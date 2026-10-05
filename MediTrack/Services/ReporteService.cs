using System;
using System.Collections.Generic;
using System.Data;
using MediTrack.Entities;

namespace MediTrack.Services
{

    public class ReporteService
    {
        public string ValidarFiltro(Reportes filtro)
        {
            if (filtro.PeriodoInicio.Date > filtro.PeriodoFin.Date)
            { 
                return "Error: La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.";
            }
            return "";
        }

        private List<RegistroAsistencia> RegistrosDelFiltro(Reportes filtro)
        {
            AsistenciaService asistenciaService = new AsistenciaService();
            asistenciaService.ActualizarFaltas();
            PersonalService personalService = new PersonalService();

            List<RegistroAsistencia> resultado = new List<RegistroAsistencia>();

            foreach (RegistroAsistencia a in asistenciaService.ListarTodas())
            {
                if (a.Estado == Estados.Programado) continue;
                if (a.InicioProgramado.Date < filtro.PeriodoInicio.Date) continue;
                if (a.InicioProgramado.Date > filtro.PeriodoFin.Date) continue;
                if (filtro.IdPersonal != 0 && a.IdPersonal != filtro.IdPersonal) continue;

                Personal p = personalService.BuscarPorId(a.IdPersonal);
                if (p == null) continue;
                if (filtro.IdArea != 0 && p.IdArea != filtro.IdArea) continue;

                resultado.Add(a);
            }
            return resultado;
        }

        // TABLAS

        public DataTable GenerarResumenAsistencia(Reportes filtro)
        {
            List<RegistroAsistencia> registros = RegistrosDelFiltro(filtro);
            PersonalService personalService = new PersonalService();
            AreaService areaService = new AreaService();

            DataTable tabla = new DataTable();
            tabla.Columns.Add("Código");
            tabla.Columns.Add("Trabajador");
            tabla.Columns.Add("Área");
            tabla.Columns.Add("Jornadas", typeof(int));
            tabla.Columns.Add("A tiempo", typeof(int));
            tabla.Columns.Add("Tardanzas", typeof(int));
            tabla.Columns.Add("Faltas", typeof(int));
            tabla.Columns.Add("Justificadas", typeof(int));
            tabla.Columns.Add("Min. tardanza", typeof(int));
            tabla.Columns.Add("Horas trabajadas", typeof(decimal));

            foreach (Personal p in personalService.ListarTodo())
            {
                int jornadas = 0, aTiempo = 0, tardanzas = 0, faltas = 0, justificadas = 0, minutos = 0;
                decimal horas = 0;

                foreach (RegistroAsistencia a in registros)
                {
                    if (a.IdPersonal != p.IdPersonal) continue;

                    jornadas++;
                    horas += a.HorasTrabajadas;
                    if (a.Estado == Estados.Presente)
                    {
                        aTiempo++;
                    }
                    if (a.Estado == Estados.Tardanza) 
                    { 
                        tardanzas++; minutos += a.MinutosTardanza; 
                    }
                    if (a.Estado == Estados.Falta)
                    {
                        faltas++;
                    }
                    if (a.Estado == Estados.Justificado) 
                    {
                        justificadas++; 
                    }
                }

                if (jornadas > 0)
                {
                    Area area = areaService.BuscarPorId(p.IdArea);
                    string nombreArea = area == null ? "" : area.Nombre;
                    tabla.Rows.Add(p.Codigo, p.NombreCompleto, nombreArea, jornadas, aTiempo, tardanzas, faltas, justificadas, minutos, horas);
                }
            }
            return tabla;
        }

        public DataTable GenerarIncidenciaDiarias(Reportes filtro)
        {
            List<RegistroAsistencia> registros = RegistrosDelFiltro(filtro);
            PersonalService personalService = new PersonalService();
            AreaService areaService = new AreaService();

            DataTable tabla = new DataTable();
            tabla.Columns.Add("Fecha");
            tabla.Columns.Add("Código");
            tabla.Columns.Add("Trabajador");
            tabla.Columns.Add("Área");
            tabla.Columns.Add("Incidencia");
            tabla.Columns.Add("Min. tardanza", typeof(int));

            foreach (RegistroAsistencia a in registros)
            {
                if (a.Estado == Estados.Presente)
                { 
                    continue; 
                }

                Personal p = personalService.BuscarPorId(a.IdPersonal);
                Area area = areaService.BuscarPorId(p.IdArea);
                string nombreArea = area == null ? "" : area.Nombre;
                tabla.Rows.Add(a.InicioProgramado.ToString("dd/MM/yyyy"), p.Codigo, p.NombreCompleto, nombreArea, a.Estado, a.MinutosTardanza);
            }
            return tabla;
        }

        public List<ItemGrafico> ObtenerDistribucionAsistencia(Reportes filtro)
        {
            List<RegistroAsistencia> registros = RegistrosDelFiltro(filtro);
            List<ItemGrafico> lista = new List<ItemGrafico>();
            if (registros.Count == 0) return lista;

            int aTiempo = 0, tardanzas = 0, faltas = 0, justificadas = 0;
            foreach (RegistroAsistencia a in registros)
            {
                if (a.Estado == Estados.Presente) aTiempo++;
                if (a.Estado == Estados.Tardanza) tardanzas++;
                if (a.Estado == Estados.Falta) faltas++;
                if (a.Estado == Estados.Justificado) justificadas++;
            }

            AgregarPorcentaje(lista, "A tiempo", aTiempo, registros.Count);
            AgregarPorcentaje(lista, "Tardanza", tardanzas, registros.Count);
            AgregarPorcentaje(lista, "Falta", faltas, registros.Count);
            AgregarPorcentaje(lista, "Justificado", justificadas, registros.Count);
            return lista;
        }

        private void AgregarPorcentaje(List<ItemGrafico> lista, string etiqueta, int cantidad, int total)
        {
            if (cantidad == 0) return;

            ItemGrafico item = new ItemGrafico();
            item.Etiqueta = etiqueta;
            item.Valor = Math.Round(cantidad * 100.0 / total, 1);
            lista.Add(item);
        }

        public List<ItemGrafico> ObtenerEvolucionAusentismo(Reportes filtro)
        {
            List<RegistroAsistencia> registros = RegistrosDelFiltro(filtro);
            List<ItemGrafico> lista = new List<ItemGrafico>();

            DateTime mes = new DateTime(filtro.PeriodoInicio.Year, filtro.PeriodoInicio.Month, 1);
            while (mes <= filtro.PeriodoFin)
            {
                int total = 0;
                int faltas = 0;
                foreach (RegistroAsistencia a in registros)
                {
                    if (a.InicioProgramado.Year == mes.Year && a.InicioProgramado.Month == mes.Month)
                    {
                        total++;
                        if (a.Estado == Estados.Falta) faltas++;
                    }
                }

                if (total > 0)
                {
                    ItemGrafico item = new ItemGrafico();
                    item.Etiqueta = mes.ToString("MM/yyyy");
                    item.Valor = Math.Round(faltas * 100.0 / total, 1);
                    lista.Add(item);
                }
                mes = mes.AddMonths(1);
            }
            return lista;
        }

        public List<ItemGrafico> ObtenerTardanzaPorArea(Reportes filtro)
        {
            List<RegistroAsistencia> registros = RegistrosDelFiltro(filtro);
            PersonalService personalService = new PersonalService();
            AreaService areaService = new AreaService();
            List<ItemGrafico> lista = new List<ItemGrafico>();

            foreach (Area area in areaService.ListarArea())
            {
                int jornadasDelArea = 0;
                int minutos = 0;

                foreach (RegistroAsistencia a in registros)
                {
                    Personal p = personalService.BuscarPorId(a.IdPersonal);
                    if (p.IdArea != area.IdArea) continue;

                    jornadasDelArea++;
                    if (a.Estado == Estados.Tardanza) minutos += a.MinutosTardanza;
                }

                if (jornadasDelArea > 0)
                {
                    ItemGrafico item = new ItemGrafico();
                    item.Etiqueta = area.Nombre;
                    item.Valor = minutos;
                    lista.Add(item);
                }
            }
            return lista;
        }
    }
}

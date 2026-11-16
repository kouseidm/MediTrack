using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Datos;

namespace Negocio
{
    public class Reportes
    {
        public DateTime PeriodoInicio { get; set; }
        public DateTime PeriodoFin { get; set; }
        public int IdArea { get; set; }       
        public int IdPersonal { get; set; }   
    }

    public class ItemGrafico
    {
        public string Etiqueta { get; set; }
        public double Valor { get; set; }
    }

    public class NReporte
    {
        private DAsistencia objDatosAsistencia = new DAsistencia();
        private DPersonal objDatosPersonal = new DPersonal();
        private DArea objDatosArea = new DArea();
        private DJustificacion objDatosJustificacion = new DJustificacion();

        public string ValidarFiltro(Reportes filtro)
        {
            if (filtro == null)
            {
                return "No se recibió el filtro del reporte.";
            }
            if (filtro.PeriodoFin.Date < filtro.PeriodoInicio.Date)
            {
                return "La fecha \"Hasta\" no puede ser menor que la fecha \"Desde\".";
            }
            return "";
        }

        private string EstadoReal(RegistroAsistencia a, DateTime ahora)
        {
            if (a.Estado == "Programado" && a.HoraIngreso == null && a.FinProgramado < ahora)
            {
                return "Falta";
            }
            return a.Estado;
        }

        private List<RegistroAsistencia> JornadasEvaluables(Reportes filtro, List<Personal> personal)
        {
            DateTime ahora = DateTime.Now;
            DateTime desde = filtro.PeriodoInicio.Date;
            DateTime hasta = filtro.PeriodoFin.Date.AddDays(1);

            List<RegistroAsistencia> lista = objDatosAsistencia.ObtenerTodos()
                .Where(a => a.InicioProgramado >= desde && a.InicioProgramado < hasta)
                .ToList();

            if (filtro.IdPersonal > 0)
            {
                lista = lista.Where(a => a.IdPersonal == filtro.IdPersonal).ToList();
            }
            if (filtro.IdArea > 0)
            {
                List<int> ids = personal.Where(p => p.IdArea == filtro.IdArea).Select(p => p.Id).ToList();
                lista = lista.Where(a => ids.Contains(a.IdPersonal)).ToList();
            }
            return lista.Where(a => EstadoReal(a, ahora) != "Programado").ToList();
        }

        private bool EstaJustificada(RegistroAsistencia a, List<Justificacion> justificaciones)
        {
            return justificaciones.Any(j => j.IdAsistencia == a.Id && j.Estado == NJustificacion.Aprobada);
        }

        public DataTable GenerarResumenAsistencia(Reportes filtro)
        {
            List<Personal> personal = objDatosPersonal.ObtenerTodos();
            List<Area> areas = objDatosArea.ObtenerTodos();
            List<Justificacion> justificaciones = objDatosJustificacion.ObtenerTodos();
            DateTime ahora = DateTime.Now;
            List<RegistroAsistencia> jornadas = JornadasEvaluables(filtro, personal);

            DataTable tabla = new DataTable();
            tabla.Columns.Add("Código");
            tabla.Columns.Add("Trabajador");
            tabla.Columns.Add("Área");
            tabla.Columns.Add("Jornadas", typeof(int));
            tabla.Columns.Add("Puntuales", typeof(int));
            tabla.Columns.Add("Tardanzas", typeof(int));
            tabla.Columns.Add("Faltas", typeof(int));
            tabla.Columns.Add("Justificadas", typeof(int));
            tabla.Columns.Add("Min. tardanza", typeof(int));
            tabla.Columns.Add("Horas trabajadas", typeof(decimal));
            tabla.Columns.Add("% Asistencia", typeof(decimal));

            foreach (IGrouping<int, RegistroAsistencia> grupo in jornadas.GroupBy(a => a.IdPersonal))
            {
                Personal p = personal.FirstOrDefault(x => x.Id == grupo.Key);
                if (p == null)
                {
                    continue;
                }
                Area area = areas.FirstOrDefault(x => x.Id == p.IdArea);

                int total = grupo.Count();
                int puntuales = grupo.Count(a => EstadoReal(a, ahora) == "Puntual");
                int tardanzas = grupo.Count(a => EstadoReal(a, ahora) == "Tardanza");
                int faltas = grupo.Count(a => EstadoReal(a, ahora) == "Falta");
                int justificadas = grupo.Count(a => EstaJustificada(a, justificaciones));
                int minutos = grupo.Sum(a => a.MinutosTardanza);
                decimal horas = grupo.Sum(a => a.HorasTrabajadas);
                decimal porcentaje = total == 0 ? 0 : Math.Round((decimal)(puntuales + tardanzas) * 100 / total, 1);

                tabla.Rows.Add(p.Codigo, p.Nombres + " " + p.Apellidos, area == null ? "" : area.Nombre,
                               total, puntuales, tardanzas, faltas, justificadas, minutos, horas, porcentaje);
            }
            return tabla;
        }

        public DataTable GenerarIncidenciasDiarias(Reportes filtro)
        {
            List<Personal> personal = objDatosPersonal.ObtenerTodos();
            List<Area> areas = objDatosArea.ObtenerTodos();
            List<Justificacion> justificaciones = objDatosJustificacion.ObtenerTodos();
            DateTime ahora = DateTime.Now;
            List<RegistroAsistencia> jornadas = JornadasEvaluables(filtro, personal);

            DataTable tabla = new DataTable();
            tabla.Columns.Add("Fecha");
            tabla.Columns.Add("Código");
            tabla.Columns.Add("Trabajador");
            tabla.Columns.Add("Área");
            tabla.Columns.Add("Incidencia");
            tabla.Columns.Add("Min. tardanza", typeof(int));
            tabla.Columns.Add("Justificación");

            foreach (RegistroAsistencia a in jornadas.OrderBy(x => x.InicioProgramado))
            {
                string estado = EstadoReal(a, ahora);
                if (estado != "Tardanza" && estado != "Falta")
                {
                    continue;
                }
                Personal p = personal.FirstOrDefault(x => x.Id == a.IdPersonal);
                if (p == null)
                {
                    continue;
                }
                Area area = areas.FirstOrDefault(x => x.Id == p.IdArea);
                Justificacion just = justificaciones.Where(j => j.IdAsistencia == a.Id)
                                                    .OrderByDescending(j => j.FechaSolicitud)
                                                    .FirstOrDefault();

                tabla.Rows.Add(a.InicioProgramado.ToString("dd/MM/yyyy"), p.Codigo, p.Nombres + " " + p.Apellidos,
                               area == null ? "" : area.Nombre, estado, a.MinutosTardanza,
                               just == null ? "Sin justificar" : just.Estado);
            }
            return tabla;
        }

        public List<ItemGrafico> ObtenerDistribucionAsistencia(Reportes filtro)
        {
            List<Personal> personal = objDatosPersonal.ObtenerTodos();
            DateTime ahora = DateTime.Now;
            List<RegistroAsistencia> jornadas = JornadasEvaluables(filtro, personal);
            List<ItemGrafico> items = new List<ItemGrafico>();
            if (jornadas.Count == 0)
            {
                return items;
            }

            foreach (string estado in new string[] { "Puntual", "Tardanza", "Falta" })
            {
                int cantidad = jornadas.Count(a => EstadoReal(a, ahora) == estado);
                items.Add(new ItemGrafico { Etiqueta = estado, Valor = cantidad * 100.0 / jornadas.Count });
            }
            return items;
        }

        public List<ItemGrafico> ObtenerEvolucionAusentismo(Reportes filtro)
        {
            List<Personal> personal = objDatosPersonal.ObtenerTodos();
            List<Justificacion> justificaciones = objDatosJustificacion.ObtenerTodos();
            DateTime ahora = DateTime.Now;
            List<RegistroAsistencia> jornadas = JornadasEvaluables(filtro, personal);

            return jornadas
                .GroupBy(a => new DateTime(a.InicioProgramado.Year, a.InicioProgramado.Month, 1))
                .OrderBy(g => g.Key)
                .Select(g => new ItemGrafico
                {
                    Etiqueta = g.Key.ToString("MM/yyyy"),
                    Valor = g.Count(a => EstadoReal(a, ahora) == "Falta" && !EstaJustificada(a, justificaciones)) * 100.0 / g.Count()
                }).ToList();
        }

        public List<ItemGrafico> ObtenerTardanzaPorArea(Reportes filtro)
        {
            List<Personal> personal = objDatosPersonal.ObtenerTodos();
            List<Area> areas = objDatosArea.ObtenerTodos();
            List<RegistroAsistencia> jornadas = JornadasEvaluables(filtro, personal);

            return jornadas
                .Join(personal, a => a.IdPersonal, p => p.Id, (a, p) => new { p.IdArea, a.MinutosTardanza })
                .GroupBy(x => x.IdArea)
                .Select(g => new ItemGrafico
                {
                    Etiqueta = areas.Where(ar => ar.Id == g.Key).Select(ar => ar.Nombre).FirstOrDefault() ?? "Sin área",
                    Valor = g.Sum(x => x.MinutosTardanza)
                })
                .OrderByDescending(i => i.Valor).ToList();
        }
    }
}

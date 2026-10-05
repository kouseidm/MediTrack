using System;
using System.Collections.Generic;
using MediTrack.Entities;
using MediTrack.Repositories;

namespace MediTrack.Services
{
    public class JustificacionService
    {
        private IJustificacionRepository repositorio = new JustificacionRepository();

        public static List<string> Tipos = new List<string> { "Inasistencia", "Tardanza", "Licencia médica", "Permiso personal" };

        private int NuevoId()
        {
            int mayor = 0;
            foreach (Justificacion j in repositorio.ObtenerTodos())
            {
                if (j.IdJustificacion > mayor)
                {
                    mayor = j.IdJustificacion;
                }
            }
            return mayor + 1;
        }

        public string RegistrarJustificacion(Justificacion justificacion)
        {
            if (!Validador.TieneTexto(justificacion.Motivo))
            {
                return "Error: El motivo es obligatorio.";
            }
            if (!Tipos.Contains(justificacion.Tipo))
            { 
                return "Error: Seleccione un tipo de justificación.";
            }

            PersonalService personalService = new PersonalService();
            Personal p = personalService.BuscarPorId(justificacion.IdPersonal);
            if (p == null || !p.Activo)
            { 
                return "Error: Seleccione un trabajador activo.";
            }

            // La justificacion se une a la jornada de ese dia
            AsistenciaService asistenciaService = new AsistenciaService();
            asistenciaService.ActualizarFaltas();
            RegistroAsistencia jornada = asistenciaService.BuscarJornada(p.IdPersonal, justificacion.FechaAusencia);
            if (jornada == null)
            { 
                return "Error: " + p.NombreCompleto + " no tiene una jornada programada en esa fecha.";
            }
            if (jornada.Estado == Estados.Presente)
            { 
                return "Error: Esa jornada no tiene falta ni tardanza que justificar.";
            }
            if (jornada.Estado == Estados.Justificado)
            { 
                return "Error: Esa jornada ya está justificada.";
            }

            // No se puede enviar dos veces la misma justificacion
            bool repetida = repositorio.Existe(j => j.IdAsistencia == jornada.IdAsistencia
                                                           && j.Estado != EstadosJustificacion.Rechazada);
            if (repetida)
                return "Error: Ya existe una justificación pendiente o aprobada para esa jornada.";

            justificacion.IdJustificacion = NuevoId();
            justificacion.IdAsistencia = jornada.IdAsistencia;
            justificacion.Motivo = justificacion.Motivo.Trim();
            justificacion.FechaSolicitud = DateTime.Now;
            justificacion.Estado = EstadosJustificacion.Pendiente;
            justificacion.FechaCreacion = DateTime.Now;
            justificacion.FechaModificacion = DateTime.Now;
            justificacion.CreadoPor = Sesion.NombreUsuario();
            justificacion.ModificadoPor = Sesion.NombreUsuario();
            repositorio.Agregar(justificacion);

            return "Justificación registrada. Queda pendiente de aprobación.";
        }

        public string Aprobar(int id)
        {
            if (!Sesion.EsGestor())
            {
                return "Error: Solo Administrador o Recursos Humanos pueden aprobar.";
            }

            Justificacion justi = BuscarPorId(id);
            if (justi == null)
            { 
                return "Error: La justificación no existe.";
            }
            if (justi.Estado != EstadosJustificacion.Pendiente)
            { 
                return "Error: La justificación ya fue " + justi.Estado.ToLower() + ".";
            }

            AsistenciaService asistenciaService = new AsistenciaService();
            RegistroAsistencia jornada = asistenciaService.BuscarPorId(justi.IdAsistencia);
            if (jornada != null)
            {
                jornada.Estado = Estados.Justificado;
                jornada.FechaModificacion = DateTime.Now;
                jornada.ModificadoPor = Sesion.NombreUsuario();
            }

            justi.Estado = EstadosJustificacion.Aprobada;
            justi.FechaModificacion = DateTime.Now;
            justi.ModificadoPor = Sesion.NombreUsuario();

            return "Justificación aprobada.";
        }

        public string Rechazar(int id)
        {
            if (!Sesion.EsGestor())
            {
                return "Error: Solo Administrador o Recursos Humanos pueden rechazar.";
            }

            Justificacion justi = BuscarPorId(id);
            if (justi == null)
            { 
                return "Error: La justificación no existe.";
            }
            if (justi.Estado != EstadosJustificacion.Pendiente)
            {
                return "Error: La justificación ya fue " + justi.Estado.ToLower() + ".";
            }

            justi.Estado = EstadosJustificacion.Rechazada;
            justi.FechaModificacion = DateTime.Now;
            justi.ModificadoPor = Sesion.NombreUsuario();

            return "Justificación rechazada.";
        }

        public List<Justificacion> Consultar(string estado)
        {
            List<Justificacion> lista = new List<Justificacion>();
            foreach (Justificacion justi in repositorio.ObtenerTodos())
            {
                if (estado == "Todos" || justi.Estado == estado)
                {
                    lista.Add(justi);
                }
            }
            return lista;
        }

        public Justificacion BuscarPorId(int id)
        {
            return repositorio.BuscarPorId(id);
        }
    }
}

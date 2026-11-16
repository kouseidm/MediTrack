using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NJustificacion
    {
        public const string Pendiente = "Pendiente";
        public const string Aprobada = "Aprobada";
        public const string Rechazada = "Rechazada";

        public static readonly string[] Tipos =
        {
            "Enfermedad", "Cita médica", "Permiso personal", "Emergencia familiar", "Otro"
        };

        private DJustificacion objDatos = new DJustificacion();
        private DAsistencia objDatosAsistencia = new DAsistencia();

        public List<Justificacion> ObtenerTodos()
        {
            return objDatos.ObtenerTodos();
        }
        public Justificacion BuscarPorId(int id)
        {
            return objDatos.BuscarPorId(id);
        }

        public List<Justificacion> Consultar(string estado)
        {
            List<Justificacion> lista = objDatos.ObtenerTodos();
            if (estado != null && estado != "" && estado != "Todos")
            {
                lista = lista.Where(j => j.Estado == estado).ToList();
            }
            return lista.OrderByDescending(j => j.FechaSolicitud).ToList();
        }

        public string Registrar(Justificacion justificacion)
        {
            if (justificacion.Tipo == "" || justificacion.Tipo == null)
            {
                return "Debe seleccionar el tipo de justificación.";
            }

            if (justificacion.Motivo == "" || justificacion.Motivo == null)
            {
                return "Debe escribir el motivo de la justificación.";
            }
            if (justificacion.IdAsistencia <= 0)
            {
                return "No se ha seleccionado el registro de asistencia a justificar.";
            }
            if (objDatos.ObtenerTodos().Any(j => j.IdAsistencia == justificacion.IdAsistencia
                                              && j.Estado != Rechazada))
            {
                return "Esa jornada ya tiene una justificación registrada.";
            }

            DateTime fechaActual = DateTime.Now;

            justificacion.Estado = Pendiente;
            justificacion.FechaSolicitud = fechaActual;
            justificacion.FechaCreacion = fechaActual;
            justificacion.FechaModificacion = fechaActual;
            justificacion.CreadoPor = NSesion.NombreUsuario;
            justificacion.ModificadoPor = NSesion.NombreUsuario;


            objDatos.Agregar(justificacion);
            return "";
        }

        public string RegistrarParaFecha(Justificacion justificacion, int idPersonal)
        {
            if (idPersonal <= 0)
            {
                return "Debe seleccionar un trabajador.";
            }
            RegistroAsistencia jornada = objDatosAsistencia.BuscarJornada(idPersonal, justificacion.FechaAusencia);
            if (jornada == null)
            {
                return "El trabajador no tiene una jornada programada en la fecha de ausencia indicada.";
            }
            justificacion.IdAsistencia = jornada.Id;
            return Registrar(justificacion);
        }

        public string Actualizar(Justificacion justificacion)
        {
            if (justificacion.Estado == "" || justificacion.Estado == null)
            {
                return "Debe seleccionar el estado de la justificación (Aprobada o Rechazada).";
            }

            DateTime fechaActual = DateTime.Now;

            justificacion.FechaModificacion = fechaActual;
            justificacion.ModificadoPor = NSesion.NombreUsuario;
            objDatos.Actualizar(justificacion);
            return "";
        }

        public string Aprobar(int id)
        {
            return Resolver(id, Aprobada);
        }

        public string Rechazar(int id)
        {
            return Resolver(id, Rechazada);
        }

        private string Resolver(int id, string nuevoEstado)
        {
            if (NSesion.EsGestor() == false)
            {
                return "Solo Administrador o RRHH pueden aprobar o rechazar justificaciones.";
            }
            Justificacion justificacion = objDatos.BuscarPorId(id);
            if (justificacion == null)
            {
                return "No se encontró la justificación seleccionada.";
            }
            if (justificacion.Estado != Pendiente)
            {
                return "Solo se pueden resolver justificaciones pendientes.";
            }
            justificacion.Estado = nuevoEstado;
            return Actualizar(justificacion);
        }
    }
}

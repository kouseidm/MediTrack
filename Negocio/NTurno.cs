using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NTurno
    {
        private DTurno objDatos = new DTurno();
        private DPersonal objDatosPersonal = new DPersonal();

        public List<Turno> ObtenerTodos()
        {
            return objDatos.ObtenerTodos();
        }
        public Turno BuscarPorId(int id)
        {
            return objDatos.BuscarPorId(id);
        }
        public string Registrar(Turno turno)
        {
            if (turno.Nombre == "" || turno.Nombre == null)
            {
                return "El nombre del turno es obligatorio.";
            }

            if (turno.Descripcion == "" || turno.Descripcion == null)
            {
                return "La descripción del turno es obligatoria.";
            }
            if (turno.HoraInicio.TimeOfDay == turno.HoraFin.TimeOfDay)
            {
                return "La hora de inicio y la hora de fin no pueden ser iguales.";
            }
            if (turno.ToleranciaMin < 0)
            {
                return "La tolerancia en minutos no puede ser un número negativo.";
            }
            if (objDatos.Existe(turno.Nombre, 0) == true)
            {
                return "Ya existe un turno registrado con ese nombre.";
            }

            turno.FechaCreacion = DateTime.Now;
            turno.FechaModificacion = DateTime.Now;
            turno.CreadoPor = NSesion.NombreUsuario;
            turno.ModificadoPor = NSesion.NombreUsuario;
            turno.Activo = true;

            objDatos.Agregar(turno);
            return "";
        }

        public string Actualizar(Turno turno)
        {
            if (turno.Nombre == "" || turno.Nombre == null)
            {
                return "El nombre del turno es obligatorio.";
            }
            if (turno.Descripcion == "" || turno.Descripcion == null)
            {
                return "La descripción del turno es obligatoria.";
            }
            if (turno.HoraInicio.TimeOfDay == turno.HoraFin.TimeOfDay)
            {
                return "La hora de inicio y la hora de fin no pueden ser iguales.";
            }
            if (turno.ToleranciaMin < 0)
            {
                return "La tolerancia en minutos no puede ser un número negativo.";
            }
            if (objDatos.Existe(turno.Nombre, turno.Id) == true)
            {
                return "Otro registro ya utiliza este nombre de turno.";
            }
            turno.FechaModificacion = DateTime.Now;
            turno.ModificadoPor = NSesion.NombreUsuario;
            objDatos.Actualizar(turno);
            return "";
        }

        public string Desactivar(int id)
        {
            Turno turno = objDatos.BuscarPorId(id);
            if (turno == null)
            {
                return "No se encontró el turno seleccionado.";
            }
            if (turno.Activo == false)
            {
                return "El turno ya está desactivado.";
            }
            if (objDatosPersonal.ExisteActivoEnTurno(id) == true)
            {
                return "No se puede desactivar: hay personal activo asignado a este turno.";
            }
            turno.Activo = false;
            turno.FechaModificacion = DateTime.Now;
            turno.ModificadoPor = NSesion.NombreUsuario;
            objDatos.Actualizar(turno);
            return "";
        }

        public string Activar(int id)
        {
            Turno turno = objDatos.BuscarPorId(id);
            if (turno == null)
            {
                return "No se encontró el turno seleccionado.";
            }
            if (turno.Activo == true)
            {
                return "El turno ya está activo.";
            }
            turno.Activo = true;
            turno.FechaModificacion = DateTime.Now;
            turno.ModificadoPor = NSesion.NombreUsuario;
            objDatos.Actualizar(turno);
            return "";
        }
    }
}

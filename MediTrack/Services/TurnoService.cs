using System;
using System.Collections.Generic;
using MediTrack.Entities;
using MediTrack.Repositories;

namespace MediTrack.Services
{
    public class TurnoService
    {
        private ITurnoRepository repositorio = new TurnoRepository();
        private static bool datosCargados = false;

        public TurnoService()
        {
            if (!datosCargados)
            {
                datosCargados = true;
                CargarDatosIniciales();
            }
        }

        private void CargarDatosIniciales()
        {
            CrearInicial("Mañana", 7, 15, "Turno de la mañana");
            CrearInicial("Tarde", 15, 23, "Turno de la tarde");
            CrearInicial("Noche", 23, 7, "Turno nocturno (termina al día siguiente)");
        }

        private void CrearInicial(string nombre, int horaInicio, int horaFin, string descripcion)
        {
            Turno turno = new Turno();

            turno.IdTurno = NuevoId();
            turno.Nombre = nombre;
            turno.HoraInicio = DateTime.Today.AddHours(horaInicio);
            turno.HoraFin = DateTime.Today.AddHours(horaFin);
            turno.ToleranciaMin = 10;
            turno.Descripcion = descripcion;
            turno.Activo = true;
            turno.FechaCreacion = DateTime.Now;
            turno.FechaModificacion = DateTime.Now;
            turno.CreadoPor = "sistema";
            turno.ModificadoPor = "sistema";
            repositorio.Agregar(turno);
        }

        private int NuevoId()
        {
            int mayor = 0;
            foreach (Turno turno in repositorio.ObtenerTodos())
            {
                if (turno.IdTurno > mayor)
                {
                    mayor = turno.IdTurno;
                }
            }
            return mayor + 1;
        }

        private bool NombreRepetido(string nombre, int idActual)
        {
            return repositorio.Existe(t => t.IdTurno != idActual && t.Nombre.ToLower() == nombre.Trim().ToLower());
        }

        private DateTime SoloHora(DateTime fecha)
        {
            return DateTime.Today.AddHours(fecha.Hour).AddMinutes(fecha.Minute);
        }

        private string ValidarDatos(Turno turno, int idActual)
        {
            if (!Validador.TieneTexto(turno.Nombre))
            {
                return "Error: El nombre del turno es obligatorio.";
            }
            if (NombreRepetido(turno.Nombre, idActual))
            {
                return "Error: Ya existe un turno con ese nombre.";
            }
            if (SoloHora(turno.HoraInicio) == SoloHora(turno.HoraFin))
            { 
                return "Error: La hora de inicio y la hora de fin no pueden ser iguales.";
            }
            if (turno.ToleranciaMin < 0 || turno.ToleranciaMin > 60)
            { 
                return "Error: La tolerancia debe estar entre 0 y 60 minutos.";
            }
            return "";
        }

        public string RegistrarTurno(Turno turno)
        {
            string error = ValidarDatos(turno, 0);
            if (error != "")
            { 
                return error;
            }

            turno.IdTurno = NuevoId();
            turno.Nombre = turno.Nombre.Trim();
            turno.HoraInicio = SoloHora(turno.HoraInicio);
            turno.HoraFin = SoloHora(turno.HoraFin);
            if (turno.Descripcion == null)
            {
                turno.Descripcion = "";
            }
            turno.Activo = true;
            turno.FechaCreacion = DateTime.Now;
            turno.FechaModificacion = DateTime.Now;
            turno.CreadoPor = Sesion.NombreUsuario();
            turno.ModificadoPor = Sesion.NombreUsuario();
            repositorio.Agregar(turno);

            return "Turno registrado correctamente.";
        }

        public string ActualizarTurno(Turno datos)
        {
            Turno turno = BuscarPorId(datos.IdTurno);
            if (turno == null)
            { 
                return "Error: El turno no existe.";
            }

            string error = ValidarDatos(datos, turno.IdTurno);
            if (error != "")
            { 
                return error;
            }

            turno.Nombre = datos.Nombre.Trim();
            turno.HoraInicio = SoloHora(datos.HoraInicio);
            turno.HoraFin = SoloHora(datos.HoraFin);
            turno.ToleranciaMin = datos.ToleranciaMin;
            turno.Descripcion = datos.Descripcion == null ? "" : datos.Descripcion;
            turno.FechaModificacion = DateTime.Now;
            turno.ModificadoPor = Sesion.NombreUsuario();

            return "Turno actualizado correctamente (las jornadas ya programadas no cambian).";
        }

        public string DesactivarTurno(int id)
        {
            Turno turno = BuscarPorId(id);
            if (turno == null)
            { 
                return "Error: El turno no existe.";
            }
            if (!turno.Activo)
            {
                return "Error: El turno ya está inactivo.";
            }

            PersonalService personalService = new PersonalService();
            if (personalService.HayPersonalActivoEnTurno(id))
            { 
                return "Error: El turno tiene personal activo asignado.";
            }

            turno.Activo = false;
            turno.FechaModificacion = DateTime.Now;
            turno.ModificadoPor = Sesion.NombreUsuario();

            return "Turno desactivado correctamente.";
        }

        public List<Turno> ListarTurnos()
        {
            return repositorio.ObtenerTodos();
        }

        public List<Turno> ListarActivos()
        {
            List<Turno> activos = new List<Turno>();
            foreach (Turno turno in repositorio.ObtenerTodos())
            {
                if (turno.Activo)
                {
                    activos.Add(turno);
                }
            }
            return activos;
        }

        public Turno BuscarPorId(int id)
        {
            return repositorio.BuscarPorId(id);
        }
    }
}

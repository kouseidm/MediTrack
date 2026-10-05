using System;
using System.Collections.Generic;
using MediTrack.Entities;
using MediTrack.Repositories;

namespace MediTrack.Services
{
    public class AsistenciaService
    {
        private IAsistenciaRepository repositorio = new AsistenciaRepository();
        private static bool datosCargados = false;

        public AsistenciaService()
        {
            if (!datosCargados)
            {
                datosCargados = true;
                CargarHistorialInicial();
            }
        }

        // datos de prueba 
       
        private void CargarHistorialInicial()
        {
            PersonalService personalService = new PersonalService();
            TurnoService turnoService = new TurnoService();

            string[] codigos = { "ENF001", "EME001" };
            foreach (string codigo in codigos)
            {
                Personal p = personalService.BuscarPorCodigo(codigo);
                Turno turno = turnoService.BuscarPorId(p.IdTurno);

                for (int dias = 90; dias >= 1; dias--)
                {
                    DateTime fecha = DateTime.Today.AddDays(-dias);
                    RegistroAsistencia a = CrearJornada(p.IdPersonal, turno, fecha);
                    a.IdAsistencia = NuevoId();
                    a.CreadoPor = "sistema";
                    a.ModificadoPor = "sistema";

                    int patron = (dias + p.IdPersonal) % 9;
                    if (patron == 0)
                    {
                        a.Estado = Estados.Falta;
                    }
                    else
                    {
                        if (patron == 4)
                            a.HoraIngreso = a.InicioProgramado.AddMinutes(15 + dias % 10);
                        else
                            a.HoraIngreso = a.InicioProgramado.AddMinutes(-5);

                        a.HoraSalida = a.FinProgramado;
                        a.MinutosTardanza = CalcularTardanza(a);
                        a.HorasTrabajadas = CalcularHorasTrabajadas(a);
                        a.Estado = a.MinutosTardanza > 0 ? Estados.Tardanza : Estados.Presente;
                    }
                    repositorio.Agregar(a);
                }
            }
        }

        private int NuevoId()
        {
            int mayor = 0;
            foreach (RegistroAsistencia a in repositorio.ObtenerTodos())
            {
                if (a.IdAsistencia > mayor)
                {
                    mayor = a.IdAsistencia;
                }
            }
            return mayor + 1;
        }

        // Arma una jornada con el horario del turno para una fecha (todavia no la guarda)
        private RegistroAsistencia CrearJornada(int idPersonal, Turno turno, DateTime fecha)
        {
            RegistroAsistencia a = new RegistroAsistencia();
            a.IdPersonal = idPersonal;
            a.InicioProgramado = fecha.Date.Add(turno.HoraInicio.TimeOfDay);
            a.FinProgramado = fecha.Date.Add(turno.HoraFin.TimeOfDay);

            // Turno nocturno: termina al dia siguiente
            if (a.FinProgramado <= a.InicioProgramado)
            {
                a.FinProgramado = a.FinProgramado.AddDays(1);
            }

            a.MinutosTardanza = 0;
            a.HorasTrabajadas = 0;
            a.Estado = Estados.Programado;
            a.FechaCreacion = DateTime.Now;
            a.FechaModificacion = DateTime.Now;
            a.CreadoPor = Sesion.NombreUsuario();
            a.ModificadoPor = Sesion.NombreUsuario();
            return a;
        }


        // Guarda la jornada si no se cruza con otra.
        public bool ProgramarJornada(RegistroAsistencia asistencia)
        {
            if (ValidarSuperposicion(asistencia.IdPersonal, asistencia.InicioProgramado, asistencia.FinProgramado))
                return false;

            asistencia.IdAsistencia = NuevoId();
            repositorio.Agregar(asistencia);
            return true;
        }

        // Devuelve true si el trabajador ya tiene una jornada que se cruza con ese horario
        public bool ValidarSuperposicion(int idPersonal, DateTime inicio, DateTime fin)
        {
            foreach (RegistroAsistencia a in repositorio.ObtenerTodos())
            {
                if (a.IdPersonal == idPersonal && inicio < a.FinProgramado && a.InicioProgramado < fin)
                {
                    return true;
                }
            }
            return false;
        }

        // Programa la jornada de un trabajador usando su turno asignado
        public string ProgramarJornadaDesdeTurno(int idPersonal, DateTime fecha)
        {
            PersonalService personalService = new PersonalService();
            Personal p = personalService.BuscarPorId(idPersonal);
            if (p == null || !p.Activo)
            { 
                return "Error: El trabajador no existe o está inactivo.";
            }

            TurnoService turnoService = new TurnoService();
            Turno turno = turnoService.BuscarPorId(p.IdTurno);
            if (turno == null || !turno.Activo)
            {
                return "Error: El trabajador no tiene un turno activo asignado.";
            }
            RegistroAsistencia jornada = CrearJornada(p.IdPersonal, turno, fecha);
            if (!ProgramarJornada(jornada))
            {
                return "Error: " + p.NombreCompleto + " ya tiene una jornada que se cruza con ese horario.";
            }
            return "Jornada programada para " + p.NombreCompleto + ": "
                   + jornada.InicioProgramado.ToString("dd/MM/yyyy HH:mm") + " a "
                   + jornada.FinProgramado.ToString("dd/MM/yyyy HH:mm") + ".";
        }

        // Programa la jornada de todo el personal activo
        public string ProgramarJornadaMasiva(DateTime fecha)
        {
            PersonalService personalService = new PersonalService();
            int programadas = 0;
            int omitidas = 0;

            foreach (Personal p in personalService.ListarActivos())
            {
                string resultado = ProgramarJornadaDesdeTurno(p.IdPersonal, fecha);
                if (Validador.EsError(resultado))
                    omitidas++;
                else
                    programadas++;
            }

            return "Jornadas programadas: " + programadas + ". Omitidas (ya existían o sin turno): " + omitidas + ".";
        }

        public string RegistrarIngreso(string codigo)
        {
            ActualizarFaltas();

            PersonalService personalService = new PersonalService();
            Personal p = personalService.BuscarPorCodigo(codigo);
            if (p == null || !p.Activo)
                return "Error: Código de trabajador no válido o inactivo.";

            // Busca una jornada programada que este en curso (se puede marcar desde 60 min antes)
            DateTime ahora = DateTime.Now;
            RegistroAsistencia jornada = repositorio.Buscar(a =>
                a.IdPersonal == p.IdPersonal &&
                a.Estado == Estados.Programado &&
                a.HoraIngreso == null &&
                ahora >= a.InicioProgramado.AddMinutes(-60) &&
                ahora <= a.FinProgramado);

            if (jornada == null)
            {
                if (repositorio.Existe(a => a.IdPersonal == p.IdPersonal && a.HoraIngreso != null && a.HoraSalida == null))
                {
                    return "Error: " + p.NombreCompleto + " ya registró su ingreso. Registre su salida.";
                }
                return "Error: " + p.NombreCompleto + " no tiene una jornada programada para este momento.";
            }

            jornada.HoraIngreso = ahora;
            jornada.MinutosTardanza = CalcularTardanza(jornada);
            jornada.Estado = jornada.MinutosTardanza > 0 ? Estados.Tardanza : Estados.Presente;
            jornada.FechaModificacion = DateTime.Now;
            jornada.ModificadoPor = Sesion.NombreUsuario();

            string mensaje = "Ingreso registrado: " + p.NombreCompleto + " a las " + ahora.ToString("HH:mm") + ".";
            if (jornada.MinutosTardanza > 0)
            { 
                mensaje += " Tardanza de " + jornada.MinutosTardanza + " minutos.";
            }
            return mensaje;
        }

        public string RegistrarSalida(string codigo)
        {
            ActualizarFaltas();

            PersonalService personalService = new PersonalService();
            Personal p = personalService.BuscarPorCodigo(codigo);
            if (p == null || !p.Activo)
            {
                return "Error: Código de trabajador no válido o inactivo.";
            }

            // La jornada que tiene ingreso pero todavia no tiene salida
            RegistroAsistencia jornada = repositorio.Buscar(a =>
                a.IdPersonal == p.IdPersonal && a.HoraIngreso != null && a.HoraSalida == null);
            if (jornada == null)
            { 
                return "Error: " + p.NombreCompleto + " no tiene un ingreso pendiente de salida.";
            }

            jornada.HoraSalida = DateTime.Now;
            jornada.HorasTrabajadas = CalcularHorasTrabajadas(jornada);
            jornada.FechaModificacion = DateTime.Now;
            jornada.ModificadoPor = Sesion.NombreUsuario();

            return "Salida registrada: " + p.NombreCompleto + " a las " + jornada.HoraSalida.Value.ToString("HH:mm")
                   + ". Horas trabajadas: " + jornada.HorasTrabajadas + ".";
        }

        public int CalcularTardanza(RegistroAsistencia asistencia)
        {
            if (asistencia.HoraIngreso == null)
            {
                return 0;
            }

            PersonalService personalService = new PersonalService();
            Personal p = personalService.BuscarPorId(asistencia.IdPersonal);

            int tolerancia = 0;
            if (p != null)
            {
                TurnoService turnoService = new TurnoService();
                Turno turno = turnoService.BuscarPorId(p.IdTurno);
                if (turno != null)
                {
                    tolerancia = turno.ToleranciaMin;
                }
            }

            double minutos = (asistencia.HoraIngreso.Value - asistencia.InicioProgramado).TotalMinutes;
            if (minutos > tolerancia)
                return (int)minutos;
            return 0;
        }

        public decimal CalcularHorasTrabajadas(RegistroAsistencia asistencia)
        {
            if (asistencia.HoraIngreso == null || asistencia.HoraSalida == null) return 0;

            double horas = (asistencia.HoraSalida.Value - asistencia.HoraIngreso.Value).TotalHours;
            return Math.Round((decimal)horas, 2);
        }

        public void ActualizarFaltas()
        {
            DateTime ahora = DateTime.Now;

            foreach (RegistroAsistencia a in repositorio.ObtenerTodos())
            {
                if (a.Estado == Estados.Programado && a.HoraIngreso == null && ahora > a.FinProgramado)
                {
                    a.Estado = Estados.Falta;
                    a.FechaModificacion = DateTime.Now;
                }

                if (a.HoraIngreso != null && a.HoraSalida == null && ahora > a.FinProgramado.AddHours(12))
                {
                    a.HoraSalida = a.FinProgramado;
                    a.HorasTrabajadas = CalcularHorasTrabajadas(a);
                    a.FechaModificacion = DateTime.Now;
                }
            }
        }

        public List<RegistroAsistencia> ListarPorPersonal(int idPersonal)
        {
            List<RegistroAsistencia> lista = new List<RegistroAsistencia>();
            foreach (RegistroAsistencia a in repositorio.ObtenerTodos())
            {
                if (idPersonal == 0 || a.IdPersonal == idPersonal)
                {
                    lista.Add(a);
                }
            }
            lista.Sort((x, y) => y.InicioProgramado.CompareTo(x.InicioProgramado));
            return lista;
        }

        public List<RegistroAsistencia> ListarTodas()
        {
            return repositorio.ObtenerTodos();
        }

        public RegistroAsistencia BuscarPorId(int id)
        {
            return repositorio.BuscarPorId(id);
        }

        public RegistroAsistencia BuscarJornada(int idPersonal, DateTime fecha)
        {
            return repositorio.BuscarJornada(idPersonal, fecha);
        }
    }
}

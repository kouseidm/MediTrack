using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NAsistencia
    {
        private DAsistencia objDatosAsistencia = new DAsistencia();
        private DPersonal objDatosPersonal = new DPersonal();
        private DTurno objDatosTurno = new DTurno();
        public List<RegistroAsistencia> ObtenerTodos()
        {
            return objDatosAsistencia.ObtenerTodos();
        }
        public RegistroAsistencia BuscarPorId(int id)
        {
            return objDatosAsistencia.BuscarPorId(id);
        }

        public List<RegistroAsistencia> ListarPorPersonal(int idPersonal)
        {
            List<RegistroAsistencia> lista = objDatosAsistencia.ObtenerTodos();
            if (idPersonal > 0)
            {
                lista = lista.Where(a => a.IdPersonal == idPersonal).ToList();
            }
            return lista.OrderByDescending(a => a.InicioProgramado).ToList();
        }

        public List<RegistroAsistencia> ListarPorArea(int idArea)
        {
            List<int> personalDelArea = objDatosPersonal.ObtenerTodos()
                .Where(p => p.IdArea == idArea)
                .Select(p => p.Id)
                .ToList();

            return objDatosAsistencia.ObtenerTodos()
                .Where(a => personalDelArea.Contains(a.IdPersonal))
                .OrderByDescending(a => a.InicioProgramado)
                .ToList();
        }

        public string ProgramarJornada(RegistroAsistencia asistencia)
        {
            if (asistencia.IdPersonal <= 0)
            {
                return "Debe seleccionar un trabajador.";
            }
            if (asistencia.FinProgramado <= asistencia.InicioProgramado)
            {
                return "La hora de fin debe ser posterior a la hora de inicio.";
            }
            RegistroAsistencia jornadaExistente = objDatosAsistencia.BuscarJornada
                                                                    (asistencia.IdPersonal,
                                                                    asistencia.InicioProgramado);
            if (jornadaExistente != null)
            {
                return "El trabajador ya tiene una jornada programada para esa fecha.";
            }
            asistencia.Estado = "Programado";
            asistencia.MinutosTardanza = 0;
            asistencia.HorasTrabajadas = 0;
            asistencia.FechaCreacion = DateTime.Now;
            asistencia.FechaModificacion = DateTime.Now;
            asistencia.CreadoPor = NSesion.NombreUsuario;
            asistencia.ModificadoPor = NSesion.NombreUsuario;
            objDatosAsistencia.Agregar(asistencia);
            return "";
        }

        private RegistroAsistencia ArmarJornada(Personal empleado, Turno turno, DateTime fecha)
        {
            DateTime inicio = fecha.Date + turno.HoraInicio.TimeOfDay;
            DateTime fin = fecha.Date + turno.HoraFin.TimeOfDay;
            if (fin <= inicio)
            {
                fin = fin.AddDays(1);
            }

            RegistroAsistencia jornada = new RegistroAsistencia();
            jornada.IdPersonal = empleado.Id;
            jornada.InicioProgramado = inicio;
            jornada.FinProgramado = fin;
            return jornada;
        }

        public string ProgramarJornadaDesdeTurno(int idPersonal, DateTime fecha)
        {
            if (idPersonal <= 0)
            {
                return "Debe seleccionar un trabajador.";
            }
            Personal empleado = objDatosPersonal.BuscarPorId(idPersonal);
            if (empleado == null)
            {
                return "No se encontró al trabajador.";
            }
            if (empleado.Activo == false)
            {
                return "El trabajador está desactivado.";
            }
            Turno turno = objDatosTurno.BuscarPorId(empleado.IdTurno);
            if (turno == null)
            {
                return "El trabajador no tiene un turno asignado.";
            }
            if (turno.Activo == false)
            {
                return "El turno asignado al trabajador está desactivado.";
            }
            return ProgramarJornada(ArmarJornada(empleado, turno, fecha));
        }

        public string ProgramarJornadaMasiva(DateTime fecha, int idArea, out int programadas)
        {
            programadas = 0;
            if (idArea <= 0)
            {
                return "Debe seleccionar un área.";
            }

            List<Turno> turnos = objDatosTurno.ObtenerTodos();

            foreach (Personal empleado in objDatosPersonal.ObtenerTodos()
                .Where(p => p.Activo && p.IdArea == idArea))
            {
                Turno turno = turnos.FirstOrDefault(t => t.Id == empleado.IdTurno && t.Activo);
                if (turno == null)
                {
                    continue;
                }
                string error = ProgramarJornada(ArmarJornada(empleado, turno, fecha));
                if (error == "")
                {
                    programadas++;
                }
            }
            return "";
        }

        public void ActualizarFaltas()
        {
            DateTime ahora = DateTime.Now;
            List<RegistroAsistencia> pendientes = objDatosAsistencia.ObtenerTodos()
                .Where(a => a.Estado == "Programado" && a.HoraIngreso == null && a.FinProgramado < ahora)
                .ToList();

            foreach (RegistroAsistencia jornada in pendientes)
            {
                jornada.Estado = "Falta";
                jornada.FechaModificacion = ahora;
                jornada.ModificadoPor = NSesion.NombreUsuario;
                objDatosAsistencia.Actualizar(jornada);
            }
        }

        public string RegistrarIngreso(string codigo)
        {
            if (codigo == "" || codigo == null)
            {
                return "Debe ingresar su código de trabajador.";
            }
            Personal empleado = objDatosPersonal.BuscarPorCodigo(codigo);

            if (empleado == null)
            {
                return "El código ingresado no existe.";
            }
            if (empleado.Activo == false)
            {
                return "El trabajador está desactivado.";
            }

            if (objDatosAsistencia.ExisteIngresoPendiente(empleado.Id) == true)
            {
                return "Ya tiene un ingreso registrado. Debe marcar su salida primero.";
            }
            DateTime horaActual = DateTime.Now;
            RegistroAsistencia jornada = objDatosAsistencia.BuscarJornadaEnCurso
                                                            (empleado.Id, horaActual, "Programado");
            if (jornada == null)
            {
                return "No tiene un turno programado para este horario.";
            }

            Turno turnoDelEmpleado = objDatosTurno.BuscarPorId(empleado.IdTurno);
            int minutosDeTolerancia = 0;

            if (turnoDelEmpleado != null)
            {
                minutosDeTolerancia = turnoDelEmpleado.ToleranciaMin;
            }
            DateTime horaLimite = jornada.InicioProgramado.AddMinutes(minutosDeTolerancia);
            int minutosTardanza = 0;
            string estadoAsistencia = "Puntual";
            if (horaActual > horaLimite)
            {
                double totalMinutos = (horaActual - jornada.InicioProgramado).TotalMinutes;
                minutosTardanza = (int)totalMinutos;
                estadoAsistencia = "Tardanza";
            }
            jornada.HoraIngreso = horaActual;
            jornada.MinutosTardanza = minutosTardanza;
            jornada.Estado = estadoAsistencia;
            jornada.FechaModificacion = horaActual;
            jornada.ModificadoPor = empleado.Usuario;
            objDatosAsistencia.Actualizar(jornada);
            return "";
        }
        public string RegistrarSalida(string codigo)
        {
            if (codigo == "" || codigo == null)
            {
                return "Debe ingresar su código de trabajador.";
            }
            Personal empleado = objDatosPersonal.BuscarPorCodigo(codigo);

            if (empleado == null)
            {
                return "El código ingresado no existe.";
            }
            RegistroAsistencia jornada = objDatosAsistencia.BuscarIngresoPendiente(empleado.Id);
            if (jornada == null)
            {
                return "No se encontró un ingreso registrado. No puede marcar salida.";
            }
            DateTime horaActual = DateTime.Now;
            DateTime horaQueIngreso = Convert.ToDateTime(jornada.HoraIngreso);
            TimeSpan diferencia = horaActual - horaQueIngreso;
            decimal totalHoras = Math.Round(Convert.ToDecimal(diferencia.TotalHours), 2);

            jornada.HoraSalida = horaActual;
            jornada.HorasTrabajadas = totalHoras;
            jornada.FechaModificacion = horaActual;
            jornada.ModificadoPor = empleado.Usuario;

            objDatosAsistencia.Actualizar(jornada);

            return "";
        }
    }
}

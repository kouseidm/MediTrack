using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DAsistencia
    {
        public List<RegistroAsistencia> ObtenerTodos()
        {
            using (var context = new dbMediTrackEntities())
            {
                return context.RegistroAsistencia.ToList();
            }
        }

        public RegistroAsistencia BuscarPorId(int id)
        {
            using (var context = new dbMediTrackEntities())
            {
                return context.RegistroAsistencia.FirstOrDefault(a => a.Id == id);
            }
        }

        public RegistroAsistencia BuscarJornada(int idPersonal, DateTime fecha)
        {
            DateTime inicioDia = fecha.Date;
            DateTime finDia = inicioDia.AddDays(1);

            using (var context = new dbMediTrackEntities())
            {
                return context.RegistroAsistencia.FirstOrDefault(a => a.IdPersonal == idPersonal
                                                                   && a.InicioProgramado >= inicioDia
                                                                   && a.InicioProgramado < finDia);
            }
        }

        public RegistroAsistencia BuscarJornadaEnCurso(int idPersonal, DateTime ahora, string estadoProgramado)
        {
            DateTime limite = ahora.AddMinutes(60);

            using (var context = new dbMediTrackEntities())
            {
                return context.RegistroAsistencia.FirstOrDefault(a => a.IdPersonal == idPersonal
                                                                   && a.Estado == estadoProgramado
                                                                   && a.HoraIngreso == null
                                                                   && a.InicioProgramado <= limite
                                                                   && ahora <= a.FinProgramado);
            }

        }

        public RegistroAsistencia BuscarIngresoPendiente(int idPersonal)
        {
            using (var context = new dbMediTrackEntities())
            {
                return context.RegistroAsistencia.FirstOrDefault(a => a.IdPersonal == idPersonal
                                                                   && a.HoraIngreso != null
                                                                   && a.HoraSalida == null);
            }
        }
        public bool ExisteIngresoPendiente(int idPersonal)
        {
            using (var context = new dbMediTrackEntities())
            {
                return context.RegistroAsistencia.Any(a => a.IdPersonal == idPersonal
                                                        && a.HoraIngreso != null
                                                        && a.HoraSalida == null);
            }
        }

        public void Agregar(RegistroAsistencia asistencia)
        {
            using (var context = new dbMediTrackEntities())
            {
                context.RegistroAsistencia.Add(asistencia);
                context.SaveChanges();
            }
        }

        public void Actualizar(RegistroAsistencia asistencia)
        {
            using (var context = new dbMediTrackEntities())
            {
                RegistroAsistencia actual = context.RegistroAsistencia.FirstOrDefault(a => a.Id == asistencia.Id);
                if (actual == null)
                {
                    return;
                }

                actual.HoraIngreso = asistencia.HoraIngreso;
                actual.HoraSalida = asistencia.HoraSalida;
                actual.MinutosTardanza = asistencia.MinutosTardanza;
                actual.HorasTrabajadas = asistencia.HorasTrabajadas;
                actual.Estado = asistencia.Estado;
                actual.FechaModificacion = asistencia.FechaModificacion;
                actual.ModificadoPor = asistencia.ModificadoPor;
                context.SaveChanges();
            }
        }

    }
}

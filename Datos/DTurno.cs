using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DTurno
    {
        public List<Turno> ObtenerTodos()
        {
            using (var context = new dbMediTrackEntities())
            {
                return context.Turno.ToList();
            }
        }

        public Turno Buscar(string nombre)
        {
            using (var context = new dbMediTrackEntities())
            {
                return context.Turno.FirstOrDefault(t => t.Nombre == nombre);
            }
        }

        public bool Existe(string nombre, int idActual)
        {
            using (var context = new dbMediTrackEntities())
            {
                return context.Turno.Any(t => t.Id != idActual && t.Nombre == nombre);
            }
        }

        public void Agregar(Turno turno)
        {
            using (var context = new dbMediTrackEntities())
            {
                context.Turno.Add(turno);
                context.SaveChanges();
            }
        }

        public Turno BuscarPorId(int id)
        {
            using (var context = new dbMediTrackEntities())
            {
                return context.Turno.FirstOrDefault(t => t.Id == id);
            }
        }

        public void Actualizar(Turno turno)
        {
            using (var context = new dbMediTrackEntities())
            {
                Turno actual = context.Turno.FirstOrDefault(t => t.Id == turno.Id);
                if (actual == null)
                {
                    return;
                }

                actual.Nombre = turno.Nombre;
                actual.HoraInicio = turno.HoraInicio;
                actual.HoraFin = turno.HoraFin;
                actual.ToleranciaMin = turno.ToleranciaMin;
                actual.Descripcion = turno.Descripcion;
                actual.Activo = turno.Activo;
                actual.FechaModificacion = turno.FechaModificacion;
                actual.ModificadoPor = turno.ModificadoPor;
                context.SaveChanges();
            }
        }

    }
}

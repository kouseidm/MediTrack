using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DArea
    {
        public List<Area> ObtenerTodos()
        {
            using (var context = new dbMediTrackEntities())
            {
                return context.Area.ToList();
            }
        }

        public bool Existe(string nombre, int idActual)
        {
            using (var context = new dbMediTrackEntities())
            {
                return context.Area.Any(a => a.Id != idActual && a.Nombre == nombre);
            }
        }


        public Area BuscarPorId(int id)
        {
            using (var context = new dbMediTrackEntities())
            {
                return context.Area.FirstOrDefault(a => a.Id == id);
            }
        }

        public void Agregar(Area area)
        {
            using (var context = new dbMediTrackEntities())
            {
                context.Area.Add(area);
                context.SaveChanges();
            }
        }


        public void Actualizar(Area area)
        {
            using (var context = new dbMediTrackEntities())
            {
                Area actual = context.Area.FirstOrDefault(a => a.Id == area.Id);
                if (actual == null)
                {
                    return;
                }

                actual.Nombre = area.Nombre;
                actual.Descripcion = area.Descripcion;
                actual.Activo = area.Activo;
                actual.FechaModificacion = area.FechaModificacion;
                actual.ModificadoPor = area.ModificadoPor;
                context.SaveChanges();
            }
        }

    }
}

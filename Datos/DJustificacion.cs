using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DJustificacion
    {

        public List<Justificacion> ObtenerTodos()
        {
            using (var context = new dbMediTrackEntities())
            {
                return context.Justificacion.ToList();
            }
        }

        public Justificacion BuscarPorId(int id)
        {
            using (var context = new dbMediTrackEntities())
            {
                return context.Justificacion.FirstOrDefault(j => j.Id == id);
            }
        }

        public void Agregar(Justificacion justificacion)
        {
            using (var context = new dbMediTrackEntities())
            {
                context.Justificacion.Add(justificacion);
                context.SaveChanges();
            }
        }

        public void Actualizar(Justificacion justificacion)
        {
            using (var context = new dbMediTrackEntities())
            {
                Justificacion actual = context.Justificacion.FirstOrDefault(j => j.Id == justificacion.Id);
                if (actual == null)
                {
                    return;
                }

                actual.Estado = justificacion.Estado;
                actual.FechaModificacion = justificacion.FechaModificacion;
                actual.ModificadoPor = justificacion.ModificadoPor;
                context.SaveChanges();
            }
        }
    }
}

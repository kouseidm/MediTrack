using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DPersonal
    {
        public List<Personal> ObtenerTodos()
        {
            using (var context = new dbMediTrackEntities())
            {
                return context.Personal.ToList();
            }
        }

        public Personal Buscar(string usuario)
        {
            using (var context = new dbMediTrackEntities())
            {
                return context.Personal.FirstOrDefault(p => p.Usuario == usuario
                                                         && p.Activo);
            }
        }

        public Personal BuscarPorId(int id)
        {
            using (var context = new dbMediTrackEntities())
            {
                return context.Personal.FirstOrDefault(p => p.Id == id);
            }
        }

        public Personal BuscarPorCodigo(string codigo)
        {
            using (var context = new dbMediTrackEntities())
            {
                return context.Personal.FirstOrDefault(p => p.Codigo == codigo);
            }
        }

        public Personal BuscarPorUsuario(string usuario)
        {
            using (var context = new dbMediTrackEntities())
            {
                return context.Personal.FirstOrDefault(p => p.Usuario == usuario);
            }
        }

        public bool ExisteCodigo(string codigo, int idActual)
        {
            using (var context = new dbMediTrackEntities())
            {
                return context.Personal.Any(p => p.Id != idActual && p.Codigo == codigo);
            }
        }

        public bool ExisteUsuario(string usuario, int idActual)
        {
            using (var context = new dbMediTrackEntities())
            {
                return context.Personal.Any(p => p.Id != idActual && p.Usuario == usuario);
            }
        }

        public bool ExisteActivoEnArea(int idArea)
        {
            using (var context = new dbMediTrackEntities())
            {
                return context.Personal.Any(p => p.Activo && p.IdArea == idArea);
            }
        }

        public bool ExisteActivoEnTurno(int idTurno)
        {
            using (var context = new dbMediTrackEntities())
            {
                return context.Personal.Any(p => p.Activo && p.IdTurno == idTurno);
            }
        }

        public void Agregar(Personal personal)
        {
            using (var context = new dbMediTrackEntities())
            {
                context.Personal.Add(personal);
                context.SaveChanges();
            }
        }

        public void Actualizar(Personal personal)
        {
            using (var context = new dbMediTrackEntities())
            {
                Personal actual = context.Personal.FirstOrDefault(p => p.Id == personal.Id);
                if (actual == null)
                {
                    return;
                }

                actual.Codigo = personal.Codigo;
                actual.Nombres = personal.Nombres;
                actual.Apellidos = personal.Apellidos;
                actual.Usuario = personal.Usuario;
                if (!string.IsNullOrEmpty(personal.Password))
                {
                    actual.Password = personal.Password;
                }
                actual.Rol = personal.Rol;
                actual.IdArea = personal.IdArea;
                actual.IdTurno = personal.IdTurno;
                actual.Activo = personal.Activo;
                actual.FechaModificacion = personal.FechaModificacion;
                actual.ModificadoPor = personal.ModificadoPor;
                context.SaveChanges();
            }
        }
    }
}

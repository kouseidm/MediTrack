using System;
using MediTrack.Entities;

namespace MediTrack.Services
{
    public static class Sesion
    {
        public static Personal UsuarioActual { get; set; }

        public static void Iniciar(Personal p)
        {
            UsuarioActual = p;
        }

        public static void Cerrar()
        {
            UsuarioActual = null;
        }

        public static int IdPersonalActual
        {
            get { return UsuarioActual == null ? 0 : UsuarioActual.IdPersonal; }
        }

        public static string NombreUsuario()
        {
            return UsuarioActual == null ? "sistema" : UsuarioActual.Usuario;
        }

        public static bool EsAdmin()
        {
            return UsuarioActual != null && UsuarioActual.Rol == Roles.Administrador;
        }

        public static bool EsGestor()
        {
            return UsuarioActual != null &&
                   (UsuarioActual.Rol == Roles.Administrador || UsuarioActual.Rol == Roles.RecursosHumanos);
        }
    }
}

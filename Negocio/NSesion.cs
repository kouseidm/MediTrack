using System;
using System.Linq;
using Datos;

namespace Negocio
{
    public static class Roles
    {
        public const string Administrador = "Administrador";
        public const string RRHH = "RRHH";
        public const string Trabajador = "Trabajador";

        public static readonly string[] Todos = { Administrador, RRHH, Trabajador };
    }

    public static class NSesion
    {
        public static Personal UsuarioActual { get; private set; }

        public static int IdPersonalActual
        {
            get { return UsuarioActual == null ? 0 : UsuarioActual.Id; }
        }

        public static string NombreUsuario
        {
            get { return UsuarioActual == null ? "sistema" : UsuarioActual.Usuario; }
        }

        public static void Iniciar(Personal personal)
        {
            UsuarioActual = personal;
        }

        public static void Cerrar()
        {
            UsuarioActual = null;
        }

        public static bool EsGestor()
        {
            if (UsuarioActual == null)
            {
                return false;
            }
            return UsuarioActual.Rol == Roles.Administrador || UsuarioActual.Rol == Roles.RRHH;
        }
    }
}

using System;
using System.Security.Cryptography;
using System.Text;

namespace MediTrack.Services
{
    // Funciones para validacion 
    public static class Validador
    {
        public static bool TieneTexto(string texto)
        {
            return texto != null && texto.Trim() != "";
        }

        public static bool EsError(string mensaje)
        {
            return mensaje != null && mensaje.StartsWith("Error");
        }

        public static bool CodigoValido(string codigo)
        {
            if (!TieneTexto(codigo)) return false;

            codigo = codigo.Trim();
            if (codigo.Length < 4 || codigo.Length > 10) return false;

            foreach (char c in codigo)
            {
                if (!char.IsLetterOrDigit(c)) return false;
            }
            return true;
        }

        public static string CifrarClave(string clave)
        {
            SHA256 sha = SHA256.Create();
            byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(clave));
            return Convert.ToBase64String(bytes);
        }
    }
}

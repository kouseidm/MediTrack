using System;
using System.Security.Cryptography;

namespace Negocio
{
    public static class NServicioPassword
    {
        private const string Prefijo = "PBKDF2-SHA256";
        private const int Iteraciones = 100000;
        private const int BytesSal = 16;
        private const int BytesHash = 32;

        public static string CrearHash(string contrasena)
        {
            if (string.IsNullOrEmpty(contrasena))
                throw new ArgumentException("La contraseña no puede estar vacía.", "contrasena");

            byte[] sal = new byte[BytesSal];
            using (var generador = RandomNumberGenerator.Create())
            {
                generador.GetBytes(sal);
            }

            byte[] hash = CrearHashPBKDF2(contrasena, sal, Iteraciones);
            return string.Join("$", Prefijo, Iteraciones.ToString(),
                Convert.ToBase64String(sal), Convert.ToBase64String(hash));
        }

        public static bool Verificar(string contrasenaIngresada, string hashGuardadoTexto)
        {
            if (string.IsNullOrEmpty(contrasenaIngresada) || string.IsNullOrEmpty(hashGuardadoTexto))
                return false;

            string[] datosHash = hashGuardadoTexto.Split('$');
            if (datosHash.Length != 4 || !string.Equals(datosHash[0], Prefijo, StringComparison.Ordinal))
                return false;

            int iteraciones;
            byte[] sal;
            byte[] hashGuardado;
            try
            {
                iteraciones = int.Parse(datosHash[1]);
                sal = Convert.FromBase64String(datosHash[2]);
                hashGuardado = Convert.FromBase64String(datosHash[3]);
            }
            catch (FormatException)
            {
                return false;
            }
            catch (OverflowException)
            {
                return false;
            }

            if (iteraciones < 1 || sal.Length == 0 || hashGuardado.Length == 0)
                return false;

            byte[] hashIngresado = CrearHashPBKDF2(contrasenaIngresada, sal, iteraciones);
            return ComparacionTiempoConstante(hashGuardado, hashIngresado);
        }

        private static byte[] CrearHashPBKDF2(string contrasena, byte[] sal, int iteraciones)
        {
            using (var derivador = new Rfc2898DeriveBytes(
                contrasena, sal, iteraciones, HashAlgorithmName.SHA256))
            {
                return derivador.GetBytes(BytesHash);
            }
        }

        private static bool ComparacionTiempoConstante(byte[] hashGuardado, byte[] hashIngresado)
        {
            if (hashGuardado == null || hashIngresado == null || hashGuardado.Length != hashIngresado.Length)
                return false;

            int diferencia = 0;
            for (int i = 0; i < hashGuardado.Length; i++)
                diferencia |= hashGuardado[i] ^ hashIngresado[i];

            return diferencia == 0;
        }
    }
}

using System;
using System.Collections.Generic;

namespace MediTrack.Services
{
    public static class Roles
    {
        public const string Administrador = "Administrador";
        public const string RecursosHumanos = "Recursos Humanos";
        public const string Personal = "Personal";

        public static List<string> Todos = new List<string> { Administrador, RecursosHumanos, Personal };
    }

    public static class Estados
    {
        public const string Programado = "Programado";
        public const string Presente = "Presente";
        public const string Tardanza = "Tardanza";
        public const string Falta = "Falta";
        public const string Justificado = "Justificado";
    }

    public static class EstadosJustificacion
    {
        public const string Pendiente = "Pendiente";
        public const string Aprobada = "Aprobada";
        public const string Rechazada = "Rechazada";
    }

    public class Opcion
    {
        public int Id { get; set; }
        public string Texto { get; set; }
    }

    public class ItemGrafico
    {
        public string Etiqueta { get; set; }
        public double Valor { get; set; }
    }
}

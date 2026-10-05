using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediTrack.Entities
{
    public class Personal
    {
        public int IdPersonal { get; set; }
        public int IdArea   { get; set; }
        public int IdTurno { get; set; }
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos   { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Rol {  get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion  { get; set; }
        public string CreadoPor {  get; set; }
        public string ModificadoPor { get; set; }

        // Nombre y apellido juntos 
        public string NombreCompleto
        {
            get { return Nombres + " " + Apellidos; }
        }
    }
}

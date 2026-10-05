using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediTrack.Entities
{
    public class Area
    {
        public int IdArea { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool   Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion   { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediTrack.Entities
{
    public class Turno
    {
        public int IdTurno { get; set; }
        public string Nombre { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public int ToleranciaMin { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }

        // Formato "07:00 - 15:00" 
        public string Horario
        {
            get { return HoraInicio.ToString("HH:mm") + " - " + HoraFin.ToString("HH:mm"); }
        }

        // Un turno nocturno termina al dia siguiente 
        public bool CruzaMedianoche
        {
            get { return HoraFin.TimeOfDay <= HoraInicio.TimeOfDay; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediTrack.Entities
{
    public class Justificacion
    {
        public int IdJustificacion {  get; set; }
        public int IdPersonal { get; set; }      
        public int IdAsistencia { get; set; }  
        public string Tipo { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaAusencia { get; set; }  
        public string Motivo { get; set; }
        public string Estado { get; set; }    
        public DateTime FechaCreacion {  get; set; }
        public DateTime FechaModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
    }
}

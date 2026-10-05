using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediTrack.Entities
{
    public class RegistroAsistencia
    {
        public int IdAsistencia { get; set; }
        public int IdPersonal {  set; get; }
        public DateTime InicioProgramado { get; set; }
        public DateTime FinProgramado { get; set; }
        public DateTime? HoraIngreso {  get; set; }
        public DateTime? HoraSalida { get; set; }
        public int MinutosTardanza { get; set; }
        public decimal HorasTrabajadas { get; set; }
        public string Estado {  get; set; }
        public DateTime FechaCreacion {  get; set; }
        public DateTime FechaModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
    }
}

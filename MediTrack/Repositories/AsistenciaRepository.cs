using System;
using MediTrack.Entities;

namespace MediTrack.Repositories
{
    public class AsistenciaRepository : RepositorioMemoria<RegistroAsistencia>, IAsistenciaRepository
    {
        public RegistroAsistencia BuscarPorId(int id)
        {
            return Buscar(x => x.IdAsistencia == id);
        }

        public RegistroAsistencia BuscarJornada(int idPersonal, DateTime fecha)
        {
            return Buscar(a => a.IdPersonal == idPersonal && a.InicioProgramado.Date == fecha.Date);
        }
    }
}

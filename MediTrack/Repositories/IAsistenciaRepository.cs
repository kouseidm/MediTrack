using System;
using MediTrack.Entities;

namespace MediTrack.Repositories
{
    public interface IAsistenciaRepository : IRepositorio<RegistroAsistencia>
    {
        RegistroAsistencia BuscarPorId(int id);
        RegistroAsistencia BuscarJornada(int idPersonal, DateTime fecha);
    }
}

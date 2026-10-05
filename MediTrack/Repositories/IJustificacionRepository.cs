using System;
using MediTrack.Entities;

namespace MediTrack.Repositories
{
    public interface IJustificacionRepository : IRepositorio<Justificacion>
    {
        Justificacion BuscarPorId(int id);

    }
}

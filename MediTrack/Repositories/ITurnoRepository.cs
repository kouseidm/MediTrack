using System;
using MediTrack.Entities;

namespace MediTrack.Repositories
{
    public interface ITurnoRepository : IRepositorio<Turno>
    {
        Turno BuscarPorId(int id);

    }
}

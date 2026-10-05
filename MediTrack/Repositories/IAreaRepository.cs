using System;
using MediTrack.Entities;

namespace MediTrack.Repositories
{
    public interface IAreaRepository : IRepositorio<Area>
    {
        Area BuscarPorId(int id);

    }
}

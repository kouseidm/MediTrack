using System;
using MediTrack.Entities;

namespace MediTrack.Repositories
{
    public class AreaRepository : RepositorioMemoria<Area>, IAreaRepository
    {
        public Area BuscarPorId(int id)
        {
            return Buscar(x => x.IdArea == id);
        }
    }
}

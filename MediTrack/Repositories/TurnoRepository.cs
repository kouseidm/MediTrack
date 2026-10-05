using System;
using MediTrack.Entities;

namespace MediTrack.Repositories
{
    public class TurnoRepository : RepositorioMemoria<Turno>, ITurnoRepository
    {
        public Turno BuscarPorId(int id)
        {
            return Buscar(x => x.IdTurno == id);
        }
    }
}

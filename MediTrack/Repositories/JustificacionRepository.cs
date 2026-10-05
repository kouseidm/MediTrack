using System;
using MediTrack.Entities;

namespace MediTrack.Repositories
{
    public class JustificacionRepository : RepositorioMemoria<Justificacion>, IJustificacionRepository
    {
        public Justificacion BuscarPorId(int id)
        {
            return Buscar(x => x.IdJustificacion == id);
        }
    }
}

using System;
using MediTrack.Entities;

namespace MediTrack.Repositories
{
    public interface IPersonalRepository : IRepositorio<Personal>
    {
        Personal BuscarPorId(int id);
        Personal BuscarPorCodigo(string codigo);
        Personal BuscarPorUsuario(string usuario);
    }
}

using System;
using MediTrack.Entities;

namespace MediTrack.Repositories
{
    public class PersonalRepository : RepositorioMemoria<Personal>, IPersonalRepository
    {
        public Personal BuscarPorId(int id)
        {
            return Buscar(x => x.IdPersonal == id);
        }

        public Personal BuscarPorCodigo(string codigo)
        {
            return Buscar(p => p.Codigo.ToLower() == codigo.Trim().ToLower());
        }

        public Personal BuscarPorUsuario(string usuario)
        {
            return Buscar(p => p.Usuario.ToLower() == usuario.Trim().ToLower());
        }
    }
}

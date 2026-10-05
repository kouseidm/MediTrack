using System;
using System.Collections.Generic;

namespace MediTrack.Repositories
{
    public interface IRepositorio<T> where T : class
    {
        List<T> ObtenerTodos();
        T Buscar(Predicate<T> condicion);
        bool Existe(Predicate<T> condicion);
        void Agregar(T entidad);
    }
}

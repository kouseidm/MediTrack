using System;
using System.Collections.Generic;

namespace MediTrack.Repositories
{
    public class RepositorioMemoria<T> : IRepositorio<T> where T : class
    {
        private static readonly List<T> datos = new List<T>();

        public List<T> ObtenerTodos()
        {
            return datos;
        }

        public T Buscar(Predicate<T> condicion)
        {
            return datos.Find(condicion);
        }

        public bool Existe(Predicate<T> condicion)
        {
            return datos.Exists(condicion);
        }

        public void Agregar(T entidad)
        {
            datos.Add(entidad);
        }
    }
}

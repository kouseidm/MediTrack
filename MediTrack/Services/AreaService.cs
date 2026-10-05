using System;
using System.Collections.Generic;
using MediTrack.Entities;
using MediTrack.Repositories;

namespace MediTrack.Services
{
    public class AreaService
    {
        private IAreaRepository repositorio = new AreaRepository();
        private static bool datosCargados = false;

        public AreaService()
        {
            if (!datosCargados)
            {
                datosCargados = true;
                CargarDatosIniciales();
            }
        }

        /* DATOS DECLAROS - PRUEBA */
        private void CargarDatosIniciales()
        {
            CrearInicial("Enfermeria", "Cuidado directo de los pacientes");
            CrearInicial("Emergencias", "Atención de urgencias las 24 horas");
            CrearInicial("Administración", "Gestion y apoyo administrativo");
        }

        private void CrearInicial(string nombre, string descripcion)
        {
            Area area = new Area();
            area.IdArea = NuevoId();
            area.Nombre = nombre;
            area.Descripcion = descripcion;
            area.Activo = true;
            area.FechaCreacion = DateTime.Now;
            area.FechaModificacion = DateTime.Now;
            area.CreadoPor = "admin";
            area.ModificadoPor = "admin";
            repositorio.Agregar(area);
        }

        // Genera un nuevoId (SUMA 1 AL ULTIMO)
        private int NuevoId()
        {
            int mayor = 0;
            foreach (Area area in repositorio.ObtenerTodos())
            {
                if (area.IdArea > mayor)
                {
                    mayor = area.IdArea;
                }
            }
            return mayor + 1;
        }

        // true si otra area (distinta de idActual) ya tiene ese nombre
        private bool NombreRepetido(string nombre, int idActual)
        {
            return repositorio.Existe(a => a.IdArea != idActual && a.Nombre.ToLower() == nombre.Trim().ToLower());
        }

        public string RegistrarArea(Area area)
        {
            if (!Validador.TieneTexto(area.Nombre))
                return "Error: El nombre del área es obligatorio.";
            if (NombreRepetido(area.Nombre, 0))
                return "Error: Ya existe un área con ese nombre.";

            area.IdArea = NuevoId();
            area.Nombre = area.Nombre.Trim();
            if (area.Descripcion == null)
            {
                area.Descripcion = "";
            }
            area.Activo = true;
            area.FechaCreacion = DateTime.Now;
            area.FechaModificacion = DateTime.Now;
            area.CreadoPor = Sesion.NombreUsuario();
            area.ModificadoPor = Sesion.NombreUsuario();
            repositorio.Agregar(area);

            return "Área registrada correctamente.";
        }

        public string ActualizarArea(Area datos)
        {
            Area area = BuscarPorId(datos.IdArea);
            if (area == null)
            {
                return "Error: El área no existe.";
            }
            if (!Validador.TieneTexto(datos.Nombre))
            {
                return "Error: El nombre del área es obligatorio.";
            }
            if (NombreRepetido(datos.Nombre, area.IdArea))
            {
                return "Error: Ya existe otra área con ese nombre.";
            }

            area.Nombre = datos.Nombre.Trim();
            area.Descripcion = datos.Descripcion == null ? "" : datos.Descripcion;
            area.FechaModificacion = DateTime.Now;
            area.ModificadoPor = Sesion.NombreUsuario();

            return "Área actualizada correctamente.";
        }

        public string DesactivarArea(int id)
        {
            Area area = BuscarPorId(id);
            if (area == null)
            { 
                return "Error: El área no existe.";
            }
            if (!area.Activo)
            { 
                return "Error: El área ya está inactiva.";
            }

            // Verificar que el area no tenga personal
            PersonalService personalService = new PersonalService();
            if (personalService.HayPersonalActivoEnArea(id))
            { 
                return "Error: El área tiene personal activo asignado.";
            }

            area.Activo = false;
            area.FechaModificacion = DateTime.Now;
            area.ModificadoPor = Sesion.NombreUsuario();

            return "Área desactivada correctamente.";
        }

        public List<Area> ListarArea()
        {
            return repositorio.ObtenerTodos();
        }

        public List<Area> ListarActivas()
        {
            List<Area> activas = new List<Area>();
            foreach (Area area in repositorio.ObtenerTodos())
            {
                if (area.Activo)
                {
                    activas.Add(area);
                }
            }
            return activas;
        }

        public Area BuscarPorId(int id)
        {
            return repositorio.BuscarPorId(id);
        }
    }
}

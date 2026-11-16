using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NArea
    {
        private DArea objDatos = new DArea();
        private DPersonal objDatosPersonal = new DPersonal();

        public List<Area> ObtenerTodos()
        {
            return objDatos.ObtenerTodos();
        }
        public Area BuscarPorId(int id)
        {
            return objDatos.BuscarPorId(id);
        }
        public string Registrar(Area area)
        {
            if (area.Nombre == "" || area.Nombre == null)
            {
                return "El nombre del área es obligatorio.";
            }
            if (area.Descripcion == "" || area.Descripcion == null)
            {
                return "La descripción del área es obligatoria.";
            }

            if (objDatos.Existe(area.Nombre, 0) == true)
            {
                return "Ya existe un área registrada con ese nombre.";
            }

            area.FechaCreacion = DateTime.Now;
            area.FechaModificacion = DateTime.Now;
            area.CreadoPor = NSesion.NombreUsuario;
            area.ModificadoPor = NSesion.NombreUsuario;
            area.Activo = true;

            objDatos.Agregar(area);
            return "";

        }

        public string Actualizar(Area area)
        {
            if (area.Nombre == "" || area.Nombre == null)
            {
                return "El nombre del área es obligatorio.";
            }
            if (area.Descripcion == "" || area.Descripcion == null)
            {
                return "La descripción del área es obligatoria.";
            }
            if (objDatos.Existe(area.Nombre, area.Id) == true)
            {
                return "Otro registro ya utiliza este nombre de área.";
            }
            area.FechaModificacion = DateTime.Now;
            area.ModificadoPor = NSesion.NombreUsuario;
            objDatos.Actualizar(area);
            return "";
        }

        public string Desactivar(int id)
        {
            Area area = objDatos.BuscarPorId(id);
            if (area == null)
            {
                return "No se encontró el área seleccionada.";
            }
            if (area.Activo == false)
            {
                return "El área ya está desactivada.";
            }
            if (objDatosPersonal.ExisteActivoEnArea(id) == true)
            {
                return "No se puede desactivar: hay personal activo asignado a esta área.";
            }
            area.Activo = false;
            area.FechaModificacion = DateTime.Now;
            area.ModificadoPor = NSesion.NombreUsuario;
            objDatos.Actualizar(area);
            return "";
        }

        public string Activar(int id)
        {
            Area area = objDatos.BuscarPorId(id);
            if (area == null)
            {
                return "No se encontró el área seleccionada.";
            }
            if (area.Activo == true)
            {
                return "El área ya está activa.";
            }
            area.Activo = true;
            area.FechaModificacion = DateTime.Now;
            area.ModificadoPor = NSesion.NombreUsuario;
            objDatos.Actualizar(area);
            return "";
        }
    }
}

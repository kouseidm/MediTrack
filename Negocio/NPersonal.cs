using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NPersonal
    {
        private DPersonal objDatos = new DPersonal();
        public List<Personal> ObtenerTodos()
        {
            return objDatos.ObtenerTodos();
        }

        
        public Personal BuscarPorId(int id)
        {
            return objDatos.BuscarPorId(id);
        }
        public List<Personal> Buscar(string texto)
        {
            if (texto == null)
            {
                texto = "";
            }
            texto = texto.Trim().ToLower();
            return objDatos.ObtenerTodos().Where(p => p.Codigo.ToLower().Contains(texto)|| p.Nombres.ToLower().Contains(texto)|| p.Apellidos.ToLower().Contains(texto)|| p.Usuario.ToLower().Contains(texto)).ToList();
        }
        public Personal ValidarLogin(string usuario, string clave)
        {
            Personal trabajador = objDatos.Buscar(usuario);
            if (trabajador == null)
                return null;

            bool claveCorrecta = NServicioPassword.Verificar(clave, trabajador.Password);
            return claveCorrecta ? trabajador : null;
        }

        public string Registrar(Personal personal)
        {
            if (personal.Codigo == "" || personal.Codigo == null)
            {
                return "El código del trabajador es obligatorio.";
            }
            if (personal.Nombres == "" || personal.Nombres == null)
            {
                return "Los nombres son obligatorios.";
            }
            if (personal.Apellidos == "" || personal.Apellidos == null)
            {
                return "Los apellidos son obligatorios.";
            }
            if (personal.Usuario == "" || personal.Usuario == null)
            {
                return "El nombre de usuario es obligatorio.";
            }
            if (personal.Password == "" || personal.Password == null)
            {
                return "La contraseña es obligatoria.";
            }
            if (personal.Password.Length < 8)
            {
                return "La contraseña debe tener al menos 8 caracteres.";
            }
            if (personal.Rol == "" || personal.Rol == null)
            {
                return "Debe seleccionar un rol para el trabajador.";
            }
            if (personal.IdArea <= 0)
            {
                return "Debe asignar un área al trabajador.";
            }
            if (personal.IdTurno <= 0)
            {
                return "Debe asignar un turno al trabajador.";
            }
            if (objDatos.ExisteCodigo(personal.Codigo, 0) == true)
            {
                return "Ya existe un trabajador registrado con ese código.";
            }
            if (objDatos.ExisteUsuario(personal.Usuario, 0) == true)
            {
                return "Ese nombre de usuario ya está en uso. Elija otro.";
            }
            personal.FechaCreacion = DateTime.Now;
            personal.FechaModificacion = DateTime.Now;
            personal.CreadoPor = NSesion.NombreUsuario;
            personal.ModificadoPor = NSesion.NombreUsuario;
            personal.Activo = true;
            personal.Password = NServicioPassword.CrearHash(personal.Password);

            objDatos.Agregar(personal);
            return "";
        }
        public string Actualizar(Personal personal)
        {
            if (personal.Codigo == "" || personal.Codigo == null)
            {
                return "El código del trabajador es obligatorio.";
            }

            if (personal.Nombres == "" || personal.Nombres == null)
            {
                return "Los nombres son obligatorios.";
            }

            if (personal.Apellidos == "" || personal.Apellidos == null)
            {
                return "Los apellidos son obligatorios.";
            }

            if (personal.Usuario == "" || personal.Usuario == null)
            {
                return "El nombre de usuario es obligatorio.";
            }

            if (personal.IdArea <= 0)
            {
                return "Debe asignar un área al trabajador.";
            }

            if (personal.IdTurno <= 0)
            {
                return "Debe asignar un turno al trabajador.";
            }

            if (objDatos.ExisteCodigo(personal.Codigo, personal.Id) == true)
            {
                return "Otro trabajador ya utiliza este código.";
            }

            if (objDatos.ExisteUsuario(personal.Usuario, personal.Id) == true)
            {
                return "Ese nombre de usuario ya está siendo usado por otra persona.";
            }

            if (!string.IsNullOrEmpty(personal.Password) && personal.Password.Length < 8)
            {
                return "La contraseña debe tener al menos 8 caracteres.";
            }

            personal.FechaModificacion = DateTime.Now;
            personal.ModificadoPor = NSesion.NombreUsuario;

            if (!string.IsNullOrEmpty(personal.Password))
                personal.Password = NServicioPassword.CrearHash(personal.Password);

            objDatos.Actualizar(personal);

            return "";
        }

        public string Desactivar(int id)
        {
            Personal personal = objDatos.BuscarPorId(id);
            if (personal == null)
            {
                return "No se encontró al trabajador seleccionado.";
            }
            if (personal.Activo == false)
            {
                return "El trabajador ya está desactivado.";
            }
            if (id == NSesion.IdPersonalActual)
            {
                return "No puede desactivar su propio usuario.";
            }
            personal.Activo = false;
            personal.FechaModificacion = DateTime.Now;
            personal.ModificadoPor = NSesion.NombreUsuario;
            objDatos.Actualizar(personal);
            return "";
        }

        public string Activar(int id)
        {
            Personal personal = objDatos.BuscarPorId(id);
            if (personal == null)
            {
                return "No se encontró al trabajador seleccionado.";
            }
            if (personal.Activo == true)
            {
                return "El trabajador ya está activo.";
            }

            Area area = new DArea().BuscarPorId(personal.IdArea);
            if (area == null || area.Activo == false)
            {
                return "No se puede activar: el área del trabajador está inactiva.";
            }
            Turno turno = new DTurno().BuscarPorId(personal.IdTurno);
            if (turno == null || turno.Activo == false)
            {
                return "No se puede activar: el turno del trabajador está inactivo.";
            }

            personal.Activo = true;
            personal.FechaModificacion = DateTime.Now;
            personal.ModificadoPor = NSesion.NombreUsuario;
            objDatos.Actualizar(personal);
            return "";
        }

    }
}

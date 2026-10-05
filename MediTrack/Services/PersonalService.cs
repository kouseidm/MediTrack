using System;
using System.Collections.Generic;
using MediTrack.Entities;
using MediTrack.Repositories;

namespace MediTrack.Services
{
    public class PersonalService
    {
        private IPersonalRepository repositorio = new PersonalRepository();
        private static bool datosCargados = false;

        public PersonalService()
        {
            if (!datosCargados)
            {
                datosCargados = true;
                CargarDatosIniciales();
            }
        }

        // Usuarios de prueba 
        private void CargarDatosIniciales()
        {
            CrearInicial("ADM001", "Admin", "MediTrack", "admin", "admin123", Roles.Administrador, 3, 1);
            CrearInicial("RRH001", "RRHH", "MediTrack", "rrhh", "rrhh123", Roles.RecursosHumanos, 3, 1);
            CrearInicial("ENF001", "Lucía", "Vega", "lvega", "enf123", Roles.Personal, 1, 1);
            CrearInicial("EME001", "Carlos", "Rojas", "crojas", "eme123", Roles.Personal, 2, 2);
        }

        private void CrearInicial(string codigo, string nombres, string apellidos, string usuario,
                                  string clave, string rol, int idArea, int idTurno)
        {
            Personal p = new Personal();
            p.IdPersonal = NuevoId();
            p.Codigo = codigo;
            p.Nombres = nombres;
            p.Apellidos = apellidos;
            p.Usuario = usuario;
            p.Password = Validador.CifrarClave(clave);
            p.Rol = rol;
            p.IdArea = idArea;
            p.IdTurno = idTurno;
            p.Activo = true;
            p.FechaCreacion = DateTime.Now;
            p.FechaModificacion = DateTime.Now;
            p.CreadoPor = "sistema";
            p.ModificadoPor = "sistema";
            repositorio.Agregar(p);
        }

        private int NuevoId()
        {
            int mayor = 0;
            foreach (Personal p in repositorio.ObtenerTodos())
            {
                if (p.IdPersonal > mayor)
                {
                    mayor = p.IdPersonal;
                }
            }
            return mayor + 1;
        }

        private string ValidarDatos(Personal datos, int idActual)
        {
            if (!Validador.CodigoValido(datos.Codigo))
            {
                return "Error: El código debe tener de 4 a 10 letras o números.";
            }
            if (!Validador.TieneTexto(datos.Nombres) || !Validador.TieneTexto(datos.Apellidos))
            { 
                return "Error: Los nombres y apellidos son obligatorios.";
            }
            if (!Validador.TieneTexto(datos.Usuario))
            { 
                return "Error: El usuario es obligatorio.";
            }
            if (!Roles.Todos.Contains(datos.Rol))
            { 
                return "Error: Seleccione un rol válido.";
            }

            // VALIDACION DE QUE NO SE PUEDE REPETIR
            if (repositorio.Existe(p => p.IdPersonal != idActual && p.Codigo.ToLower() == datos.Codigo.Trim().ToLower()))
            { 
                return "Error: Ya existe un trabajador con ese código.";
            }
            if (repositorio.Existe(p => p.IdPersonal != idActual && p.Usuario.ToLower() == datos.Usuario.Trim().ToLower()))
            { 
                return "Error: Ya existe un trabajador con ese usuario.";
            }

            // AREA Y TURNO ACTIVOS
            AreaService areaService = new AreaService();
            Area area = areaService.BuscarPorId(datos.IdArea);
            if (area == null || !area.Activo)
            { 
                return "Error: Seleccione un área activa.";
            }

            TurnoService turnoService = new TurnoService();
            Turno turno = turnoService.BuscarPorId(datos.IdTurno);
            if (turno == null || !turno.Activo)
            { 
                return "Error: Seleccione un turno activo.";
            }

            return "";
        }

        public string RegistrarPersonal(Personal personal, string clave)
        {
            string error = ValidarDatos(personal, 0);
            if (error != "")
            {
                return error;
            }
            if (clave == null || clave.Length < 6)
            {
                return "Error: La contraseña debe tener al menos 6 caracteres.";
            }
            personal.IdPersonal = NuevoId();
            personal.Codigo = personal.Codigo.Trim();
            personal.Nombres = personal.Nombres.Trim();
            personal.Apellidos = personal.Apellidos.Trim();
            personal.Usuario = personal.Usuario.Trim();
            personal.Password = Validador.CifrarClave(clave);
            personal.Activo = true;
            personal.FechaCreacion = DateTime.Now;
            personal.FechaModificacion = DateTime.Now;
            personal.CreadoPor = Sesion.NombreUsuario();
            personal.ModificadoPor = Sesion.NombreUsuario();
            repositorio.Agregar(personal);

            return "Trabajador registrado correctamente.";
        }

        public string ModificarPersonal(Personal datos)
        {
            Personal p = BuscarPorId(datos.IdPersonal);
            if (p == null)
            { 
                return "Error: El trabajador no existe.";
            }

            string error = ValidarDatos(datos, p.IdPersonal);
            if (error != "")
            {
                return error;
            }

            p.Codigo = datos.Codigo.Trim();
            p.Nombres = datos.Nombres.Trim();
            p.Apellidos = datos.Apellidos.Trim();
            p.Usuario = datos.Usuario.Trim();
            p.Rol = datos.Rol;
            p.IdArea = datos.IdArea;
            p.IdTurno = datos.IdTurno;
            p.FechaModificacion = DateTime.Now;
            p.ModificadoPor = Sesion.NombreUsuario();

            return "Datos del trabajador actualizados.";
        }

        public string DesactivarPersonal(int id)
        {
            Personal p = BuscarPorId(id);
            if (p == null)
            { 
                return "Error: El trabajador no existe.";
            }
            if (!p.Activo)
            {
                return "Error: El trabajador ya está inactivo.";
            }
            if (id == Sesion.IdPersonalActual)
            { 
                return "Error: No puede desactivar su propia cuenta.";
            }

            p.Activo = false;
            p.FechaModificacion = DateTime.Now;
            p.ModificadoPor = Sesion.NombreUsuario();

            return "Trabajador desactivado correctamente.";
        }

        public List<Personal> BuscarPersonal(string texto)
        {
            if (!Validador.TieneTexto(texto))
            {
                return ListarTodo();
            }

            string buscado = texto.Trim().ToLower();
            List<Personal> encontrados = new List<Personal>();

            foreach (Personal p in repositorio.ObtenerTodos())
            {
                if (p.Codigo.ToLower().Contains(buscado) ||
                    p.NombreCompleto.ToLower().Contains(buscado) ||
                    p.Usuario.ToLower().Contains(buscado))
                {
                    encontrados.Add(p);
                }
            }
            return encontrados;
        }

        public string AsignarTurno(int idPersonal, int idTurno)
        {
            Personal p = BuscarPorId(idPersonal);
            if (p == null)
            { 
                return "Error: El trabajador no existe.";
            }

            TurnoService turnoService = new TurnoService();
            Turno turno = turnoService.BuscarPorId(idTurno);
            if (turno == null || !turno.Activo)
            { 
                return "Error: Seleccione un turno activo.";
            }

            p.IdTurno = idTurno;
            p.FechaModificacion = DateTime.Now;
            p.ModificadoPor = Sesion.NombreUsuario();

            return "Turno asignado: " + turno.Nombre + " (" + turno.Horario + ").";
        }

        public Personal IniciarSesion(string usuario, string clave)
        {
            string claveCifrada = Validador.CifrarClave(clave);
            return repositorio.Buscar(p => p.Usuario.ToLower() == usuario.Trim().ToLower()
                                         && p.Password == claveCifrada
                                         && p.Activo);
        }

        public string CambiarPassword(string usuario, string nuevoPassword)
        {
            Personal p = repositorio.Buscar(x => x.Usuario.ToLower() == usuario.ToLower());
            if (p == null)
            { 
                return "Error: El usuario no existe.";
            }
            if (nuevoPassword == null || nuevoPassword.Length < 6)
            {
                return "Error: La contraseña debe tener al menos 6 caracteres.";
            }

            p.Password = Validador.CifrarClave(nuevoPassword);
            p.FechaModificacion = DateTime.Now;
            p.ModificadoPor = Sesion.NombreUsuario();

            return "Contraseña cambiada correctamente.";
        }

        public List<Personal> ListarTodo()
        {
            return repositorio.ObtenerTodos();
        }

        public List<Personal> ListarActivos()
        {
            List<Personal> activos = new List<Personal>();
            foreach (Personal p in repositorio.ObtenerTodos())
            {
                if (p.Activo)
                {
                    activos.Add(p);
                }
            }
            return activos;
        }

        public Personal BuscarPorId(int id)
        {
            return repositorio.BuscarPorId(id);
        }

        public Personal BuscarPorCodigo(string codigo)
        {
            if (!Validador.TieneTexto(codigo))
            {
                return null;
            }
            return repositorio.BuscarPorCodigo(codigo);
        }

        public bool HayPersonalActivoEnArea(int idArea)
        {
            return repositorio.Existe(p => p.Activo && p.IdArea == idArea);
        }

        public bool HayPersonalActivoEnTurno(int idTurno)
        {
            return repositorio.Existe(p => p.Activo && p.IdTurno == idTurno);
        }
    }
}

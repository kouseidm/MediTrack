using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormPersonal : Form
    {
        private NPersonal negPersonal = new NPersonal();
        private NArea negArea = new NArea();
        private NTurno negTurno = new NTurno();
        private ErrorProvider errores = new ErrorProvider();

        public FormPersonal()
        {
            InitializeComponent();
            CargarCombos();
            CargarGrid(negPersonal.ObtenerTodos());
        }

        private void CargarCombos()
        {
            UI.CargarCombo(cmbArea, negArea.ObtenerTodos().Where(a => a.Activo)
                                           .Select(a => new Opcion { Id = a.Id, Texto = a.Nombre }).ToList());
            UI.CargarCombo(cmbTurno, negTurno.ObtenerTodos().Where(t => t.Activo)
                                             .Select(t => new Opcion { Id = t.Id, Texto = t.Nombre + " (" + UI.Horario(t) + ")" }).ToList());
            cmbRol.DataSource = negPersonal.ObtenerTodos().Select(p => p.Rol).Distinct().ToList();
            cmbRol.SelectedItem = null;

        }

        private void CargarGrid(List<Personal> lista)
        {
            List<Area> areas = negArea.ObtenerTodos();
            List<Turno> turnos = negTurno.ObtenerTodos();

            grid.DataSource = lista.Select(p => new
            {
                Id = p.Id,
                Codigo = p.Codigo,
                Nombre = UI.NombreCompleto(p),
                Usuario = p.Usuario,
                Rol = p.Rol,
                Area = areas.Find(a => a.Id == p.IdArea)?.Nombre,
                Turno = turnos.Find(t => t.Id == p.IdTurno)?.Nombre,
                Activo = p.Activo ? "Sí" : "No"
            }).ToList();
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            Personal p = negPersonal.BuscarPorId(UI.IdFilaSeleccionada(grid));
            MostrarAuditoria(p);
            if (p == null) return;

            txtCodigo.Text = p.Codigo;
            txtNombres.Text = p.Nombres;
            txtApellidos.Text = p.Apellidos;
            txtUsuario.Text = p.Usuario;
            txtClave.Clear();
            cmbRol.SelectedItem = p.Rol;
            cmbArea.SelectedValue = p.IdArea;
            cmbTurno.SelectedValue = p.IdTurno;
        }

        private void MostrarAuditoria(Personal x)
        {
            if (x == null)
            {
                lblCreadoPor.Text = "-";
                lblCreadoEl.Text = "-";
                lblActualizadoPor.Text = "-";
                lblActualizadoEl.Text = "-";
            }
            else
            {
                lblCreadoPor.Text = x.CreadoPor;
                lblCreadoEl.Text = UI.FechaHora(x.FechaCreacion);
                lblActualizadoPor.Text = x.ModificadoPor;
                lblActualizadoEl.Text = UI.FechaHora(x.FechaModificacion);
            }
        }

        private bool Requerido(TextBox t)
        {
            if (!Validador.TieneTexto(t.Text))
            {
                errores.SetError(t, "Campo obligatorio");
                return false;
            }
            errores.SetError(t, "");
            return true;
        }

        private void Limpiar()
        {
            txtCodigo.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtUsuario.Clear();
            txtClave.Clear();
            errores.Clear();
        }

        private void LeerFormulario(Personal p)
        {
            p.Codigo = txtCodigo.Text.Trim();
            p.Nombres = txtNombres.Text.Trim();
            p.Apellidos = txtApellidos.Text.Trim();
            p.Usuario = txtUsuario.Text.Trim();
            p.Rol = cmbRol.SelectedItem == null ? "" : cmbRol.SelectedItem.ToString();
            p.IdArea = UI.IdElegido(cmbArea);
            p.IdTurno = UI.IdElegido(cmbTurno);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!Requerido(txtCodigo))
                return;

            if (!Requerido(txtNombres))
                return;

            if (!Requerido(txtApellidos))
                return;

            if (!Requerido(txtUsuario))
                return;

            if (!Requerido(txtClave))
                return;

            Personal p = new Personal();
            LeerFormulario(p);
            p.Password = txtClave.Text;

            if (UI.Resultado(negPersonal.Registrar(p), "Trabajador registrado correctamente."))
            {
                CargarGrid(negPersonal.ObtenerTodos());
                Limpiar();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int id = UI.IdFilaSeleccionada(grid);
            if (id == 0)
            {
                UI.Aviso("Seleccione un trabajador de la tabla.");
                return;
            }
            bool a = Requerido(txtNombres), b = Requerido(txtApellidos);
            if (!(a && b)) return;

            Personal p = negPersonal.BuscarPorId(id);
            if (p == null)
            {
                UI.Aviso("No se encontró al trabajador seleccionado.");
                return;
            }
            LeerFormulario(p);

            if (Validador.TieneTexto(txtClave.Text))
            {
                p.Password = txtClave.Text;
            }

            if (UI.Resultado(negPersonal.Actualizar(p), "Trabajador actualizado correctamente."))
            {
                txtClave.Clear();
                CargarGrid(negPersonal.ObtenerTodos());
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            int id = UI.IdFilaSeleccionada(grid);
            if (id == 0)
            {
                UI.Aviso("Seleccione un trabajador de la tabla.");
                return;
            }

            if (MessageBox.Show("¿Desactivar al trabajador seleccionado?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (UI.Resultado(negPersonal.Desactivar(id), "Trabajador desactivado correctamente."))
                {
                    CargarGrid(negPersonal.ObtenerTodos());
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Personal> res = negPersonal.Buscar(txtBuscar.Text);
            if (res.Count == 0)
                MessageBox.Show("No se encontraron resultados.");
            CargarGrid(res);
        }

        private void btnVerTodos_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarGrid(negPersonal.ObtenerTodos());
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            int id = UI.IdFilaSeleccionada(grid);
            if (id == 0)
            {
                UI.Aviso("Seleccione un trabajador de la tabla.");
                return;
            }
            if (UI.Resultado(negPersonal.Activar(id), "Trabajador activado correctamente."))
            {
                CargarGrid(negPersonal.ObtenerTodos());
            }
        }

        private void FiltrarPorEstado(bool? activo)
        {
            txtBuscar.Clear();
            List<Personal> lista = negPersonal.ObtenerTodos();

            if (activo != null)
                lista = lista.Where(p => p.Activo == activo.Value).ToList();

            if (lista.Count == 0)
                MessageBox.Show("No hay trabajadores en esta categoría.");

            CargarGrid(lista);
        }

        private void btnActivos_Click(object sender, EventArgs e)
        {
            FiltrarPorEstado(true);
        }

        private void btnDesactivados_Click(object sender, EventArgs e)
        {
            FiltrarPorEstado(false);
        }

        private void btnVerTodo_Click(object sender, EventArgs e)
        {
            FiltrarPorEstado(null);
        }
    }
}

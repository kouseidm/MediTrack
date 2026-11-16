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
    public partial class FormArea : Form
    {

        private NArea negArea = new NArea();
        private ErrorProvider errores = new ErrorProvider();

        private bool? filtroActiva = null;

        public FormArea()
        {
            InitializeComponent();
            CargarGrid();
        }

        private void CargarGrid()
        {
            List<Area> lista = negArea.ObtenerTodos();

            if (filtroActiva != null)
                lista = lista.Where(a => a.Activo == filtroActiva.Value).ToList();

            grid.DataSource = lista.Select(a => new
            {
                Id = a.Id,
                Nombre = a.Nombre,
                Descripcion = a.Descripcion,
                Estado = a.Activo ? "Activa" : "Inactiva"
            }).ToList();
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            Area a = negArea.BuscarPorId(UI.IdFilaSeleccionada(grid));
            MostrarAuditoria(a);
            if (a == null)
            {
                return;
            }
            txtNombre.Text = a.Nombre;
            txtDescripcion.Text = a.Descripcion;
        }

        private void MostrarAuditoria(Area x)
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

        private bool NombreOk()
        {
            if (!Validador.TieneTexto(txtNombre.Text))
            {
                errores.SetError(txtNombre, "Campo obligatorio");
                return false;
            }
            errores.SetError(txtNombre, "");
            return true;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!NombreOk())
            {
                return;
            }
            Area area = new Area();
            area.Nombre = txtNombre.Text.Trim();
            area.Descripcion = txtDescripcion.Text.Trim();

            if (UI.Resultado(negArea.Registrar(area), "Área registrada correctamente."))
            {
                CargarGrid();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int id = UI.IdFilaSeleccionada(grid);
            if (id == 0)
            {
                UI.Aviso("Seleccione un área de la tabla.");
                return;
            }
            if (!NombreOk())
            {
                return;
            }

            Area area = negArea.BuscarPorId(id);
            if (area == null)
            {
                UI.Aviso("No se encontró el área seleccionada.");
                return;
            }
            area.Nombre = txtNombre.Text.Trim();
            area.Descripcion = txtDescripcion.Text.Trim();

            if (UI.Resultado(negArea.Actualizar(area), "Área actualizada correctamente."))
            {
                CargarGrid();
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            int id = UI.IdFilaSeleccionada(grid);
            if (id == 0)
            {
                UI.Aviso("Seleccione un área de la tabla.");
                return;
            }
            if (UI.Resultado(negArea.Desactivar(id), "Área desactivada correctamente."))
            {
                CargarGrid();
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            int id = UI.IdFilaSeleccionada(grid);
            if (id == 0)
            {
                UI.Aviso("Seleccione un área de la tabla.");
                return;
            }
            if (UI.Resultado(negArea.Activar(id), "Área activada correctamente."))
            {
                CargarGrid();
            }
        }

        private void FiltrarPorEstado(bool? activa)
        {
            filtroActiva = activa;
            CargarGrid();

            if (grid.Rows.Count == 0)
                MessageBox.Show("No hay áreas en esta categoría.");
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

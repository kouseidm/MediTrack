using System;
using System.Linq;
using System.Windows.Forms;
using MediTrack.Entities;
using MediTrack.Services;

namespace MediTrack.Forms
{
    // Gestion de areas (solo Administrador)
    public partial class FormAreas : Form
    {
        private AreaService areaService = new AreaService();

        public FormAreas()
        {
            InitializeComponent();
            CargarGrid();
        }

        private void CargarGrid()
        {
            grid.DataSource = areaService.ListarArea().Select(a => new
            {
                Id = a.IdArea, Nombre = a.Nombre, Descripcion = a.Descripcion,
                Estado = a.Activo ? "Activa" : "Inactiva"
            }).ToList();
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            Area a = areaService.ListarArea().Find(x => x.IdArea == UI.IdFilaSeleccionada(grid));
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

        private void Resultado(string msg)
        {
            UI.Mostrar(msg);
            if (!Validador.EsError(msg))
            {
                CargarGrid();
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!NombreOk())
            {
                return;
            }
            Area area = new Area();
            area.Nombre = txtNombre.Text;
            area.Descripcion = txtDescripcion.Text;

            Resultado(areaService.RegistrarArea(area));
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int id = UI.IdFilaSeleccionada(grid);

            if (id == 0 || !NombreOk())
            {
                return;
            }

            Area area = new Area();
            area.IdArea = id;
            area.Nombre = txtNombre.Text;
            area.Descripcion = txtDescripcion.Text;

            Resultado(areaService.ActualizarArea(area));
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            int id = UI.IdFilaSeleccionada(grid);
            if (id == 0) 
            { 
                UI.Mostrar("Error: Seleccione un área de la tabla.");
                return; 
            }
            Resultado(areaService.DesactivarArea(id));
        }
    }
}

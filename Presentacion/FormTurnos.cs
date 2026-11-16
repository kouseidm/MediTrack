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
    public partial class FormTurnos : Form
    {
        private NTurno negTurno = new NTurno();
        private ErrorProvider errores = new ErrorProvider();

        private bool? filtroActivo = null;

        public FormTurnos()
        {
            InitializeComponent();

            numTolerancia.Value = 10;
            dtpInicio.Value = DateTime.Today.AddHours(7);
            dtpFin.Value = DateTime.Today.AddHours(15);

            CargarGrid();
        }

        private void CargarGrid()
        {
            List<Turno> lista = negTurno.ObtenerTodos();

            if (filtroActivo != null)
                lista = lista.Where(t => t.Activo == filtroActivo.Value).ToList();

            grid.DataSource = lista.Select(t => new
            {
                Id = t.Id,
                Nombre = t.Nombre,
                Horario = UI.Horario(t),
                Tolerancia = t.ToleranciaMin,
                Nocturno = t.HoraFin.TimeOfDay <= t.HoraInicio.TimeOfDay ? "Sí" : "No",
                Estado = t.Activo ? "Activo" : "Inactivo"
            }).ToList();
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            Turno t = negTurno.BuscarPorId(UI.IdFilaSeleccionada(grid));
            MostrarAuditoria(t);
            if (t == null) return;
            txtNombre.Text = t.Nombre;
            dtpInicio.Value = DateTime.Today.Add(t.HoraInicio.TimeOfDay);
            dtpFin.Value = DateTime.Today.Add(t.HoraFin.TimeOfDay);
            numTolerancia.Value = t.ToleranciaMin;
            txtDescripcion.Text = t.Descripcion;
        }

        private void MostrarAuditoria(Turno x)
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

        private void LeerFormulario(Turno turno)
        {
            turno.Nombre = txtNombre.Text.Trim();
            turno.HoraInicio = UI.SoloHora(dtpInicio.Value);
            turno.HoraFin = UI.SoloHora(dtpFin.Value);
            turno.ToleranciaMin = (int)numTolerancia.Value;
            turno.Descripcion = txtDescripcion.Text.Trim();
        }

        private bool NombreOk()
        {
            if (!Validador.TieneTexto(txtNombre.Text))
            {
                errores.SetError(txtNombre, "Campo obligatorio"); return false;
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
            Turno turno = new Turno();
            LeerFormulario(turno);

            if (UI.Resultado(negTurno.Registrar(turno), "Turno registrado correctamente."))
            {
                CargarGrid();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int id = UI.IdFilaSeleccionada(grid);
            if (id == 0)
            {
                UI.Aviso("Seleccione un turno de la tabla.");
                return;
            }
            if (!NombreOk())
            {
                return;
            }

            Turno turno = negTurno.BuscarPorId(id);
            if (turno == null)
            {
                UI.Aviso("No se encontró el turno seleccionado.");
                return;
            }
            LeerFormulario(turno);

            if (UI.Resultado(negTurno.Actualizar(turno), "Turno actualizado correctamente."))
            {
                CargarGrid();
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            int id = UI.IdFilaSeleccionada(grid);
            if (id == 0)
            {
                UI.Aviso("Seleccione un turno de la tabla.");
                return;
            }
            if (UI.Resultado(negTurno.Desactivar(id), "Turno desactivado correctamente."))
            {
                CargarGrid();
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            int id = UI.IdFilaSeleccionada(grid);
            if (id == 0)
            {
                UI.Aviso("Seleccione un turno de la tabla.");
                return;
            }
            if (UI.Resultado(negTurno.Activar(id), "Turno activado correctamente."))
            {
                CargarGrid();
            }
        }

        private void FiltrarPorEstado(bool? activo)
        {
            filtroActivo = activo;
            CargarGrid();

            if (grid.Rows.Count == 0)
                MessageBox.Show("No hay turnos en esta categoría.");
        }

        private void btnVerTodo_Click(object sender, EventArgs e)
        {
            FiltrarPorEstado(null);
        }

        private void btnDesactivados_Click(object sender, EventArgs e)
        {
            FiltrarPorEstado(false);
        }

        private void btnActivos_Click(object sender, EventArgs e)
        {
            FiltrarPorEstado(true);
        }
    }
}

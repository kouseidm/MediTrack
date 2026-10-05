using System;
using System.Linq;
using System.Windows.Forms;
using MediTrack.Entities;
using MediTrack.Services;

namespace MediTrack.Forms
{
    public partial class FormTurnos : Form
    {
        private TurnoService turnoService = new TurnoService();

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
            grid.DataSource = turnoService.ListarTurnos().Select(t => new
            {
                Id = t.IdTurno, Nombre = t.Nombre, Horario = t.Horario,
                Tolerancia = t.ToleranciaMin, Nocturno = t.CruzaMedianoche ? "Sí" : "No",
                Estado = t.Activo ? "Activo" : "Inactivo"
            }).ToList();
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            Turno t = turnoService.ListarTurnos().Find(x => x.IdTurno == UI.IdFilaSeleccionada(grid));
            MostrarAuditoria(t);
            if (t == null) return;
            txtNombre.Text = t.Nombre;
            dtpInicio.Value = t.HoraInicio;
            dtpFin.Value = t.HoraFin;
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

        private Turno LeerFormulario(int id)
        {
            return new Turno
            {
                IdTurno = id,
                Nombre = txtNombre.Text,
                HoraInicio = dtpInicio.Value,
                HoraFin = dtpFin.Value,
                ToleranciaMin = (int)numTolerancia.Value,
                Descripcion = txtDescripcion.Text
            };
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
            if (NombreOk())
            {
                Resultado(turnoService.RegistrarTurno(LeerFormulario(0)));
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int id = UI.IdFilaSeleccionada(grid);
            if (id == 0) 
            { 
                UI.Mostrar("Error: Seleccione un turno de la tabla."); return; 
            }
            if (NombreOk())
                Resultado(turnoService.ActualizarTurno(LeerFormulario(id)));
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            int id = UI.IdFilaSeleccionada(grid);
            if (id == 0) 
            { 
                UI.Mostrar("Error: Seleccione un turno de la tabla.");
                return; 
            }
            Resultado(turnoService.DesactivarTurno(id));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MediTrack.Entities;
using MediTrack.Services;

namespace MediTrack.Forms
{
    public partial class FormJustificaciones : Form
    {
        private PersonalService personalService = new PersonalService();
        private JustificacionService justificacionService = new JustificacionService();

        public FormJustificaciones()
        {
            InitializeComponent();

            cmbTipo.DataSource = JustificacionService.Tipos.ToList();
            cmbFiltro.DataSource = new List<string> { "Todos", "Pendiente", "Aprobada", "Rechazada" };

            // Solo Administrador y RRHH aprueban o rechazan
            btnAprobar.Visible = Sesion.EsGestor();
            btnRechazar.Visible = Sesion.EsGestor();

            CargarPersonal();
            CargarGrid();
        }

        private void CargarPersonal()
        {
            List<Personal> lista = personalService.ListarActivos();

     
            if (!Sesion.EsGestor())
                lista = lista.Where(p => p.IdPersonal == Sesion.IdPersonalActual).ToList();

            UI.CargarCombo(cmbPersonal, lista.Select(p => new Opcion { Id = p.IdPersonal, Texto = p.Codigo + " - " + p.NombreCompleto }).ToList());
            cmbPersonal.Enabled = Sesion.EsGestor();
        }

        private void CargarGrid()
        {
            List<Justificacion> lista = justificacionService.Consultar(cmbFiltro.SelectedItem.ToString());
            if (!Sesion.EsGestor())
                lista = lista.Where(j => j.IdPersonal == Sesion.IdPersonalActual).ToList();

            grid.DataSource = lista.Select(j => new
            {
                Id = j.IdJustificacion,
                Trabajador = personalService.BuscarPorId(j.IdPersonal)?.NombreCompleto,
                Tipo = j.Tipo,
                Solicitud = j.FechaSolicitud.ToString("dd/MM/yyyy HH:mm"),
                Ausencia = j.FechaAusencia.ToString("dd/MM/yyyy"),
                Motivo = j.Motivo,
                Estado = j.Estado
            }).ToList();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Motivo obligatorio
            if (!Validador.TieneTexto(txtMotivo.Text)) { errores.SetError(txtMotivo, "Campo obligatorio"); return; }
            errores.SetError(txtMotivo, "");

            Justificacion j = new Justificacion();
            j.IdPersonal = Sesion.EsGestor() ? UI.IdElegido(cmbPersonal) : Sesion.IdPersonalActual;
            j.Tipo = cmbTipo.SelectedItem.ToString();
            j.FechaAusencia = dtpAusencia.Value;
            j.Motivo = txtMotivo.Text;

            string r = justificacionService.RegistrarJustificacion(j);
            UI.Mostrar(r);
            if (!Validador.EsError(r)) 
            { 
                txtMotivo.Clear(); CargarGrid(); 
            }
        }

        private void btnAprobar_Click(object sender, EventArgs e) { Resolver(true); }
        private void btnRechazar_Click(object sender, EventArgs e) { Resolver(false); }
        private void btnConsultar_Click(object sender, EventArgs e) { CargarGrid(); }

        private void Resolver(bool aprobar)
        {
            int id = UI.IdFilaSeleccionada(grid);
            if (id == 0) 
            { 
                UI.Mostrar("Error: Seleccione una justificación de la tabla."); return; 
            }

            UI.Mostrar(aprobar ? justificacionService.Aprobar(id) : justificacionService.Rechazar(id));
            CargarGrid();
        }
    }
}

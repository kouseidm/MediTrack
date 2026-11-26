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
    public partial class FormJustificaciones : Form
    {
        private NPersonal negPersonal = new NPersonal();
        private NAsistencia negAsistencia = new NAsistencia();
        private NJustificacion negJustificacion = new NJustificacion();
        private ErrorProvider errores = new ErrorProvider();

        public FormJustificaciones()
        {
            InitializeComponent();

            cmbTipo.DataSource = NJustificacion.Tipos.ToList();
            cmbFiltro.DataSource = new List<string> { "Todos", NJustificacion.Pendiente, NJustificacion.Aprobada, NJustificacion.Rechazada };

            btnAprobar.Visible = NSesion.EsGestor();
            btnRechazar.Visible = NSesion.EsGestor();

            CargarPersonal();
            CargarGrid();
        }

        private void CargarPersonal()
        {
            List<Personal> lista = negPersonal.ObtenerTodos().Where(p => p.Activo).ToList();

            if (!NSesion.EsGestor())
                lista = lista.Where(p => p.Id == NSesion.IdPersonalActual).ToList();

            UI.CargarCombo(cmbPersonal, lista.Select(p => new Opcion { Id = p.Id, Texto = p.Codigo + " - " + UI.NombreCompleto(p) }).ToList());
            cmbPersonal.Enabled = NSesion.EsGestor();
        }

        private void CargarGrid()
        {
            List<Justificacion> lista = negJustificacion.Consultar(cmbFiltro.SelectedItem.ToString());

            Dictionary<int, RegistroAsistencia> jornadas = negAsistencia.ObtenerTodos().ToDictionary(a => a.Id);
            Dictionary<int, Personal> personal = negPersonal.ObtenerTodos().ToDictionary(p => p.Id);

            var filas = lista.Select(j =>
            {
                RegistroAsistencia jornada;
                jornadas.TryGetValue(j.IdAsistencia, out jornada);
                int idPersonal = jornada == null ? 0 : jornada.IdPersonal;
                Personal trabajador;
                personal.TryGetValue(idPersonal, out trabajador);
                return new { Justificacion = j, IdPersonal = idPersonal, Trabajador = trabajador };
            });

            if (!NSesion.EsGestor())
                filas = filas.Where(f => f.IdPersonal == NSesion.IdPersonalActual);

            grid.DataSource = filas.Select(f => new
            {
                Id = f.Justificacion.Id,
                Trabajador = UI.NombreCompleto(f.Trabajador),
                Tipo = f.Justificacion.Tipo,
                Solicitud = f.Justificacion.FechaSolicitud.ToString("dd/MM/yyyy HH:mm"),
                Ausencia = f.Justificacion.FechaAusencia.ToString("dd/MM/yyyy"),
                Motivo = f.Justificacion.Motivo,
                Estado = f.Justificacion.Estado
            }).ToList();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!Validador.TieneTexto(txtMotivo.Text)) { errores.SetError(txtMotivo, "Campo obligatorio"); return; }
            errores.SetError(txtMotivo, "");

            int idPersonal = NSesion.EsGestor() ? UI.IdElegido(cmbPersonal) : NSesion.IdPersonalActual;

            Justificacion j = new Justificacion();
            j.Tipo = cmbTipo.SelectedItem == null ? "" : cmbTipo.SelectedItem.ToString();
            j.FechaAusencia = dtpAusencia.Value.Date;
            j.Motivo = txtMotivo.Text.Trim();

            if (UI.Resultado(negJustificacion.RegistrarParaFecha(j, idPersonal), "Justificación registrada correctamente."))
            {
                txtMotivo.Clear();
                CargarGrid();
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
                UI.Aviso("Seleccione una justificación de la tabla.");
                return;
            }

            string error = aprobar ? negJustificacion.Aprobar(id) : negJustificacion.Rechazar(id);
            UI.Resultado(error, aprobar ? "Justificación aprobada." : "Justificación rechazada.");
            CargarGrid();
        }
    }
}

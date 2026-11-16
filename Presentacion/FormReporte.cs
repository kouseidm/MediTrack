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
    public partial class FormReporte : Form
    {
        private NReporte negReporte = new NReporte();
        private NArea negArea = new NArea();
        private NPersonal negPersonal = new NPersonal();

        public FormReporte()
        {
            InitializeComponent();

            dtpDesde.Value = DateTime.Today.AddDays(-90);
            CargarFiltros();
            CargarTipos();

            if (!NSesion.EsGestor())
            {
                cmbPersonal.SelectedValue = NSesion.IdPersonalActual;
                cmbPersonal.Enabled = false;
                cmbArea.SelectedValue = NSesion.UsuarioActual.IdArea;
                cmbArea.Enabled = false;
            }

        }

        private void CargarFiltros()
        {

            List<Opcion> areas = new List<Opcion>();
            areas.Add(new Opcion { Id = 0, Texto = "(Todas)" });
            foreach (Area a in negArea.ObtenerTodos())
            {
                areas.Add(new Opcion { Id = a.Id, Texto = a.Nombre });
            }
            UI.CargarCombo(cmbArea, areas);

            List<Opcion> personal = new List<Opcion>();
            personal.Add(new Opcion { Id = 0, Texto = "(Todos)" });
            foreach (Personal p in negPersonal.ObtenerTodos())
            {
                personal.Add(new Opcion { Id = p.Id, Texto = p.Codigo + " - " + UI.NombreCompleto(p) });
            }
            UI.CargarCombo(cmbPersonal, personal);
        }

        private void CargarTipos()
        {
            List<Opcion> tipos = new List<Opcion>();
            tipos.Add(new Opcion { Id = 1, Texto = "Resumen de asistencia" });
            tipos.Add(new Opcion { Id = 2, Texto = "Incidencias diarias" });
            UI.CargarCombo(cmbTipo, tipos);


        }

        private Reportes LeerFiltro()
        {
            Reportes f = new Reportes();
            f.PeriodoInicio = dtpDesde.Value.Date;
            f.PeriodoFin = dtpHasta.Value.Date;
            f.IdArea = UI.IdElegido(cmbArea);
            f.IdPersonal = UI.IdElegido(cmbPersonal);
            return f;
        }

        private void MostrarReporte()
        {
            Reportes filtro = LeerFiltro();
            string error = negReporte.ValidarFiltro(filtro);
            if (error != "")
            {
                UI.Aviso(error);
                return;
            }

            int tipo = UI.IdElegido(cmbTipo);
            DataTable tabla;

            if (tipo == 1)
                tabla = negReporte.GenerarResumenAsistencia(filtro);
            else
                tabla = negReporte.GenerarIncidenciasDiarias(filtro);

            dgvReportes.DataSource = tabla;

            if (tabla.Rows.Count == 0)
                MessageBox.Show("No hay jornadas registradas en el periodo seleccionado.");
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            MostrarReporte();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            MostrarReporte();
        }

    }
}

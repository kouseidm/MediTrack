using System;
using System.Windows.Forms;
using MediTrack.Entities;
using MediTrack.Services;

namespace MediTrack.Forms
{
    // Menu principal
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();

            label4.Text = "Bienvenido: " + Sesion.UsuarioActual.NombreCompleto + " (" + Sesion.UsuarioActual.Rol + ")";
            AplicarPermisos();
        }

        // Roles 
        private void AplicarPermisos()
        {
            bool gestor = Sesion.EsGestor();

            mantenimientoToolStripMenuItem.Visible = gestor;
            áreasToolStripMenuItem.Visible = Sesion.EsAdmin();
            jornadasToolStripMenuItem.Visible = gestor;
            reportesToolStripMenuItem.Visible = gestor;
        }

        private void personalMédicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPersonal frm = new FormPersonal();
            frm.ShowDialog();
        }

        private void áreasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAreas frm = new FormAreas();
            frm.ShowDialog();
        }

        private void turnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTurnos frm = new FormTurnos();
            frm.ShowDialog();
        }

        private void jornadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormJornadas frm = new FormJornadas();
            frm.ShowDialog();
        }

        private void justificacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormJustificaciones frm = new FormJustificaciones();
            frm.ShowDialog();
        }

        private void reporteDeAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReportes frm = new FormReportes();
            frm.ShowDialog();
        }

        // Abre los graficos con un filtro por defecto
        private void graficoDeLineasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes filtro = new Reportes();
            filtro.PeriodoInicio = DateTime.Today.AddDays(-90);
            filtro.PeriodoFin = DateTime.Today;
            filtro.IdArea = 0;
            filtro.IdPersonal = 0;

            FormGraficos frm = new FormGraficos(filtro);
            frm.ShowDialog();
        }

        private void btnRegistrarAsistencia_Click(object sender, EventArgs e)
        {
            FormMarcacion frm = new FormMarcacion();
            frm.ShowDialog();
        }

        // Al cerrar este formulario, FormLogin vuelve a mostrarse
        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

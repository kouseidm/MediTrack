using Datos;
using Negocio;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormMenuPrincipal : Form
    {
        private Personal usuarioActual;
        public bool CerrarSesion { get; private set; }

        public FormMenuPrincipal(Personal usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            lblBienvenida.Text = "Bienvenido: " + usuario.Nombres + " " + usuario.Apellidos
                               + " (" + usuario.Rol + ")";

            AplicarPermisos();
        }

        private void mnuPersonal_Click(object sender, EventArgs e)
        {
            FormPersonal form = new FormPersonal();
            form.ShowDialog();
        }

        private void mnuAreas_Click(object sender, EventArgs e)
        {
            FormArea form = new FormArea();
            form.ShowDialog();
        }

        private void mnuTurnos_Click(object sender, EventArgs e)
        {
            FormTurnos form = new FormTurnos();
            form.ShowDialog();
        }

        private void mnuJornadas_Click(object sender, EventArgs e)
        {
            FormJornada form = new FormJornada();
            form.ShowDialog();
        }

        private void mnuJustificaciones_Click(object sender, EventArgs e)
        {
            FormJustificaciones form = new FormJustificaciones();
            form.ShowDialog();
        }

        private void mnuReportesEstadisticos_Click(object sender, EventArgs e)
        {
            FormReporte form = new FormReporte();
            form.ShowDialog();
        }

        private void mnuGraficos_Click(object sender, EventArgs e)
        {
            FormGraficos form = new FormGraficos();
            form.ShowDialog();
        }
        private void btnMarcarAsistencia_Click(object sender, EventArgs e)
        {
            using (FormMarcarAsistencia frm = new FormMarcarAsistencia())
            {
                frm.ShowDialog(this);
            }
        }
        private void mnuCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea cerrar la sesión?", "MediTrack",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                CerrarSesion = true;
                this.Close();
            }
        }

        private void AplicarPermisos()
        {
            bool gestor = NSesion.EsGestor();
            mnuMantenimiento.Visible = gestor;   
            mnuJornadas.Visible = gestor;        
        }


    }
}

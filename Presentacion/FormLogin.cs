using System;
using System.Windows.Forms;
using Datos;
using Negocio;

namespace Presentacion
{
    public partial class FormLogin : Form
    {
        private NPersonal objNegocio = new NPersonal();

        public FormLogin()
        {
            InitializeComponent();
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text;

            if (usuario == "" || clave == "")
            {
                MessageBox.Show("Ingrese su usuario y contraseña.", "MediTrack",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Personal empleado;
            try
            {
                empleado = objNegocio.ValidarLogin(usuario, clave);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar con la base de datos.\n\n" + ex.Message,
                                "MediTrack", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (empleado == null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "MediTrack",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Clear();
                txtClave.Focus();
                return;
            }

            NSesion.Iniciar(empleado);
            FormMenuPrincipal menu = new FormMenuPrincipal(empleado);
            this.Hide();
            menu.ShowDialog();

            if (menu.CerrarSesion)
            {
                NSesion.Cerrar();
                txtUsuario.Clear();
                txtClave.Clear();
                this.Show();
                txtUsuario.Focus();
            }
            else
            {
                this.Close();
            }
        }

        private void lnkSalir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }
    }
}

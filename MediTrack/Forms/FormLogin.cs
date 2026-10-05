using System;
using System.Windows.Forms;
using MediTrack.Entities;
using MediTrack.Services;

namespace MediTrack.Forms
{
    public partial class FormLogin : Form
    {
        private PersonalService personalService = new PersonalService();

        public FormLogin()
        {
            InitializeComponent();   
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Validacion de campos obligatorios
            if (!Validador.TieneTexto(txtUsuario.Text) || !Validador.TieneTexto(txtClave.Text))
            {
                MessageBox.Show("Ingrese usuario y contraseña.");
                return;
            }

            Personal p = personalService.IniciarSesion(txtUsuario.Text, txtClave.Text);
            if (p == null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos, o usuario desactivado.");
                txtClave.Clear();
                return;
            }

            Sesion.Iniciar(p);
            txtUsuario.Clear();
            txtClave.Clear();

            this.Hide();
            new FormPrincipal().ShowDialog();   // al cerrar el menu volvemos al login
            Sesion.Cerrar();
            this.Show();
        }

        // La marcacion no necesita iniciar sesion
        private void btnMarcar_Click(object sender, EventArgs e)
        {
            new FormMarcacion().ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

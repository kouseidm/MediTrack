using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Datos;
using Negocio;

namespace Presentacion
{
    public partial class FormMarcarAsistencia : Form
    {
        private NAsistencia objAsistencia = new NAsistencia();
        private NPersonal objPersonal = new NPersonal();
        private CultureInfo cultura = new CultureInfo("es-PE");

        public FormMarcarAsistencia()
        {
            InitializeComponent();
        }
        private void FrmMarcarAsistencia_Load(object sender, EventArgs e)
        {
            ActualizarReloj();

            if (!NSesion.EsGestor())
            {
                txtCodigo.Text = NSesion.UsuarioActual.Codigo;
                txtCodigo.ReadOnly = true;
            }

            txtCodigo.Focus();
        }
        private void timerReloj_Tick(object sender, EventArgs e)
        {
            ActualizarReloj();
        }
        private void ActualizarReloj()
        {
            DateTime ahora = DateTime.Now;
            lblReloj.Text = ahora.ToString("HH:mm:ss");
            lblFecha.Text = ahora.ToString("dddd, dd 'de' MMMM 'de' yyyy", cultura);
        }
        private void MostrarMensaje(string texto, bool esError)
        {
            lblMensaje.Text = texto;
            lblMensaje.ForeColor = esError ? Color.Firebrick : Color.SeaGreen;
        }
        private Personal BuscarTrabajador(string codigo)
        {
            return objPersonal.ObtenerTodos().FirstOrDefault(p => p.Codigo == codigo);
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.Trim();

            try
            {
                string error = objAsistencia.RegistrarIngreso(codigo);
                if (error != "")
                {
                    MostrarMensaje(error, true);
                    return;
                }

                string mensaje = "Ingreso registrado";
                Personal trabajador = BuscarTrabajador(codigo);
                if (trabajador != null)
                {
                    mensaje += ": " + trabajador.Nombres + " " + trabajador.Apellidos;

                    RegistroAsistencia registro = objAsistencia.ObtenerTodos()
                        .Where(a => a.IdPersonal == trabajador.Id && a.HoraIngreso != null)
                        .OrderByDescending(a => a.HoraIngreso)
                        .FirstOrDefault();

                    if (registro != null)
                    {
                        mensaje += " a las " + registro.HoraIngreso.Value.ToString("HH:mm") + ".";
                        if (registro.MinutosTardanza > 0)
                        {
                            mensaje += " Tardanza de " + registro.MinutosTardanza + " minutos.";
                        }
                    }
                }

                MostrarMensaje(mensaje, false);
                txtCodigo.Clear();
                txtCodigo.Focus();
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al registrar el ingreso: " + ex.Message, true);
            }
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.Trim();

            try
            {
                string error = objAsistencia.RegistrarSalida(codigo);
                if (error != "")
                {
                    MostrarMensaje(error, true);
                    return;
                }

                string mensaje = "Salida registrada";
                Personal trabajador = BuscarTrabajador(codigo);
                if (trabajador != null)
                {
                    mensaje += ": " + trabajador.Nombres + " " + trabajador.Apellidos;

                    RegistroAsistencia registro = objAsistencia.ObtenerTodos()
                        .Where(a => a.IdPersonal == trabajador.Id && a.HoraSalida != null)
                        .OrderByDescending(a => a.HoraSalida)
                        .FirstOrDefault();

                    if (registro != null)
                    {
                        mensaje += " a las " + registro.HoraSalida.Value.ToString("HH:mm") + ".";
                        mensaje += " Horas trabajadas: " + registro.HorasTrabajadas.ToString("0.00") + ".";
                    }
                }

                MostrarMensaje(mensaje, false);
                txtCodigo.Clear();
                txtCodigo.Focus();
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al registrar la salida: " + ex.Message, true);
            }
        }
    }
}

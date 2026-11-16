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
    public partial class FormJornada : Form
    {
        private NPersonal negPersonal = new NPersonal();
        private NAsistencia negAsistencia = new NAsistencia();

        public FormJornada()
        {
            InitializeComponent();

            List<Personal> personal = negPersonal.ObtenerTodos().Where(p => p.Activo).ToList();

            List<Opcion> opciones = personal.Select(p => new Opcion
            {
                Id = p.Id,
                Texto = p.Codigo + " - " + UI.NombreCompleto(p)
            }).ToList();

            UI.CargarCombo(cmbPersonal, opciones);
            CargarGrid();
        }

        private void CargarGrid()
        {
            negAsistencia.ActualizarFaltas();
            grid.DataSource = negAsistencia.ListarPorPersonal(UI.IdElegido(cmbPersonal)).Select(a => new
            {
                Id = a.Id,
                Inicio = a.InicioProgramado.ToString("dd/MM/yyyy HH:mm"),
                Fin = a.FinProgramado.ToString("dd/MM/yyyy HH:mm"),
                Ingreso = a.HoraIngreso == null ? "-" : a.HoraIngreso.Value.ToString("HH:mm"),
                Salida = a.HoraSalida == null ? "-" : a.HoraSalida.Value.ToString("HH:mm"),
                MinTardanza = a.MinutosTardanza,
                Horas = a.HorasTrabajadas,
                Estado = a.Estado
            }).ToList();
        }

        private void btnProgramar_Click(object sender, EventArgs e)
        {
            int id = UI.IdElegido(cmbPersonal);
            if (id == 0)
            {
                UI.Aviso("Seleccione un trabajador.");
                return;
            }

            UI.Resultado(negAsistencia.ProgramarJornadaDesdeTurno(id, dtpFecha.Value), "Jornada programada correctamente.");
            CargarGrid();
        }

        private void btnMasivo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Programar la jornada del " + dtpFecha.Value.ToShortDateString() + " para todo el personal activo?",
                "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int programadas;
                string error = negAsistencia.ProgramarJornadaMasiva(dtpFecha.Value, out programadas);
                UI.Resultado(error, "Se programaron " + programadas + " jornadas. (Quienes ya tenían jornada ese día se omitieron.)");
                CargarGrid();
            }
        }

        private void btnVerJornadas_Click(object sender, EventArgs e)
        {
            CargarGrid();
        }
    }
}

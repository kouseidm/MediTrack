using MediTrack.Entities;
using MediTrack.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MediTrack.Forms
{
    // Programacion de jornadas segun el turno asignado
    public partial class FormJornadas : Form
    {
        private PersonalService personalService = new PersonalService();
        private AsistenciaService asistenciaService = new AsistenciaService();

        public FormJornadas()
        {
            InitializeComponent();

            List<Personal> personal = personalService.ListarActivos();

            List<Opcion> opciones = personal.Select(p => new Opcion
            {
                Id = p.IdPersonal,
                Texto = p.Codigo + " - " + p.NombreCompleto
            }).ToList();

            UI.CargarCombo(cmbPersonal, opciones);
            CargarGrid();
        }

        private void CargarGrid()
        {
            asistenciaService.ActualizarFaltas();
            grid.DataSource = asistenciaService.ListarPorPersonal(UI.IdElegido(cmbPersonal)).Select(a => new
            {
                Id = a.IdAsistencia,
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
                UI.Mostrar("Error: Seleccione un trabajador.");
                return; 
            }

            UI.Mostrar(asistenciaService.ProgramarJornadaDesdeTurno(id, dtpFecha.Value));
            CargarGrid();
        }

        private void btnMasivo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Programar la jornada del " + dtpFecha.Value.ToShortDateString() + " para todo el personal activo?",
                "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show(asistenciaService.ProgramarJornadaMasiva(dtpFecha.Value));
                CargarGrid();
            }
        }

        private void btnVerJornadas_Click(object sender, EventArgs e)
        {
            CargarGrid();
        }
    }
}

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
        private NArea negArea = new NArea();
        private NAsistencia negAsistencia = new NAsistencia();

        public FormJornada()
        {
            InitializeComponent();

            CargarAreas();
            CargarPersonal();
            CargarGrid();
        }

        private void CargarAreas()
        {
            List<Opcion> opciones = new List<Opcion>
            {
                new Opcion { Id = 0, Texto = "Seleccione un área" }
            };

            opciones.AddRange(negArea.ObtenerTodos()
                .Where(a => a.Activo)
                .OrderBy(a => a.Nombre)
                .Select(a => new Opcion
                {
                    Id = a.Id,
                    Texto = a.Nombre
                }));

            UI.CargarCombo(cmbArea, opciones);
        }

        private void CargarPersonal()
        {
            List<Opcion> opciones = new List<Opcion>
            {
                new Opcion { Id = 0, Texto = "Seleccione un trabajador (opcional)" }
            };

            opciones.AddRange(negPersonal.ObtenerTodos()
                .Where(p => p.Activo)
                .OrderBy(p => p.Apellidos)
                .ThenBy(p => p.Nombres)
                .Select(p => new Opcion
                {
                    Id = p.Id,
                    Texto = p.Codigo + " - " + UI.NombreCompleto(p)
                }));

            UI.CargarCombo(cmbPersonal, opciones);
        }

        private void CargarGrid()
        {
            negAsistencia.ActualizarFaltas();
            int idPersonal = UI.IdElegido(cmbPersonal);
            int idArea = UI.IdElegido(cmbArea);

            List<RegistroAsistencia> jornadas;
            if (idPersonal > 0)
            {
                jornadas = negAsistencia.ListarPorPersonal(idPersonal);
            }
            else if (idArea > 0)
            {
                jornadas = negAsistencia.ListarPorArea(idArea);
            }
            else
            {
                jornadas = negAsistencia.ListarPorPersonal(0);
            }

            grid.DataSource = jornadas.Select(a => new
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
            int idArea = UI.IdElegido(cmbArea);
            if (idArea == 0)
            {
                UI.Aviso("Seleccione un área.");
                return;
            }

            Opcion areaElegida = cmbArea.SelectedItem as Opcion;
            string nombreArea = areaElegida == null ? "área seleccionada" : areaElegida.Texto;
            if (MessageBox.Show("¿Programar la jornada del " + dtpFecha.Value.ToShortDateString() +
                " para todo el personal activo del área " + nombreArea + "?",
                "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int programadas;
                string error = negAsistencia.ProgramarJornadaMasiva(dtpFecha.Value, idArea, out programadas);
                UI.Resultado(error, "Se programaron " + programadas + " jornadas. (Quienes ya tenían jornada ese día se omitieron.)");
                CargarGrid();
            }
        }

        private void btnVerJornadas_Click(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void btnVerTodos_Click(object sender, EventArgs e)
        {
            negAsistencia.ActualizarFaltas();

            Dictionary<int, Personal> personalPorId = negPersonal.ObtenerTodos()
                .ToDictionary(p => p.Id);

            grid.DataSource = negAsistencia.ObtenerTodos()
                .OrderByDescending(a => a.InicioProgramado)
                .Select(a => new
                {
                    Id = a.Id,
                    Trabajador = personalPorId.ContainsKey(a.IdPersonal)
                        ? personalPorId[a.IdPersonal].Codigo + " - " + UI.NombreCompleto(personalPorId[a.IdPersonal])
                        : "(trabajador no encontrado)",
                    Inicio = a.InicioProgramado.ToString("dd/MM/yyyy HH:mm"),
                    Fin = a.FinProgramado.ToString("dd/MM/yyyy HH:mm"),
                    Ingreso = a.HoraIngreso == null ? "-" : a.HoraIngreso.Value.ToString("HH:mm"),
                    Salida = a.HoraSalida == null ? "-" : a.HoraSalida.Value.ToString("HH:mm"),
                    MinTardanza = a.MinutosTardanza,
                    Horas = a.HorasTrabajadas,
                    Estado = a.Estado
                })
                .ToList();
        }
    }
}

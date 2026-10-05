using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MediTrack.Entities;
using MediTrack.Services;

namespace MediTrack.Forms
{
    public partial class FormReportes : Form
    {
        private ReporteService reporteService = new ReporteService();
        private AreaService areaService = new AreaService();
        private PersonalService personalService = new PersonalService();

        public FormReportes()
        {
            InitializeComponent();

            dtpDesde.Value = DateTime.Today.AddDays(-90);
            CargarFiltros();
            CargarTipos();
        }

        private void CargarFiltros()
        {
            
            List<Opcion> areas = new List<Opcion>();
            areas.Add(new Opcion { Id = 0, Texto = "(Todas)" });
            foreach (Area a in areaService.ListarArea())
            {
                areas.Add(new Opcion { Id = a.IdArea, Texto = a.Nombre });
            }
            UI.CargarCombo(cmbArea, areas);

            List<Opcion> personal = new List<Opcion>();
            personal.Add(new Opcion { Id = 0, Texto = "(Todos)" });
            foreach (Personal p in personalService.ListarTodo())
            {
                personal.Add(new Opcion { Id = p.IdPersonal, Texto = p.Codigo + " - " + p.NombreCompleto });
            }
            UI.CargarCombo(cmbPersonal, personal);
        }

        // Los 2 reportes que se pueden mostrar en la tabla
        private void CargarTipos()
        {
            List<Opcion> tipos = new List<Opcion>();
            tipos.Add(new Opcion { Id = 1, Texto = "Resumen de asistencia" });
            tipos.Add(new Opcion { Id = 2, Texto = "Incidencias diarias" });
            UI.CargarCombo(cmbTipo, tipos);
        }

        // Arma el filtro con lo que hay en pantalla
        private Reportes LeerFiltro()
        {
            Reportes f = new Reportes();
            f.PeriodoInicio = dtpDesde.Value.Date;
            f.PeriodoFin = dtpHasta.Value.Date;
            f.IdArea = UI.IdElegido(cmbArea);
            f.IdPersonal = UI.IdElegido(cmbPersonal);
            return f;
        }

        // Muestra en la tabla el reporte elegido por el usuario
        private void MostrarReporte()
        {
            Reportes filtro = LeerFiltro();
            string error = reporteService.ValidarFiltro(filtro);
            if (error != "") 
            { 
                UI.Mostrar(error);
                return; 
            }

            int tipo = UI.IdElegido(cmbTipo);
            DataTable tabla;

            if (tipo == 1)
                tabla = reporteService.GenerarResumenAsistencia(filtro);
            else
                tabla = reporteService.GenerarIncidenciaDiarias(filtro);

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

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MediTrack.Entities;
using MediTrack.Services;

namespace MediTrack.Forms
{
    public partial class FormGraficos : Form
    {
        private ReporteService reporteService = new ReporteService();
        private Reportes filtro;

        public FormGraficos(Reportes filtro)
        {
            InitializeComponent();
            this.filtro = filtro;

            UI.CargarCombo(cmbTipo, new List<Opcion>
            {
                new Opcion { Id = 1, Texto = "Distribución de asistencia (circular)" },
                new Opcion { Id = 2, Texto = "Evolución del ausentismo (líneas)" },
                new Opcion { Id = 3, Texto = "Tardanzas por área (barras)" }
            });

            Mostrar();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void Mostrar()
        {
            int tipo = UI.IdElegido(cmbTipo);
            chart.Series.Clear();
            chart.Titles.Clear();

            Series serie = new Series("Datos");
            List<ItemGrafico> datos;

            if (tipo == 1)          
            {
                datos = reporteService.ObtenerDistribucionAsistencia(filtro);
                serie.ChartType = SeriesChartType.Pie;
                serie.Label = "#VALX: #VAL{0.0}%";
                serie.LegendText = "#VALX";
                serie["PieLabelStyle"] = "Outside";
                serie["PieLineColor"] = "Gray";
                chart.Titles.Add(new Title("Distribución de asistencia (%)"));
            }
            else if (tipo == 2)     
            {
                datos = reporteService.ObtenerEvolucionAusentismo(filtro);
                serie.ChartType = SeriesChartType.Line;
                serie.MarkerStyle = MarkerStyle.Circle;
                serie.Label = "#VAL{0.0}%";
                chart.Titles.Add(new Title("Ausentismo no justificado por mes (%)"));
            }
            else                    
            {
                datos = reporteService.ObtenerTardanzaPorArea(filtro);
                serie.ChartType = SeriesChartType.Column;
                serie.Label = "#VAL";
                chart.Titles.Add(new Title("Tardanzas acumuladas por área"));
            }

            chart.Legends["leyenda"].Enabled = (tipo == 1);

            // Etiquetas (labels) de los ejes y de los datos
            ChartArea area = chart.ChartAreas["principal"];
            area.AxisX.Title = "";
            area.AxisY.Title = "";
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Angle = 0;
            area.AxisY.LabelStyle.Format = "0.#";
            serie.IsValueShownAsLabel = true;
            serie.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            if (tipo == 2)
            {
                area.AxisX.Title = "Mes";
                area.AxisY.Title = "Ausentismo no justificado (%)";
                serie.LabelFormat = "0.0\"%\"";
                serie.SmartLabelStyle.Enabled = true;
            }
            else if (tipo == 3)
            {
                area.AxisX.Title = "Área";
                area.AxisY.Title = "Minutos de tardanza";
                serie.LabelFormat = "0";
            }

            foreach (ItemGrafico item in datos)
            {
                serie.Points.AddXY(item.Etiqueta, item.Valor);
            }

            chart.Series.Add(serie);

            if (datos.Count == 0)
            {
                MessageBox.Show("No hay datos para el periodo y filtros seleccionados.");
            }
        }
    }
}

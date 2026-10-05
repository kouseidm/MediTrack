using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MediTrack.Entities;
using MediTrack.Services;

namespace MediTrack.Forms
{
    public static class UI
    {
        // Llena un ComboBox con una lista de Opcion
        public static void CargarCombo(ComboBox c, List<Opcion> opciones)
        {
            c.DataSource = null;
            c.DisplayMember = "Texto";
            c.ValueMember = "Id";
            c.DataSource = opciones;
        }

        // Devuelve el Id elegido (0 si no hay nada elegido)
        public static int IdElegido(ComboBox c)
        {
            if (c.SelectedValue == null)
                return 0;
            return Convert.ToInt32(c.SelectedValue);
        }

        // Muestra el resultado de un servicio
        public static void Mostrar(string mensaje)
        {
            MessageBoxIcon icono = Validador.EsError(mensaje) ? MessageBoxIcon.Warning : MessageBoxIcon.Information;
            MessageBox.Show(mensaje, "MediTrack", MessageBoxButtons.OK, icono);
        }

        // Fecha y hora para mostrar en los labels de auditoria
        public static string FechaHora(DateTime fecha)
        {
            return fecha.ToString("dd/MM/yyyy HH:mm");
        }

        // Id de la primera columna de la fila seleccionada (0 si no hay)
        public static int IdFilaSeleccionada(DataGridView g)
        {
            if (g.CurrentRow == null || g.CurrentRow.Cells.Count == 0)
                return 0;
            return Convert.ToInt32(g.CurrentRow.Cells[0].Value);
        }
    }
}

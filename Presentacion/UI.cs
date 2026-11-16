using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Datos;

namespace Presentacion
{
    public class Opcion
    {
        public int Id { get; set; }
        public string Texto { get; set; }
    }

    public static class Validador
    {
        public static bool TieneTexto(string texto)
        {
            return !string.IsNullOrWhiteSpace(texto);
        }
    }

    public static class UI
    {
        public static int IdFilaSeleccionada(DataGridView grid)
        {
            if (grid.CurrentRow == null)
            {
                return 0;
            }
            object valor = grid.CurrentRow.Cells["Id"].Value;
            if (valor == null)
            {
                return 0;
            }
            return Convert.ToInt32(valor);
        }

        public static void CargarCombo(ComboBox combo, List<Opcion> opciones)
        {
            combo.DataSource = null;
            combo.DisplayMember = "Texto";
            combo.ValueMember = "Id";
            combo.DataSource = opciones;
        }

        public static int IdElegido(ComboBox combo)
        {
            if (combo.SelectedValue is int)
            {
                return (int)combo.SelectedValue;
            }
            Opcion opcion = combo.SelectedItem as Opcion;
            if (opcion == null)
            {
                return 0;
            }
            return opcion.Id;
        }

        public static bool Resultado(string error, string exito)
        {
            if (error != "")
            {
                MessageBox.Show(error, "MediTrack", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            MessageBox.Show(exito, "MediTrack", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        public static void Aviso(string mensaje)
        {
            MessageBox.Show(mensaje, "MediTrack", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static string FechaHora(DateTime fecha)
        {
            return fecha.ToString("dd/MM/yyyy HH:mm");
        }

        public static string NombreCompleto(Personal p)
        {
            if (p == null)
            {
                return "";
            }
            return p.Nombres + " " + p.Apellidos;
        }

        public static string Horario(Turno t)
        {
            return t.HoraInicio.ToString("HH:mm") + " - " + t.HoraFin.ToString("HH:mm");
        }

        public static DateTime SoloHora(DateTime valor)
        {
            return new DateTime(1900, 1, 1).Add(valor.TimeOfDay);
        }
    }
}

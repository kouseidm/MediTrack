using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MediTrack.Entities;
using MediTrack.Services;

namespace MediTrack.Forms
{
    public partial class FormPersonal : Form
    {
        private PersonalService personalService = new PersonalService();
        private AreaService areaService = new AreaService();
        private TurnoService turnoService = new TurnoService();

        public FormPersonal()
        {
            InitializeComponent();

            cmbRol.DataSource = Roles.Todos.ToList();
            CargarCombos();
            CargarGrid(personalService.ListarTodo());
        }

        private void CargarCombos()
        {
            UI.CargarCombo(cmbArea, areaService.ListarActivas().Select(a => new Opcion { Id = a.IdArea, Texto = a.Nombre }).ToList());
            UI.CargarCombo(cmbTurno, turnoService.ListarActivos().Select(t => new Opcion { Id = t.IdTurno, Texto = t.Nombre + " (" + t.Horario + ")" }).ToList());
        }

        private void CargarGrid(List<Personal> lista)
        {
            List<Area> areas = areaService.ListarArea();
            List<Turno> turnos = turnoService.ListarTurnos();

            grid.DataSource = lista.Select(p => new
            {
                Id = p.IdPersonal,
                Codigo = p.Codigo,
                Nombre = p.NombreCompleto,
                Usuario = p.Usuario,
                Rol = p.Rol,
                Area = areas.Find(a => a.IdArea == p.IdArea)?.Nombre,
                Turno = turnos.Find(t => t.IdTurno == p.IdTurno)?.Nombre,
                Activo = p.Activo ? "Sí" : "No"
            }).ToList();
        }

        // Al elegir una fila se llenan los campos
        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            Personal p = personalService.BuscarPorId(UI.IdFilaSeleccionada(grid));
            MostrarAuditoria(p);
            if (p == null) return;

            txtCodigo.Text = p.Codigo;
            txtNombres.Text = p.Nombres;
            txtApellidos.Text = p.Apellidos;
            txtUsuario.Text = p.Usuario;
            txtClave.Clear();
            cmbRol.SelectedItem = p.Rol;
            cmbArea.SelectedValue = p.IdArea;
            cmbTurno.SelectedValue = p.IdTurno;
        }

        // Llena el cuadro AUDITORIA con los datos del registro elegido ("-" si no hay)
        private void MostrarAuditoria(Personal x)
        {
            if (x == null)
            {
                lblCreadoPor.Text = "-";
                lblCreadoEl.Text = "-";
                lblActualizadoPor.Text = "-";
                lblActualizadoEl.Text = "-";
            }
            else
            {
                lblCreadoPor.Text = x.CreadoPor;
                lblCreadoEl.Text = UI.FechaHora(x.FechaCreacion);
                lblActualizadoPor.Text = x.ModificadoPor;
                lblActualizadoEl.Text = UI.FechaHora(x.FechaModificacion);
            }
        }

        // Marca el campo con error si esta vacio 
        private bool Requerido(TextBox t)
        {
            if (!Validador.TieneTexto(t.Text))
            {
                errores.SetError(t, "Campo obligatorio");
                return false;
            }
            errores.SetError(t, "");
            return true;
        }

        private void Limpiar()
        {
            txtCodigo.Clear(); 
            txtNombres.Clear(); 
            txtApellidos.Clear();
            txtUsuario.Clear(); 
            txtClave.Clear();
            errores.Clear();
        }

        // Arma el objeto con lo que hay en pantalla
        private Personal LeerFormulario()
        {
            Personal p = new Personal();
            p.IdPersonal = UI.IdFilaSeleccionada(grid);
            p.Codigo = txtCodigo.Text;
            p.Nombres = txtNombres.Text;
            p.Apellidos = txtApellidos.Text;
            p.Usuario = txtUsuario.Text;
            p.Rol = cmbRol.SelectedItem == null ? "" : cmbRol.SelectedItem.ToString();
            p.IdArea = UI.IdElegido(cmbArea);
            p.IdTurno = UI.IdElegido(cmbTurno);
            return p;
        }

        private void Refrescar(string resultado)
        {
            UI.Mostrar(resultado);
            if (!Validador.EsError(resultado)) 
            { 
                CargarGrid(personalService.ListarTodo()); 
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!Requerido(txtCodigo))
                return;

            if (!Requerido(txtNombres))
                return;

            if (!Requerido(txtApellidos))
                return;

            if (!Requerido(txtUsuario))
                return;

            if (!Requerido(txtClave))
                return;


            string r = personalService.RegistrarPersonal(LeerFormulario(), txtClave.Text);

            Refrescar(r);

            if (!Validador.EsError(r))
            {
                Limpiar();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (UI.IdFilaSeleccionada(grid) == 0) { UI.Mostrar("Error: Seleccione un trabajador de la tabla."); return; }
            bool a = Requerido(txtNombres), b = Requerido(txtApellidos);
            if (!(a && b)) return;

            Refrescar(personalService.ModificarPersonal(LeerFormulario()));
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            int id = UI.IdFilaSeleccionada(grid);
            if (id == 0) 
            { 
                UI.Mostrar("Error: Seleccione un trabajador de la tabla.");
                return; 
            }

            if (MessageBox.Show("¿Desactivar al trabajador seleccionado?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Refrescar(personalService.DesactivarPersonal(id));
        }

        private void btnAsignarTurno_Click(object sender, EventArgs e)
        {
            int id = UI.IdFilaSeleccionada(grid);
            if (id == 0)
            { 
                UI.Mostrar("Error: Seleccione un trabajador de la tabla."); 
                return; 
            }
            Refrescar(personalService.AsignarTurno(id, UI.IdElegido(cmbTurno)));
        }

        private void btnCambiarClave_Click(object sender, EventArgs e)
        {
            Personal p = personalService.BuscarPorId(UI.IdFilaSeleccionada(grid));
            if (p == null)
            {
                UI.Mostrar("Error: Seleccione un trabajador de la tabla."); 
                return; 
            }
            if (!Requerido(txtClave))
                return;

            UI.Mostrar(personalService.CambiarPassword(p.Usuario, txtClave.Text));
            txtClave.Clear();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Personal> res = personalService.BuscarPersonal(txtBuscar.Text);
            if (res.Count == 0) 
                MessageBox.Show("No se encontraron resultados.");
            CargarGrid(res);
        }

        private void btnVerTodos_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarGrid(personalService.ListarTodo());
        }
    }
}

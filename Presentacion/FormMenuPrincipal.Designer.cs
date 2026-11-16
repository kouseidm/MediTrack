namespace Presentacion
{
    partial class FormMenuPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuMantenimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPersonal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAreas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTurnos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOperaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuJornadas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuJustificaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportesEstadisticos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGraficos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlCentro = new System.Windows.Forms.Panel();
            this.btnMarcarAsistencia = new System.Windows.Forms.Button();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.pnlCentro.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMantenimiento,
            this.mnuOperaciones,
            this.mnuReportes,
            this.mnuSesion});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuMantenimiento
            // 
            this.mnuMantenimiento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPersonal,
            this.mnuAreas,
            this.mnuTurnos});
            this.mnuMantenimiento.Name = "mnuMantenimiento";
            this.mnuMantenimiento.Size = new System.Drawing.Size(101, 20);
            this.mnuMantenimiento.Text = "Mantenimiento";
            // 
            // mnuPersonal
            // 
            this.mnuPersonal.Name = "mnuPersonal";
            this.mnuPersonal.Size = new System.Drawing.Size(221, 22);
            this.mnuPersonal.Text = "Gestion de Personal Medico";
            this.mnuPersonal.Click += new System.EventHandler(this.mnuPersonal_Click);
            // 
            // mnuAreas
            // 
            this.mnuAreas.Name = "mnuAreas";
            this.mnuAreas.Size = new System.Drawing.Size(221, 22);
            this.mnuAreas.Text = "Gestion de Areas";
            this.mnuAreas.Click += new System.EventHandler(this.mnuAreas_Click);
            // 
            // mnuTurnos
            // 
            this.mnuTurnos.Name = "mnuTurnos";
            this.mnuTurnos.Size = new System.Drawing.Size(221, 22);
            this.mnuTurnos.Text = "Gestion de Turnos";
            this.mnuTurnos.Click += new System.EventHandler(this.mnuTurnos_Click);
            // 
            // mnuOperaciones
            // 
            this.mnuOperaciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuJornadas,
            this.mnuJustificaciones});
            this.mnuOperaciones.Name = "mnuOperaciones";
            this.mnuOperaciones.Size = new System.Drawing.Size(85, 20);
            this.mnuOperaciones.Text = "Operaciones";
            // 
            // mnuJornadas
            // 
            this.mnuJornadas.Name = "mnuJornadas";
            this.mnuJornadas.Size = new System.Drawing.Size(179, 22);
            this.mnuJornadas.Text = "Programar Jornadas";
            this.mnuJornadas.Click += new System.EventHandler(this.mnuJornadas_Click);
            // 
            // mnuJustificaciones
            // 
            this.mnuJustificaciones.Name = "mnuJustificaciones";
            this.mnuJustificaciones.Size = new System.Drawing.Size(179, 22);
            this.mnuJustificaciones.Text = "Justificaciones";
            this.mnuJustificaciones.Click += new System.EventHandler(this.mnuJustificaciones_Click);
            // 
            // mnuReportes
            // 
            this.mnuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuReportesEstadisticos,
            this.mnuGraficos});
            this.mnuReportes.Name = "mnuReportes";
            this.mnuReportes.Size = new System.Drawing.Size(65, 20);
            this.mnuReportes.Text = "Reportes";
            // 
            // mnuReportesEstadisticos
            // 
            this.mnuReportesEstadisticos.Name = "mnuReportesEstadisticos";
            this.mnuReportesEstadisticos.Size = new System.Drawing.Size(120, 22);
            this.mnuReportesEstadisticos.Text = "Reportes";
            this.mnuReportesEstadisticos.Click += new System.EventHandler(this.mnuReportesEstadisticos_Click);
            // 
            // mnuGraficos
            // 
            this.mnuGraficos.Name = "mnuGraficos";
            this.mnuGraficos.Size = new System.Drawing.Size(120, 22);
            this.mnuGraficos.Text = "Graficos";
            this.mnuGraficos.Click += new System.EventHandler(this.mnuGraficos_Click);
            // 
            // mnuSesion
            // 
            this.mnuSesion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCerrarSesion});
            this.mnuSesion.Name = "mnuSesion";
            this.mnuSesion.Size = new System.Drawing.Size(53, 20);
            this.mnuSesion.Text = "Sesion";
            // 
            // mnuCerrarSesion
            // 
            this.mnuCerrarSesion.Name = "mnuCerrarSesion";
            this.mnuCerrarSesion.Size = new System.Drawing.Size(142, 22);
            this.mnuCerrarSesion.Text = "Cerrar sesion";
            this.mnuCerrarSesion.Click += new System.EventHandler(this.mnuCerrarSesion_Click);
            // 
            // pnlCentro
            // 
            this.pnlCentro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCentro.Controls.Add(this.btnMarcarAsistencia);
            this.pnlCentro.Controls.Add(this.lblBienvenida);
            this.pnlCentro.Controls.Add(this.lblSubtitulo);
            this.pnlCentro.Controls.Add(this.lblTitulo);
            this.pnlCentro.Location = new System.Drawing.Point(100, 120);
            this.pnlCentro.Name = "pnlCentro";
            this.pnlCentro.Size = new System.Drawing.Size(600, 270);
            this.pnlCentro.TabIndex = 1;
            // 
            // btnMarcarAsistencia
            // 
            this.btnMarcarAsistencia.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnMarcarAsistencia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMarcarAsistencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarcarAsistencia.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnMarcarAsistencia.ForeColor = System.Drawing.Color.White;
            this.btnMarcarAsistencia.Location = new System.Drawing.Point(110, 190);
            this.btnMarcarAsistencia.Name = "btnMarcarAsistencia";
            this.btnMarcarAsistencia.Size = new System.Drawing.Size(380, 46);
            this.btnMarcarAsistencia.TabIndex = 3;
            this.btnMarcarAsistencia.Text = "MARCAR ASISTENCIA";
            this.btnMarcarAsistencia.UseVisualStyleBackColor = false;
            this.btnMarcarAsistencia.Click += new System.EventHandler(this.btnMarcarAsistencia_Click);
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBienvenida.ForeColor = System.Drawing.Color.Gray;
            this.lblBienvenida.Location = new System.Drawing.Point(0, 140);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(600, 26);
            this.lblBienvenida.TabIndex = 2;
            this.lblBienvenida.Text = "Bienvenido";
            this.lblBienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.Location = new System.Drawing.Point(0, 92);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(600, 26);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Control de asistencia y personal médico";
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(600, 90);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "MediTrack";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.pnlCentro);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(700, 450);
            this.Name = "FormMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MediTrack - Menú principal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlCentro.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuMantenimiento;
        private System.Windows.Forms.ToolStripMenuItem mnuPersonal;
        private System.Windows.Forms.ToolStripMenuItem mnuAreas;
        private System.Windows.Forms.ToolStripMenuItem mnuTurnos;
        private System.Windows.Forms.ToolStripMenuItem mnuOperaciones;
        private System.Windows.Forms.ToolStripMenuItem mnuJornadas;
        private System.Windows.Forms.ToolStripMenuItem mnuJustificaciones;
        private System.Windows.Forms.ToolStripMenuItem mnuReportes;
        private System.Windows.Forms.ToolStripMenuItem mnuReportesEstadisticos;
        private System.Windows.Forms.ToolStripMenuItem mnuGraficos;
        private System.Windows.Forms.ToolStripMenuItem mnuSesion;
        private System.Windows.Forms.ToolStripMenuItem mnuCerrarSesion;
        private System.Windows.Forms.Panel pnlCentro;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Button btnMarcarAsistencia;
    }
}

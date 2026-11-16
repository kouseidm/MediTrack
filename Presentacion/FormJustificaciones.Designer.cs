namespace Presentacion
{
    partial class FormJustificaciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lblPersonal = new System.Windows.Forms.Label();
            this.cmbPersonal = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblAusencia = new System.Windows.Forms.Label();
            this.dtpAusencia = new System.Windows.Forms.DateTimePicker();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnAprobar = new System.Windows.Forms.Button();
            this.btnRechazar = new System.Windows.Forms.Button();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.btnVerPendientes = new System.Windows.Forms.Button();
            this.btnRechazados = new System.Windows.Forms.Button();
            this.btnAprobados = new System.Windows.Forms.Button();
            this.btnVerTodo = new System.Windows.Forms.Button();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(194, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(560, 50);
            this.label1.TabIndex = 27;
            this.label1.Text = "JUSTIFICACIONES Y LICENCIAS";
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.lblPersonal);
            this.gbDatos.Controls.Add(this.cmbPersonal);
            this.gbDatos.Controls.Add(this.lblTipo);
            this.gbDatos.Controls.Add(this.cmbTipo);
            this.gbDatos.Controls.Add(this.lblAusencia);
            this.gbDatos.Controls.Add(this.dtpAusencia);
            this.gbDatos.Controls.Add(this.lblMotivo);
            this.gbDatos.Controls.Add(this.txtMotivo);
            this.gbDatos.Location = new System.Drawing.Point(8, 70);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(940, 150);
            this.gbDatos.TabIndex = 19;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "NUEVA JUSTIFICACION";
            // 
            // lblPersonal
            // 
            this.lblPersonal.AutoSize = true;
            this.lblPersonal.Location = new System.Drawing.Point(15, 33);
            this.lblPersonal.Name = "lblPersonal";
            this.lblPersonal.Size = new System.Drawing.Size(61, 13);
            this.lblPersonal.TabIndex = 0;
            this.lblPersonal.Text = "Trabajador:";
            // 
            // cmbPersonal
            // 
            this.cmbPersonal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPersonal.FormattingEnabled = true;
            this.cmbPersonal.Location = new System.Drawing.Point(130, 30);
            this.cmbPersonal.Name = "cmbPersonal";
            this.cmbPersonal.Size = new System.Drawing.Size(280, 21);
            this.cmbPersonal.TabIndex = 1;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(15, 69);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 2;
            this.lblTipo.Text = "Tipo:";
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(130, 66);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(200, 21);
            this.cmbTipo.TabIndex = 3;
            // 
            // lblAusencia
            // 
            this.lblAusencia.AutoSize = true;
            this.lblAusencia.Location = new System.Drawing.Point(15, 105);
            this.lblAusencia.Name = "lblAusencia";
            this.lblAusencia.Size = new System.Drawing.Size(86, 13);
            this.lblAusencia.TabIndex = 4;
            this.lblAusencia.Text = "Fecha ausencia:";
            // 
            // dtpAusencia
            // 
            this.dtpAusencia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAusencia.Location = new System.Drawing.Point(130, 102);
            this.dtpAusencia.Name = "dtpAusencia";
            this.dtpAusencia.Size = new System.Drawing.Size(130, 20);
            this.dtpAusencia.TabIndex = 5;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(470, 33);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(42, 13);
            this.lblMotivo.TabIndex = 6;
            this.lblMotivo.Text = "Motivo:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(473, 55);
            this.txtMotivo.MaxLength = 200;
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(447, 80);
            this.txtMotivo.TabIndex = 7;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRegistrar.Location = new System.Drawing.Point(8, 229);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(157, 32);
            this.btnRegistrar.TabIndex = 20;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnAprobar
            // 
            this.btnAprobar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnAprobar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAprobar.FlatAppearance.BorderSize = 0;
            this.btnAprobar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAprobar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAprobar.Location = new System.Drawing.Point(188, 229);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(150, 32);
            this.btnAprobar.TabIndex = 21;
            this.btnAprobar.Text = "Aprobar";
            this.btnAprobar.UseVisualStyleBackColor = false;
            this.btnAprobar.Click += new System.EventHandler(this.btnAprobar_Click);
            // 
            // btnRechazar
            // 
            this.btnRechazar.BackColor = System.Drawing.Color.DarkRed;
            this.btnRechazar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRechazar.FlatAppearance.BorderSize = 0;
            this.btnRechazar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRechazar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRechazar.Location = new System.Drawing.Point(361, 229);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(149, 32);
            this.btnRechazar.TabIndex = 22;
            this.btnRechazar.Text = "Rechazar";
            this.btnRechazar.UseVisualStyleBackColor = false;
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(578, 235);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(43, 13);
            this.lblFiltro.TabIndex = 23;
            this.lblFiltro.Text = "Estado:";
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltro.FormattingEnabled = true;
            this.cmbFiltro.Location = new System.Drawing.Point(638, 232);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new System.Drawing.Size(140, 21);
            this.cmbFiltro.TabIndex = 24;
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultar.FlatAppearance.BorderSize = 0;
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnConsultar.Location = new System.Drawing.Point(784, 229);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(164, 29);
            this.btnConsultar.TabIndex = 25;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.DefaultCellStyle = dataGridViewCellStyle12;
            this.grid.EnableHeadersVisualStyles = false;
            this.grid.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.grid.Location = new System.Drawing.Point(8, 279);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(940, 321);
            this.grid.TabIndex = 26;
            // 
            // btnVerPendientes
            // 
            this.btnVerPendientes.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnVerPendientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerPendientes.FlatAppearance.BorderSize = 0;
            this.btnVerPendientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerPendientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnVerPendientes.Location = new System.Drawing.Point(784, 606);
            this.btnVerPendientes.Name = "btnVerPendientes";
            this.btnVerPendientes.Size = new System.Drawing.Size(157, 21);
            this.btnVerPendientes.TabIndex = 28;
            this.btnVerPendientes.Text = "PENDIENTES";
            this.btnVerPendientes.UseVisualStyleBackColor = false;
            this.btnVerPendientes.Click += new System.EventHandler(this.btnVerPendientes_Click);
            // 
            // btnRechazados
            // 
            this.btnRechazados.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnRechazados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRechazados.FlatAppearance.BorderSize = 0;
            this.btnRechazados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRechazados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRechazados.Location = new System.Drawing.Point(621, 606);
            this.btnRechazados.Name = "btnRechazados";
            this.btnRechazados.Size = new System.Drawing.Size(157, 21);
            this.btnRechazados.TabIndex = 29;
            this.btnRechazados.Text = "RECHAZADOS";
            this.btnRechazados.UseVisualStyleBackColor = false;
            this.btnRechazados.Click += new System.EventHandler(this.btnRechazados_Click);
            // 
            // btnAprobados
            // 
            this.btnAprobados.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnAprobados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAprobados.FlatAppearance.BorderSize = 0;
            this.btnAprobados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAprobados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAprobados.Location = new System.Drawing.Point(458, 606);
            this.btnAprobados.Name = "btnAprobados";
            this.btnAprobados.Size = new System.Drawing.Size(157, 21);
            this.btnAprobados.TabIndex = 30;
            this.btnAprobados.Text = "APROBADOS";
            this.btnAprobados.UseVisualStyleBackColor = false;
            this.btnAprobados.Click += new System.EventHandler(this.btnAprobados_Click);
            // 
            // btnVerTodo
            // 
            this.btnVerTodo.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnVerTodo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerTodo.FlatAppearance.BorderSize = 0;
            this.btnVerTodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerTodo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnVerTodo.Location = new System.Drawing.Point(8, 606);
            this.btnVerTodo.Name = "btnVerTodo";
            this.btnVerTodo.Size = new System.Drawing.Size(157, 21);
            this.btnVerTodo.TabIndex = 31;
            this.btnVerTodo.Text = "VER TODOS";
            this.btnVerTodo.UseVisualStyleBackColor = false;
            this.btnVerTodo.Click += new System.EventHandler(this.btnVerTodo_Click);
            // 
            // FormJustificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 641);
            this.Controls.Add(this.btnVerTodo);
            this.Controls.Add(this.btnAprobados);
            this.Controls.Add(this.btnRechazados);
            this.Controls.Add(this.btnVerPendientes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnAprobar);
            this.Controls.Add(this.btnRechazar);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.cmbFiltro);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.grid);
            this.Name = "FormJustificaciones";
            this.Text = "FormJustificaciones";
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblPersonal;
        private System.Windows.Forms.ComboBox cmbPersonal;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblAusencia;
        private System.Windows.Forms.DateTimePicker dtpAusencia;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnAprobar;
        private System.Windows.Forms.Button btnRechazar;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.ComboBox cmbFiltro;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btnVerPendientes;
        private System.Windows.Forms.Button btnRechazados;
        private System.Windows.Forms.Button btnAprobados;
        private System.Windows.Forms.Button btnVerTodo;
    }
}
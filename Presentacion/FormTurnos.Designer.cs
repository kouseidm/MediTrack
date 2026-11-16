namespace Presentacion
{
    partial class FormTurnos
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
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnDesactivar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCreadoPor = new System.Windows.Forms.Label();
            this.lblCreadoEl = new System.Windows.Forms.Label();
            this.lblActualizadoPor = new System.Windows.Forms.Label();
            this.lblActualizadoEl = new System.Windows.Forms.Label();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblInicio = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFin = new System.Windows.Forms.Label();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.lblTolerancia = new System.Windows.Forms.Label();
            this.numTolerancia = new System.Windows.Forms.NumericUpDown();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.btnActivar = new System.Windows.Forms.Button();
            this.btnVerTodo = new System.Windows.Forms.Button();
            this.btnDesactivados = new System.Windows.Forms.Button();
            this.btnActivos = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTolerancia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(350, 9);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(398, 50);
            this.label1.TabIndex = 30;
            this.label1.Text = "GESTION DE TURNOS";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRegistrar.Location = new System.Drawing.Point(31, 228);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(269, 32);
            this.btnRegistrar.TabIndex = 27;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnActualizar.Location = new System.Drawing.Point(334, 228);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(269, 32);
            this.btnActualizar.TabIndex = 28;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.BackColor = System.Drawing.Color.Maroon;
            this.btnDesactivar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesactivar.FlatAppearance.BorderSize = 0;
            this.btnDesactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesactivar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDesactivar.Location = new System.Drawing.Point(636, 228);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(183, 32);
            this.btnDesactivar.TabIndex = 29;
            this.btnDesactivar.Text = "Desactivar";
            this.btnDesactivar.UseVisualStyleBackColor = false;
            this.btnDesactivar.Click += new System.EventHandler(this.btnDesactivar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblCreadoPor);
            this.groupBox1.Controls.Add(this.lblCreadoEl);
            this.groupBox1.Controls.Add(this.lblActualizadoPor);
            this.groupBox1.Controls.Add(this.lblActualizadoEl);
            this.groupBox1.Location = new System.Drawing.Point(699, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 145);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AUDITORIA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(163, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Actualizado el";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(163, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Actualizado por:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Creado el";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Creado por:";
            // 
            // lblCreadoPor
            // 
            this.lblCreadoPor.AutoSize = true;
            this.lblCreadoPor.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreadoPor.Location = new System.Drawing.Point(15, 57);
            this.lblCreadoPor.Name = "lblCreadoPor";
            this.lblCreadoPor.Size = new System.Drawing.Size(13, 17);
            this.lblCreadoPor.TabIndex = 30;
            this.lblCreadoPor.Text = "-";
            // 
            // lblCreadoEl
            // 
            this.lblCreadoEl.AutoSize = true;
            this.lblCreadoEl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreadoEl.Location = new System.Drawing.Point(15, 108);
            this.lblCreadoEl.Name = "lblCreadoEl";
            this.lblCreadoEl.Size = new System.Drawing.Size(13, 17);
            this.lblCreadoEl.TabIndex = 31;
            this.lblCreadoEl.Text = "-";
            // 
            // lblActualizadoPor
            // 
            this.lblActualizadoPor.AutoSize = true;
            this.lblActualizadoPor.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualizadoPor.Location = new System.Drawing.Point(163, 57);
            this.lblActualizadoPor.Name = "lblActualizadoPor";
            this.lblActualizadoPor.Size = new System.Drawing.Size(13, 17);
            this.lblActualizadoPor.TabIndex = 32;
            this.lblActualizadoPor.Text = "-";
            // 
            // lblActualizadoEl
            // 
            this.lblActualizadoEl.AutoSize = true;
            this.lblActualizadoEl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualizadoEl.Location = new System.Drawing.Point(163, 108);
            this.lblActualizadoEl.Name = "lblActualizadoEl";
            this.lblActualizadoEl.Size = new System.Drawing.Size(13, 17);
            this.lblActualizadoEl.TabIndex = 33;
            this.lblActualizadoEl.Text = "-";
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.lblNombre);
            this.gbDatos.Controls.Add(this.txtNombre);
            this.gbDatos.Controls.Add(this.lblInicio);
            this.gbDatos.Controls.Add(this.dtpInicio);
            this.gbDatos.Controls.Add(this.lblFin);
            this.gbDatos.Controls.Add(this.dtpFin);
            this.gbDatos.Controls.Add(this.lblTolerancia);
            this.gbDatos.Controls.Add(this.numTolerancia);
            this.gbDatos.Controls.Add(this.lblDescripcion);
            this.gbDatos.Controls.Add(this.txtDescripcion);
            this.gbDatos.Location = new System.Drawing.Point(13, 70);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(680, 145);
            this.gbDatos.TabIndex = 24;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "DATOS DEL TURNO";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(15, 33);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(130, 30);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Location = new System.Drawing.Point(15, 69);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(60, 13);
            this.lblInicio.TabIndex = 2;
            this.lblInicio.Text = "Hora inicio:";
            // 
            // dtpInicio
            // 
            this.dtpInicio.CustomFormat = "HH:mm";
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicio.Location = new System.Drawing.Point(130, 66);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.ShowUpDown = true;
            this.dtpInicio.Size = new System.Drawing.Size(80, 20);
            this.dtpInicio.TabIndex = 3;
            // 
            // lblFin
            // 
            this.lblFin.AutoSize = true;
            this.lblFin.Location = new System.Drawing.Point(15, 105);
            this.lblFin.Name = "lblFin";
            this.lblFin.Size = new System.Drawing.Size(47, 13);
            this.lblFin.TabIndex = 4;
            this.lblFin.Text = "Hora fin:";
            // 
            // dtpFin
            // 
            this.dtpFin.CustomFormat = "HH:mm";
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFin.Location = new System.Drawing.Point(130, 102);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.ShowUpDown = true;
            this.dtpFin.Size = new System.Drawing.Size(80, 20);
            this.dtpFin.TabIndex = 5;
            // 
            // lblTolerancia
            // 
            this.lblTolerancia.AutoSize = true;
            this.lblTolerancia.Location = new System.Drawing.Point(360, 33);
            this.lblTolerancia.Name = "lblTolerancia";
            this.lblTolerancia.Size = new System.Drawing.Size(85, 13);
            this.lblTolerancia.TabIndex = 6;
            this.lblTolerancia.Text = "Tolerancia (min):";
            // 
            // numTolerancia
            // 
            this.numTolerancia.Location = new System.Drawing.Point(490, 30);
            this.numTolerancia.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numTolerancia.Name = "numTolerancia";
            this.numTolerancia.Size = new System.Drawing.Size(80, 20);
            this.numTolerancia.TabIndex = 7;
            this.numTolerancia.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(360, 69);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 8;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(490, 66);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(170, 20);
            this.txtDescripcion.TabIndex = 9;
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
            this.grid.Location = new System.Drawing.Point(13, 273);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(1052, 344);
            this.grid.TabIndex = 25;
            this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);
            // 
            // btnActivar
            // 
            this.btnActivar.BackColor = System.Drawing.Color.Green;
            this.btnActivar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActivar.FlatAppearance.BorderSize = 0;
            this.btnActivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnActivar.Location = new System.Drawing.Point(851, 228);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(183, 32);
            this.btnActivar.TabIndex = 31;
            this.btnActivar.Text = "Activar";
            this.btnActivar.UseVisualStyleBackColor = false;
            this.btnActivar.Click += new System.EventHandler(this.btnActivar_Click);
            // 
            // btnVerTodo
            // 
            this.btnVerTodo.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnVerTodo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerTodo.FlatAppearance.BorderSize = 0;
            this.btnVerTodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerTodo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnVerTodo.Location = new System.Drawing.Point(13, 623);
            this.btnVerTodo.Name = "btnVerTodo";
            this.btnVerTodo.Size = new System.Drawing.Size(157, 21);
            this.btnVerTodo.TabIndex = 38;
            this.btnVerTodo.Text = "VER TODOS";
            this.btnVerTodo.UseVisualStyleBackColor = false;
            this.btnVerTodo.Click += new System.EventHandler(this.btnVerTodo_Click);
            // 
            // btnDesactivados
            // 
            this.btnDesactivados.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnDesactivados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesactivados.FlatAppearance.BorderSize = 0;
            this.btnDesactivados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesactivados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDesactivados.Location = new System.Drawing.Point(745, 623);
            this.btnDesactivados.Name = "btnDesactivados";
            this.btnDesactivados.Size = new System.Drawing.Size(157, 21);
            this.btnDesactivados.TabIndex = 37;
            this.btnDesactivados.Text = "DESACTIVADOS";
            this.btnDesactivados.UseVisualStyleBackColor = false;
            this.btnDesactivados.Click += new System.EventHandler(this.btnDesactivados_Click);
            // 
            // btnActivos
            // 
            this.btnActivos.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnActivos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActivos.FlatAppearance.BorderSize = 0;
            this.btnActivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnActivos.Location = new System.Drawing.Point(908, 623);
            this.btnActivos.Name = "btnActivos";
            this.btnActivos.Size = new System.Drawing.Size(157, 21);
            this.btnActivos.TabIndex = 36;
            this.btnActivos.Text = "ACTIVOS";
            this.btnActivos.UseVisualStyleBackColor = false;
            this.btnActivos.Click += new System.EventHandler(this.btnActivos_Click);
            // 
            // FormTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 654);
            this.Controls.Add(this.btnVerTodo);
            this.Controls.Add(this.btnDesactivados);
            this.Controls.Add(this.btnActivos);
            this.Controls.Add(this.btnActivar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnDesactivar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.grid);
            this.Name = "FormTurnos";
            this.Text = "FormTurnos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTolerancia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnDesactivar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCreadoPor;
        private System.Windows.Forms.Label lblCreadoEl;
        private System.Windows.Forms.Label lblActualizadoPor;
        private System.Windows.Forms.Label lblActualizadoEl;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label lblFin;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.Label lblTolerancia;
        private System.Windows.Forms.NumericUpDown numTolerancia;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.Button btnVerTodo;
        private System.Windows.Forms.Button btnDesactivados;
        private System.Windows.Forms.Button btnActivos;
    }
}
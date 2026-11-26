namespace Presentacion
{
    partial class FormJornada
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.gbProgramacion = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.lblPersonal = new System.Windows.Forms.Label();
            this.cmbPersonal = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.btnVerJornadas = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnProgramar = new System.Windows.Forms.Button();
            this.btnMasivo = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.btnVerTodo = new System.Windows.Forms.Button();
            this.btnVerTodos = new System.Windows.Forms.Button();
            this.gbProgramacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(182, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(464, 50);
            this.label1.TabIndex = 20;
            this.label1.Text = "PROGRAMAR JORNADAS";
            // 
            // gbProgramacion
            // 
            this.gbProgramacion.Controls.Add(this.label2);
            this.gbProgramacion.Controls.Add(this.cmbArea);
            this.gbProgramacion.Controls.Add(this.lblPersonal);
            this.gbProgramacion.Controls.Add(this.cmbPersonal);
            this.gbProgramacion.Controls.Add(this.lblFecha);
            this.gbProgramacion.Controls.Add(this.btnVerJornadas);
            this.gbProgramacion.Controls.Add(this.dtpFecha);
            this.gbProgramacion.Controls.Add(this.btnProgramar);
            this.gbProgramacion.Controls.Add(this.btnMasivo);
            this.gbProgramacion.Location = new System.Drawing.Point(25, 77);
            this.gbProgramacion.Name = "gbProgramacion";
            this.gbProgramacion.Size = new System.Drawing.Size(810, 167);
            this.gbProgramacion.TabIndex = 18;
            this.gbProgramacion.TabStop = false;
            this.gbProgramacion.Text = "Programación";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Area:";
            // 
            // cmbArea
            // 
            this.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(100, 68);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(424, 21);
            this.cmbArea.TabIndex = 8;
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
            this.cmbPersonal.Location = new System.Drawing.Point(100, 30);
            this.cmbPersonal.Name = "cmbPersonal";
            this.cmbPersonal.Size = new System.Drawing.Size(424, 21);
            this.cmbPersonal.TabIndex = 1;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(616, 30);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha:";
            // 
            // btnVerJornadas
            // 
            this.btnVerJornadas.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnVerJornadas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerJornadas.FlatAppearance.BorderSize = 0;
            this.btnVerJornadas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerJornadas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerJornadas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnVerJornadas.Location = new System.Drawing.Point(554, 112);
            this.btnVerJornadas.Name = "btnVerJornadas";
            this.btnVerJornadas.Size = new System.Drawing.Size(235, 32);
            this.btnVerJornadas.TabIndex = 6;
            this.btnVerJornadas.Text = "Ver jornadas";
            this.btnVerJornadas.UseVisualStyleBackColor = false;
            this.btnVerJornadas.Click += new System.EventHandler(this.btnVerJornadas_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(671, 27);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(118, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // btnProgramar
            // 
            this.btnProgramar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnProgramar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProgramar.FlatAppearance.BorderSize = 0;
            this.btnProgramar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProgramar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnProgramar.Location = new System.Drawing.Point(18, 112);
            this.btnProgramar.Name = "btnProgramar";
            this.btnProgramar.Size = new System.Drawing.Size(235, 32);
            this.btnProgramar.TabIndex = 4;
            this.btnProgramar.Text = "Programar jornada";
            this.btnProgramar.UseVisualStyleBackColor = false;
            this.btnProgramar.Click += new System.EventHandler(this.btnProgramar_Click);
            // 
            // btnMasivo
            // 
            this.btnMasivo.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnMasivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMasivo.FlatAppearance.BorderSize = 0;
            this.btnMasivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMasivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnMasivo.Location = new System.Drawing.Point(289, 112);
            this.btnMasivo.Name = "btnMasivo";
            this.btnMasivo.Size = new System.Drawing.Size(235, 32);
            this.btnMasivo.TabIndex = 5;
            this.btnMasivo.Text = "Programar a todos";
            this.btnMasivo.UseVisualStyleBackColor = false;
            this.btnMasivo.Click += new System.EventHandler(this.btnMasivo_Click);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.DefaultCellStyle = dataGridViewCellStyle3;
            this.grid.EnableHeadersVisualStyles = false;
            this.grid.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.grid.Location = new System.Drawing.Point(25, 250);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(810, 369);
            this.grid.TabIndex = 19;
            // 
            // btnVerTodo
            // 
            this.btnVerTodo.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnVerTodo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerTodo.FlatAppearance.BorderSize = 0;
            this.btnVerTodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerTodo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnVerTodo.Location = new System.Drawing.Point(-357, 625);
            this.btnVerTodo.Name = "btnVerTodo";
            this.btnVerTodo.Size = new System.Drawing.Size(157, 21);
            this.btnVerTodo.TabIndex = 38;
            this.btnVerTodo.Text = "VER TODOS";
            this.btnVerTodo.UseVisualStyleBackColor = false;
            // 
            // btnVerTodos
            // 
            this.btnVerTodos.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnVerTodos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerTodos.FlatAppearance.BorderSize = 0;
            this.btnVerTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerTodos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnVerTodos.Location = new System.Drawing.Point(675, 625);
            this.btnVerTodos.Name = "btnVerTodos";
            this.btnVerTodos.Size = new System.Drawing.Size(157, 21);
            this.btnVerTodos.TabIndex = 36;
            this.btnVerTodos.Text = "VER TODOS";
            this.btnVerTodos.UseVisualStyleBackColor = false;
            this.btnVerTodos.Click += new System.EventHandler(this.btnVerTodos_Click);
            // 
            // FormJornada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 666);
            this.Controls.Add(this.btnVerTodo);
            this.Controls.Add(this.btnVerTodos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbProgramacion);
            this.Controls.Add(this.grid);
            this.Name = "FormJornada";
            this.Text = "FormJornada";
            this.gbProgramacion.ResumeLayout(false);
            this.gbProgramacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbProgramacion;
        private System.Windows.Forms.Label lblPersonal;
        private System.Windows.Forms.ComboBox cmbPersonal;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Button btnVerJornadas;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnProgramar;
        private System.Windows.Forms.Button btnMasivo;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Button btnVerTodo;
        private System.Windows.Forms.Button btnVerTodos;
    }
}
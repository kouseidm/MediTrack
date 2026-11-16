namespace Presentacion
{
    partial class FormMarcarAsistencia
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
            this.components = new System.ComponentModel.Container();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblReloj = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnIngreso = new System.Windows.Forms.Button();
            this.btnSalida = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.timerReloj = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTitulo.Location = new System.Drawing.Point(0, 30);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(520, 60);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "MARCAR ASISTENCIA";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblReloj
            //
            this.lblReloj.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.lblReloj.ForeColor = System.Drawing.Color.DimGray;
            this.lblReloj.Location = new System.Drawing.Point(0, 100);
            this.lblReloj.Name = "lblReloj";
            this.lblReloj.Size = new System.Drawing.Size(520, 70);
            this.lblReloj.TabIndex = 1;
            this.lblReloj.Text = "00:00:00";
            this.lblReloj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblFecha
            //
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFecha.ForeColor = System.Drawing.Color.DimGray;
            this.lblFecha.Location = new System.Drawing.Point(0, 175);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(520, 24);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "fecha";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblCodigo
            //
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCodigo.Location = new System.Drawing.Point(100, 230);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(130, 19);
            this.lblCodigo.TabIndex = 3;
            this.lblCodigo.Text = "Código del trabajador";
            //
            // txtCodigo
            //
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCodigo.Location = new System.Drawing.Point(100, 255);
            this.txtCodigo.MaxLength = 50;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(320, 29);
            this.txtCodigo.TabIndex = 0;
            //
            // btnIngreso
            //
            this.btnIngreso.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnIngreso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngreso.FlatAppearance.BorderSize = 0;
            this.btnIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngreso.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIngreso.ForeColor = System.Drawing.Color.White;
            this.btnIngreso.Location = new System.Drawing.Point(100, 310);
            this.btnIngreso.Name = "btnIngreso";
            this.btnIngreso.Size = new System.Drawing.Size(155, 44);
            this.btnIngreso.TabIndex = 1;
            this.btnIngreso.Text = "Registrar ingreso";
            this.btnIngreso.UseVisualStyleBackColor = false;
            this.btnIngreso.Click += new System.EventHandler(this.btnIngreso_Click);
            //
            // btnSalida
            //
            this.btnSalida.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSalida.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalida.FlatAppearance.BorderSize = 0;
            this.btnSalida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalida.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSalida.ForeColor = System.Drawing.Color.White;
            this.btnSalida.Location = new System.Drawing.Point(265, 310);
            this.btnSalida.Name = "btnSalida";
            this.btnSalida.Size = new System.Drawing.Size(155, 44);
            this.btnSalida.TabIndex = 2;
            this.btnSalida.Text = "Registrar salida";
            this.btnSalida.UseVisualStyleBackColor = false;
            this.btnSalida.Click += new System.EventHandler(this.btnSalida_Click);
            //
            // lblMensaje
            //
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMensaje.Location = new System.Drawing.Point(40, 375);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(440, 70);
            this.lblMensaje.TabIndex = 7;
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            //
            // timerReloj
            //
            this.timerReloj.Enabled = true;
            this.timerReloj.Interval = 1000;
            this.timerReloj.Tick += new System.EventHandler(this.timerReloj_Tick);
            //
            // FrmMarcarAsistencia
            //
            this.AcceptButton = this.btnIngreso;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(520, 470);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnSalida);
            this.Controls.Add(this.btnIngreso);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblReloj);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMarcarAsistencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MediTrack - Marcar asistencia";
            this.Load += new System.EventHandler(this.FrmMarcarAsistencia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblReloj;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnIngreso;
        private System.Windows.Forms.Button btnSalida;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Timer timerReloj;
    }
}

namespace Presentacion
{
    partial class FormLogin
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.lnkSalir = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTitulo.Location = new System.Drawing.Point(0, 40);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(400, 70);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "MediTrack";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.Location = new System.Drawing.Point(0, 112);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(400, 24);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Gestor de Asistencias";
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblUsuario
            //
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUsuario.Location = new System.Drawing.Point(50, 160);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(55, 19);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Usuario";
            //
            // txtUsuario
            //
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtUsuario.Location = new System.Drawing.Point(50, 185);
            this.txtUsuario.MaxLength = 50;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(300, 29);
            this.txtUsuario.TabIndex = 0;
            //
            // lblClave
            //
            this.lblClave.AutoSize = true;
            this.lblClave.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblClave.Location = new System.Drawing.Point(50, 230);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(78, 19);
            this.lblClave.TabIndex = 4;
            this.lblClave.Text = "Contraseña";
            //
            // txtClave
            //
            this.txtClave.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtClave.Location = new System.Drawing.Point(50, 255);
            this.txtClave.MaxLength = 100;
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(300, 29);
            this.txtClave.TabIndex = 1;
            this.txtClave.UseSystemPasswordChar = true;
            //
            // btnIngresar
            //
            this.btnIngresar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Location = new System.Drawing.Point(50, 315);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(300, 44);
            this.btnIngresar.TabIndex = 2;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            //
            // lnkSalir
            //
            this.lnkSalir.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lnkSalir.LinkColor = System.Drawing.Color.DimGray;
            this.lnkSalir.Location = new System.Drawing.Point(0, 380);
            this.lnkSalir.Name = "lnkSalir";
            this.lnkSalir.Size = new System.Drawing.Size(400, 24);
            this.lnkSalir.TabIndex = 3;
            this.lnkSalir.TabStop = true;
            this.lnkSalir.Text = "Salir";
            this.lnkSalir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkSalir.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSalir_LinkClicked);
            //
            // FrmLogin
            //
            this.AcceptButton = this.btnIngresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 440);
            this.Controls.Add(this.lnkSalir);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.lblClave);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MediTrack - Inicio de sesión";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.LinkLabel lnkSalir;
    }
}

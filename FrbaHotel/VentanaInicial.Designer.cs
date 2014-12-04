namespace FrbaHotel
{
    partial class ventanaInicial
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
            this.botonLogin = new System.Windows.Forms.Button();
            this.mensajePrincipal = new System.Windows.Forms.Label();
            this.mensajeOBien = new System.Windows.Forms.Label();
            this.botonGuest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botonLogin
            // 
            this.botonLogin.Location = new System.Drawing.Point(99, 65);
            this.botonLogin.Name = "botonLogin";
            this.botonLogin.Size = new System.Drawing.Size(75, 23);
            this.botonLogin.TabIndex = 0;
            this.botonLogin.Text = "Inicie sesión";
            this.botonLogin.UseVisualStyleBackColor = true;
            this.botonLogin.Click += new System.EventHandler(this.botonLogin_Click);
            
            // 
            // mensajePrincipal
            // 
            this.mensajePrincipal.AutoSize = true;
            this.mensajePrincipal.Location = new System.Drawing.Point(35, 25);
            this.mensajePrincipal.Name = "mensajePrincipal";
            this.mensajePrincipal.Size = new System.Drawing.Size(208, 13);
            this.mensajePrincipal.TabIndex = 1;
            this.mensajePrincipal.Text = "Bienvenido a G_N, administración hotelera";
            // 
            // mensajeOBien
            // 
            this.mensajeOBien.AutoSize = true;
            this.mensajeOBien.Location = new System.Drawing.Point(107, 135);
            this.mensajeOBien.Name = "mensajeOBien";
            this.mensajeOBien.Size = new System.Drawing.Size(50, 13);
            this.mensajeOBien.TabIndex = 2;
            this.mensajeOBien.Text = "O bien....";
            // 
            // botonGuest
            // 
            this.botonGuest.Location = new System.Drawing.Point(57, 165);
            this.botonGuest.Name = "botonGuest";
            this.botonGuest.Size = new System.Drawing.Size(173, 23);
            this.botonGuest.TabIndex = 3;
            this.botonGuest.Text = "Ingrese al sistema como invitado";
            this.botonGuest.UseVisualStyleBackColor = true;
            this.botonGuest.Click += new System.EventHandler(this.botonGuest_Click);
            // 
            // ventanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 228);
            this.Controls.Add(this.botonGuest);
            this.Controls.Add(this.mensajeOBien);
            this.Controls.Add(this.mensajePrincipal);
            this.Controls.Add(this.botonLogin);
            this.Name = "ventanaPrincipal";
            this.Text = "Administración Hotelera";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonLogin;
        private System.Windows.Forms.Label mensajePrincipal;
        private System.Windows.Forms.Label mensajeOBien;
        private System.Windows.Forms.Button botonGuest;
    }
}


namespace FrbaHotel
{
    partial class ventanaPrincipal
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
            this.botonRoles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botonRoles
            // 
            this.botonRoles.Location = new System.Drawing.Point(95, 63);
            this.botonRoles.Name = "botonRoles";
            this.botonRoles.Size = new System.Drawing.Size(75, 23);
            this.botonRoles.TabIndex = 0;
            this.botonRoles.Text = "ABM Roles";
            this.botonRoles.UseVisualStyleBackColor = true;
            this.botonRoles.Click += new System.EventHandler(this.botonRoles_Click);
            // 
            // ventanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.botonRoles);
            this.Name = "ventanaPrincipal";
            this.Text = "Administración Hotelera";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botonRoles;
    }
}


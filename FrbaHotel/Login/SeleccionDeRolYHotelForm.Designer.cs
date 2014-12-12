namespace FrbaHotel.Login
{
    partial class SeleccionDeRolYHotelForm
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
            this.mensajeRolLabel = new System.Windows.Forms.Label();
            this.rolesCombo = new System.Windows.Forms.ComboBox();
            this.botonContinuar = new System.Windows.Forms.Button();
            this.mensajeHotelLabel = new System.Windows.Forms.Label();
            this.hotelesCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // mensajeRolLabel
            // 
            this.mensajeRolLabel.AutoSize = true;
            this.mensajeRolLabel.Location = new System.Drawing.Point(39, 23);
            this.mensajeRolLabel.Name = "mensajeRolLabel";
            this.mensajeRolLabel.Size = new System.Drawing.Size(216, 13);
            this.mensajeRolLabel.TabIndex = 0;
            this.mensajeRolLabel.Text = "Seleccione el rol con el que desea ingresar: ";
            // 
            // rolesCombo
            // 
            this.rolesCombo.FormattingEnabled = true;
            this.rolesCombo.Location = new System.Drawing.Point(62, 52);
            this.rolesCombo.Name = "rolesCombo";
            this.rolesCombo.Size = new System.Drawing.Size(162, 21);
            this.rolesCombo.TabIndex = 1;
            // 
            // botonContinuar
            // 
            this.botonContinuar.Location = new System.Drawing.Point(100, 185);
            this.botonContinuar.Name = "botonContinuar";
            this.botonContinuar.Size = new System.Drawing.Size(75, 23);
            this.botonContinuar.TabIndex = 2;
            this.botonContinuar.Text = "Continuar";
            this.botonContinuar.UseVisualStyleBackColor = true;
            this.botonContinuar.Click += new System.EventHandler(this.botonContinuar_Click);
            // 
            // mensajeHotelLabel
            // 
            this.mensajeHotelLabel.AutoSize = true;
            this.mensajeHotelLabel.Location = new System.Drawing.Point(39, 104);
            this.mensajeHotelLabel.Name = "mensajeHotelLabel";
            this.mensajeHotelLabel.Size = new System.Drawing.Size(215, 13);
            this.mensajeHotelLabel.TabIndex = 3;
            this.mensajeHotelLabel.Text = "Seleccione el hotel en el que desea operar: ";
         
            // 
            // hotelesCombo
            // 
            this.hotelesCombo.FormattingEnabled = true;
            this.hotelesCombo.Location = new System.Drawing.Point(67, 132);
            this.hotelesCombo.Name = "hotelesCombo";
            this.hotelesCombo.Size = new System.Drawing.Size(162, 21);
            this.hotelesCombo.TabIndex = 4;
           
            // 
            // SeleccionDeRolYHotelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 223);
            this.Controls.Add(this.hotelesCombo);
            this.Controls.Add(this.mensajeHotelLabel);
            this.Controls.Add(this.botonContinuar);
            this.Controls.Add(this.rolesCombo);
            this.Controls.Add(this.mensajeRolLabel);
            this.Name = "SeleccionDeRolYHotelForm";
            this.Text = "Rol y Hotel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mensajeRolLabel;
        private System.Windows.Forms.ComboBox rolesCombo;
        private System.Windows.Forms.Button botonContinuar;
        private System.Windows.Forms.Label mensajeHotelLabel;
        private System.Windows.Forms.ComboBox hotelesCombo;
    }
}
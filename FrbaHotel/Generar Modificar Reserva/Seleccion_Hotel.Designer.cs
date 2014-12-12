namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class Seleccion_Hotel
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
            this.hotelesCombo = new System.Windows.Forms.ComboBox();
            this.mensajeHotelLabel = new System.Windows.Forms.Label();
            this.botonContinuar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hotelesCombo
            // 
            this.hotelesCombo.FormattingEnabled = true;
            this.hotelesCombo.Location = new System.Drawing.Point(38, 43);
            this.hotelesCombo.Name = "hotelesCombo";
            this.hotelesCombo.Size = new System.Drawing.Size(212, 21);
            this.hotelesCombo.TabIndex = 7;
            // 
            // mensajeHotelLabel
            // 
            this.mensajeHotelLabel.AutoSize = true;
            this.mensajeHotelLabel.Location = new System.Drawing.Point(35, 15);
            this.mensajeHotelLabel.Name = "mensajeHotelLabel";
            this.mensajeHotelLabel.Size = new System.Drawing.Size(215, 13);
            this.mensajeHotelLabel.TabIndex = 6;
            this.mensajeHotelLabel.Text = "Seleccione el hotel en el que desea operar: ";
            // 
            // botonContinuar
            // 
            this.botonContinuar.Location = new System.Drawing.Point(96, 70);
            this.botonContinuar.Name = "botonContinuar";
            this.botonContinuar.Size = new System.Drawing.Size(75, 23);
            this.botonContinuar.TabIndex = 5;
            this.botonContinuar.Text = "Continuar";
            this.botonContinuar.UseVisualStyleBackColor = true;
            this.botonContinuar.Click += new System.EventHandler(this.botonContinuar_Click);
            // 
            // Seleccion_Hotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 104);
            this.Controls.Add(this.hotelesCombo);
            this.Controls.Add(this.mensajeHotelLabel);
            this.Controls.Add(this.botonContinuar);
            this.Name = "Seleccion_Hotel";
            this.Text = "Seleccion_Hotel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox hotelesCombo;
        private System.Windows.Forms.Label mensajeHotelLabel;
        private System.Windows.Forms.Button botonContinuar;
    }
}
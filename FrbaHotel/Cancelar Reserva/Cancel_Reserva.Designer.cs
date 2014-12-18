namespace FrbaHotel.Cancelar_Reserva
{
    partial class Cancel_Reserva
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
            this.label1 = new System.Windows.Forms.Label();
            this.motivoTextbox = new System.Windows.Forms.TextBox();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Motivo de cancelacion: ";
            // 
            // motivoTextbox
            // 
            this.motivoTextbox.Location = new System.Drawing.Point(141, 13);
            this.motivoTextbox.Name = "motivoTextbox";
            this.motivoTextbox.Size = new System.Drawing.Size(324, 20);
            this.motivoTextbox.TabIndex = 1;
            // 
            // botonCancelar
            // 
            this.botonCancelar.Location = new System.Drawing.Point(478, 12);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(100, 23);
            this.botonCancelar.TabIndex = 2;
            this.botonCancelar.Text = "Cancelar reserva";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // Cancelar_Reserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 50);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.motivoTextbox);
            this.Controls.Add(this.label1);
            this.Name = "Cancelar_Reserva";
            this.Text = "Cancelacion de reserva";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox motivoTextbox;
        private System.Windows.Forms.Button botonCancelar;
    }
}
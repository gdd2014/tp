namespace FrbaHotel.Registrar_Consumible
{
    partial class Elegir_Estadia
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
            this.codReservaTextbox = new System.Windows.Forms.TextBox();
            this.botonContinuar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // codReservaTextbox
            // 
            this.codReservaTextbox.Location = new System.Drawing.Point(135, 12);
            this.codReservaTextbox.Name = "codReservaTextbox";
            this.codReservaTextbox.Size = new System.Drawing.Size(100, 20);
            this.codReservaTextbox.TabIndex = 11;
            this.codReservaTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);

            // 
            // botonContinuar
            // 
            this.botonContinuar.Location = new System.Drawing.Point(86, 43);
            this.botonContinuar.Name = "botonContinuar";
            this.botonContinuar.Size = new System.Drawing.Size(108, 23);
            this.botonContinuar.TabIndex = 9;
            this.botonContinuar.Text = "Continuar";
            this.botonContinuar.UseVisualStyleBackColor = true;
            this.botonContinuar.Click += new System.EventHandler(this.botonContinuar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Código de reserva: ";
            // 
            // Elegir_Estadia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 78);
            this.Controls.Add(this.codReservaTextbox);
            this.Controls.Add(this.botonContinuar);
            this.Controls.Add(this.label1);
            this.Name = "Elegir_Estadia";
            this.Text = "Elegir_Estadia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox codReservaTextbox;
        private System.Windows.Forms.Button botonContinuar;
        private System.Windows.Forms.Label label1;
    }
}
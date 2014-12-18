namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class Admin_Reservas
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
            this.botonGenReserva = new System.Windows.Forms.Button();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.botonModificar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.codReservaTextbox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // botonGenReserva
            // 
            this.botonGenReserva.Location = new System.Drawing.Point(72, 21);
            this.botonGenReserva.Name = "botonGenReserva";
            this.botonGenReserva.Size = new System.Drawing.Size(132, 23);
            this.botonGenReserva.TabIndex = 0;
            this.botonGenReserva.Text = "Generar nueva reserva";
            this.botonGenReserva.UseVisualStyleBackColor = true;
            this.botonGenReserva.Click += new System.EventHandler(this.botonGenReserva_Click);
            // 
            // botonCancelar
            // 
            this.botonCancelar.Location = new System.Drawing.Point(8, 51);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(108, 23);
            this.botonCancelar.TabIndex = 1;
            this.botonCancelar.Text = "Cancelar reserva";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // botonModificar
            // 
            this.botonModificar.Location = new System.Drawing.Point(133, 51);
            this.botonModificar.Name = "botonModificar";
            this.botonModificar.Size = new System.Drawing.Size(104, 23);
            this.botonModificar.TabIndex = 2;
            this.botonModificar.Text = "Modificar reserva";
            this.botonModificar.UseVisualStyleBackColor = true;
            this.botonModificar.Click += new System.EventHandler(this.botonModificar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Código de reserva: ";
            // 
            // codReservaTextbox
            // 
            this.codReservaTextbox.Location = new System.Drawing.Point(122, 22);
            this.codReservaTextbox.Name = "codReservaTextbox";
            this.codReservaTextbox.Size = new System.Drawing.Size(100, 20);
            this.codReservaTextbox.TabIndex = 4;
            this.codReservaTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.botonModificar);
            this.groupBox1.Controls.Add(this.codReservaTextbox);
            this.groupBox1.Controls.Add(this.botonCancelar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 87);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reservas existentes";
            // 
            // Admin_Reservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 177);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.botonGenReserva);
            this.Name = "Admin_Reservas";
            this.Text = "Administracion de reservas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botonGenReserva;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Button botonModificar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox codReservaTextbox;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
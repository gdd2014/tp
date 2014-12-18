namespace FrbaHotel.Registrar_Estadia
{
    partial class Admin_Estadias
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
            this.botonCheckout = new System.Windows.Forms.Button();
            this.codReservaTextbox = new System.Windows.Forms.TextBox();
            this.botonCheckin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // botonCheckout
            // 
            this.botonCheckout.Location = new System.Drawing.Point(146, 48);
            this.botonCheckout.Name = "botonCheckout";
            this.botonCheckout.Size = new System.Drawing.Size(112, 23);
            this.botonCheckout.TabIndex = 6;
            this.botonCheckout.Text = "Informar checkout";
            this.botonCheckout.UseVisualStyleBackColor = true;
            this.botonCheckout.Click += new System.EventHandler(this.botonCheckout_Click);
            // 
            // codReservaTextbox
            // 
            this.codReservaTextbox.Location = new System.Drawing.Point(145, 16);
            this.codReservaTextbox.Name = "codReservaTextbox";
            this.codReservaTextbox.Size = new System.Drawing.Size(100, 20);
            this.codReservaTextbox.TabIndex = 8;
            this.codReservaTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
           
            // 
            // botonCheckin
            // 
            this.botonCheckin.Location = new System.Drawing.Point(21, 48);
            this.botonCheckin.Name = "botonCheckin";
            this.botonCheckin.Size = new System.Drawing.Size(108, 23);
            this.botonCheckin.TabIndex = 5;
            this.botonCheckin.Text = "Registrar checkin";
            this.botonCheckin.UseVisualStyleBackColor = true;
            this.botonCheckin.Click += new System.EventHandler(this.botonCheckin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Código de reserva: ";
            // 
            // Admin_Estadias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 89);
            this.Controls.Add(this.botonCheckout);
            this.Controls.Add(this.codReservaTextbox);
            this.Controls.Add(this.botonCheckin);
            this.Controls.Add(this.label1);
            this.Name = "Admin_Estadias";
            this.Text = "Administración de estadías";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonCheckout;
        private System.Windows.Forms.TextBox codReservaTextbox;
        private System.Windows.Forms.Button botonCheckin;
        private System.Windows.Forms.Label label1;
    }
}
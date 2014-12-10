namespace FrbaHotel.ABM_de_Hotel
{
    partial class B_Hotel
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.desdeDTP = new System.Windows.Forms.DateTimePicker();
            this.hastaDTP = new System.Windows.Forms.DateTimePicker();
            this.motivoTextbox = new System.Windows.Forms.TextBox();
            this.botonCerrarHotel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desde: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hasta: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(349, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Motivo: ";
            // 
            // desdeDTP
            // 
            this.desdeDTP.CustomFormat = "dd/MM/yyyy";
            this.desdeDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.desdeDTP.Location = new System.Drawing.Point(57, 7);
            this.desdeDTP.Name = "desdeDTP";
            this.desdeDTP.Size = new System.Drawing.Size(109, 20);
            this.desdeDTP.TabIndex = 17;
            // 
            // hastaDTP
            // 
            this.hastaDTP.CustomFormat = "dd/MM/yyyy";
            this.hastaDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.hastaDTP.Location = new System.Drawing.Point(223, 7);
            this.hastaDTP.Name = "hastaDTP";
            this.hastaDTP.Size = new System.Drawing.Size(109, 20);
            this.hastaDTP.TabIndex = 18;
            // 
            // motivoTextbox
            // 
            this.motivoTextbox.Location = new System.Drawing.Point(400, 7);
            this.motivoTextbox.Name = "motivoTextbox";
            this.motivoTextbox.Size = new System.Drawing.Size(299, 20);
            this.motivoTextbox.TabIndex = 19;
            // 
            // botonCerrarHotel
            // 
            this.botonCerrarHotel.Location = new System.Drawing.Point(720, 7);
            this.botonCerrarHotel.Name = "botonCerrarHotel";
            this.botonCerrarHotel.Size = new System.Drawing.Size(74, 23);
            this.botonCerrarHotel.TabIndex = 20;
            this.botonCerrarHotel.Text = "Cerrar Hotel";
            this.botonCerrarHotel.UseVisualStyleBackColor = true;
            this.botonCerrarHotel.Click += new System.EventHandler(this.botonCerrarHotel_Click);
            // 
            // B_Hotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 35);
            this.Controls.Add(this.botonCerrarHotel);
            this.Controls.Add(this.motivoTextbox);
            this.Controls.Add(this.hastaDTP);
            this.Controls.Add(this.desdeDTP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "B_Hotel";
            this.Text = "Cierre de hotel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker desdeDTP;
        private System.Windows.Forms.DateTimePicker hastaDTP;
        private System.Windows.Forms.TextBox motivoTextbox;
        private System.Windows.Forms.Button botonCerrarHotel;
    }
}
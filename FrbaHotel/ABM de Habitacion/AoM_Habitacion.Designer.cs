namespace FrbaHotel.ABM_de_Habitacion
{
    partial class AoM_Habitacion
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
            this.label4 = new System.Windows.Forms.Label();
            this.frontalCheckbox = new System.Windows.Forms.CheckBox();
            this.activoCheckbox = new System.Windows.Forms.CheckBox();
            this.numeroTextbox = new System.Windows.Forms.TextBox();
            this.pisoTextbox = new System.Windows.Forms.TextBox();
            this.tipoCombo = new System.Windows.Forms.ComboBox();
            this.descTextbox = new System.Windows.Forms.TextBox();
            this.botonGuardar = new System.Windows.Forms.Button();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Piso * :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Número de habitación * :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo * :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Descripción: ";
            // 
            // frontalCheckbox
            // 
            this.frontalCheckbox.AutoSize = true;
            this.frontalCheckbox.Location = new System.Drawing.Point(193, 51);
            this.frontalCheckbox.Name = "frontalCheckbox";
            this.frontalCheckbox.Size = new System.Drawing.Size(70, 17);
            this.frontalCheckbox.TabIndex = 4;
            this.frontalCheckbox.Text = "Es frontal";
            this.frontalCheckbox.UseVisualStyleBackColor = true;
            // 
            // activoCheckbox
            // 
            this.activoCheckbox.AutoSize = true;
            this.activoCheckbox.Location = new System.Drawing.Point(19, 126);
            this.activoCheckbox.Name = "activoCheckbox";
            this.activoCheckbox.Size = new System.Drawing.Size(56, 17);
            this.activoCheckbox.TabIndex = 5;
            this.activoCheckbox.Text = "Activa";
            this.activoCheckbox.UseVisualStyleBackColor = true;
            // 
            // numeroTextbox
            // 
            this.numeroTextbox.Location = new System.Drawing.Point(146, 12);
            this.numeroTextbox.Name = "numeroTextbox";
            this.numeroTextbox.Size = new System.Drawing.Size(35, 20);
            this.numeroTextbox.TabIndex = 6;
            this.numeroTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNums_KeyPressed);
            // 
            // pisoTextbox
            // 
            this.pisoTextbox.Location = new System.Drawing.Point(248, 12);
            this.pisoTextbox.Name = "pisoTextbox";
            this.pisoTextbox.Size = new System.Drawing.Size(35, 20);
            this.pisoTextbox.TabIndex = 7;
            this.pisoTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNums_KeyPressed);
            // 
            // tipoCombo
            // 
            this.tipoCombo.FormattingEnabled = true;
            this.tipoCombo.Location = new System.Drawing.Point(63, 49);
            this.tipoCombo.Name = "tipoCombo";
            this.tipoCombo.Size = new System.Drawing.Size(102, 21);
            this.tipoCombo.TabIndex = 8;
            // 
            // descTextbox
            // 
            this.descTextbox.Location = new System.Drawing.Point(91, 81);
            this.descTextbox.Name = "descTextbox";
            this.descTextbox.Size = new System.Drawing.Size(191, 20);
            this.descTextbox.TabIndex = 9;
            // 
            // botonGuardar
            // 
            this.botonGuardar.Location = new System.Drawing.Point(106, 126);
            this.botonGuardar.Name = "botonGuardar";
            this.botonGuardar.Size = new System.Drawing.Size(75, 23);
            this.botonGuardar.TabIndex = 20;
            this.botonGuardar.Text = "Guardar";
            this.botonGuardar.UseVisualStyleBackColor = true;
            this.botonGuardar.Click += new System.EventHandler(this.botonGuardar_Click);
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(205, 126);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.botonLimpiar.TabIndex = 21;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // AoM_Habitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 166);
            this.Controls.Add(this.botonGuardar);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.descTextbox);
            this.Controls.Add(this.tipoCombo);
            this.Controls.Add(this.pisoTextbox);
            this.Controls.Add(this.numeroTextbox);
            this.Controls.Add(this.activoCheckbox);
            this.Controls.Add(this.frontalCheckbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AoM_Habitacion";
            this.Text = "Alta de habitación";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox frontalCheckbox;
        private System.Windows.Forms.CheckBox activoCheckbox;
        private System.Windows.Forms.TextBox numeroTextbox;
        private System.Windows.Forms.TextBox pisoTextbox;
        private System.Windows.Forms.ComboBox tipoCombo;
        private System.Windows.Forms.TextBox descTextbox;
        private System.Windows.Forms.Button botonGuardar;
        private System.Windows.Forms.Button botonLimpiar;
    }
}
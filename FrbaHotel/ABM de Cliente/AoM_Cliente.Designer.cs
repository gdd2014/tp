namespace FrbaHotel.ABM_de_Cliente
{
    partial class AoM_Cliente
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nombreTextbox = new System.Windows.Forms.TextBox();
            this.apellidoTextbox = new System.Windows.Forms.TextBox();
            this.nDocTextbox = new System.Windows.Forms.TextBox();
            this.tDocCombo = new System.Windows.Forms.ComboBox();
            this.emailTextbox = new System.Windows.Forms.TextBox();
            this.calleTextbox = new System.Windows.Forms.TextBox();
            this.telTextbox = new System.Windows.Forms.TextBox();
            this.nacionalidadTextbox = new System.Windows.Forms.TextBox();
            this.fNacDTP = new System.Windows.Forms.DateTimePicker();
            this.activoCheckbox = new System.Windows.Forms.CheckBox();
            this.botonGuardar = new System.Windows.Forms.Button();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numeroTextbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.paisTextbox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.localidadTextbox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.deptoTextbox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pisoTextbox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre * :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido * :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Documento * :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "E-Mail * :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Teléfono * :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Calle * :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 330);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Fecha de Nacimiento * :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(200, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Nacionalidad * :";
            // 
            // nombreTextbox
            // 
            this.nombreTextbox.Location = new System.Drawing.Point(87, 20);
            this.nombreTextbox.Name = "nombreTextbox";
            this.nombreTextbox.Size = new System.Drawing.Size(118, 20);
            this.nombreTextbox.TabIndex = 8;
            // 
            // apellidoTextbox
            // 
            this.apellidoTextbox.Location = new System.Drawing.Point(288, 20);
            this.apellidoTextbox.Name = "apellidoTextbox";
            this.apellidoTextbox.Size = new System.Drawing.Size(123, 20);
            this.apellidoTextbox.TabIndex = 9;
            // 
            // nDocTextbox
            // 
            this.nDocTextbox.Location = new System.Drawing.Point(202, 59);
            this.nDocTextbox.Name = "nDocTextbox";
            this.nDocTextbox.Size = new System.Drawing.Size(111, 20);
            this.nDocTextbox.TabIndex = 11;
            this.nDocTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNums_KeyPressed);
            // 
            // tDocCombo
            // 
            this.tDocCombo.FormattingEnabled = true;
            this.tDocCombo.Location = new System.Drawing.Point(100, 58);
            this.tDocCombo.Name = "tDocCombo";
            this.tDocCombo.Size = new System.Drawing.Size(88, 21);
            this.tDocCombo.TabIndex = 10;
            // 
            // emailTextbox
            // 
            this.emailTextbox.Location = new System.Drawing.Point(74, 98);
            this.emailTextbox.Name = "emailTextbox";
            this.emailTextbox.Size = new System.Drawing.Size(239, 20);
            this.emailTextbox.TabIndex = 12;
            // 
            // calleTextbox
            // 
            this.calleTextbox.Location = new System.Drawing.Point(65, 19);
            this.calleTextbox.Name = "calleTextbox";
            this.calleTextbox.Size = new System.Drawing.Size(176, 20);
            this.calleTextbox.TabIndex = 13;
            // 
            // telTextbox
            // 
            this.telTextbox.Location = new System.Drawing.Point(87, 135);
            this.telTextbox.Name = "telTextbox";
            this.telTextbox.Size = new System.Drawing.Size(91, 20);
            this.telTextbox.TabIndex = 14;
            // 
            // nacionalidadTextbox
            // 
            this.nacionalidadTextbox.Location = new System.Drawing.Point(288, 135);
            this.nacionalidadTextbox.Name = "nacionalidadTextbox";
            this.nacionalidadTextbox.Size = new System.Drawing.Size(110, 20);
            this.nacionalidadTextbox.TabIndex = 15;
            // 
            // fNacDTP
            // 
            this.fNacDTP.CustomFormat = "dd/MM/yyyy";
            this.fNacDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fNacDTP.Location = new System.Drawing.Point(154, 330);
            this.fNacDTP.Name = "fNacDTP";
            this.fNacDTP.Size = new System.Drawing.Size(109, 20);
            this.fNacDTP.TabIndex = 16;
            // 
            // activoCheckbox
            // 
            this.activoCheckbox.AutoSize = true;
            this.activoCheckbox.Location = new System.Drawing.Point(319, 335);
            this.activoCheckbox.Name = "activoCheckbox";
            this.activoCheckbox.Size = new System.Drawing.Size(56, 17);
            this.activoCheckbox.TabIndex = 17;
            this.activoCheckbox.Text = "Activo";
            this.activoCheckbox.UseVisualStyleBackColor = true;
            // 
            // botonGuardar
            // 
            this.botonGuardar.Location = new System.Drawing.Point(117, 388);
            this.botonGuardar.Name = "botonGuardar";
            this.botonGuardar.Size = new System.Drawing.Size(75, 23);
            this.botonGuardar.TabIndex = 18;
            this.botonGuardar.Text = "Guardar";
            this.botonGuardar.UseVisualStyleBackColor = true;
            this.botonGuardar.Click += new System.EventHandler(this.botonGuardar_Click);
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(238, 388);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.botonLimpiar.TabIndex = 19;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deptoTextbox);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.pisoTextbox);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.localidadTextbox);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.paisTextbox);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.numeroTextbox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.calleTextbox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(22, 174);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 127);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Domicilio";
            // 
            // numeroTextbox
            // 
            this.numeroTextbox.Location = new System.Drawing.Point(326, 19);
            this.numeroTextbox.Name = "numeroTextbox";
            this.numeroTextbox.Size = new System.Drawing.Size(40, 20);
            this.numeroTextbox.TabIndex = 15;
            this.numeroTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNums_KeyPressed);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(263, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Número * :";
            // 
            // paisTextbox
            // 
            this.paisTextbox.Location = new System.Drawing.Point(60, 55);
            this.paisTextbox.Name = "paisTextbox";
            this.paisTextbox.Size = new System.Drawing.Size(60, 20);
            this.paisTextbox.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "País * :";
            // 
            // localidadTextbox
            // 
            this.localidadTextbox.Location = new System.Drawing.Point(83, 89);
            this.localidadTextbox.Name = "localidadTextbox";
            this.localidadTextbox.Size = new System.Drawing.Size(283, 20);
            this.localidadTextbox.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Localidad * :";
            // 
            // deptoTextbox
            // 
            this.deptoTextbox.Location = new System.Drawing.Point(326, 55);
            this.deptoTextbox.Name = "deptoTextbox";
            this.deptoTextbox.Size = new System.Drawing.Size(40, 20);
            this.deptoTextbox.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(233, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Departamento * :";
            // 
            // pisoTextbox
            // 
            this.pisoTextbox.Location = new System.Drawing.Point(181, 55);
            this.pisoTextbox.Name = "pisoTextbox";
            this.pisoTextbox.Size = new System.Drawing.Size(42, 20);
            this.pisoTextbox.TabIndex = 21;
            this.pisoTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNums_KeyPressed);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(135, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Piso * :";
            // 
            // AoM_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 436);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.activoCheckbox);
            this.Controls.Add(this.botonGuardar);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.fNacDTP);
            this.Controls.Add(this.nacionalidadTextbox);
            this.Controls.Add(this.telTextbox);
            this.Controls.Add(this.emailTextbox);
            this.Controls.Add(this.nDocTextbox);
            this.Controls.Add(this.tDocCombo);
            this.Controls.Add(this.apellidoTextbox);
            this.Controls.Add(this.nombreTextbox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AoM_Cliente";
            this.Text = "Alta de Cliente";
            this.Load += new System.EventHandler(this.AoM_Cliente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox nombreTextbox;
        private System.Windows.Forms.TextBox apellidoTextbox;
        private System.Windows.Forms.TextBox nDocTextbox;
        private System.Windows.Forms.ComboBox tDocCombo;
        private System.Windows.Forms.TextBox emailTextbox;
        private System.Windows.Forms.TextBox calleTextbox;
        private System.Windows.Forms.TextBox telTextbox;
        private System.Windows.Forms.TextBox nacionalidadTextbox;
        private System.Windows.Forms.DateTimePicker fNacDTP;
        private System.Windows.Forms.CheckBox activoCheckbox;
        private System.Windows.Forms.Button botonGuardar;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox numeroTextbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox localidadTextbox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox paisTextbox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox deptoTextbox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox pisoTextbox;
        private System.Windows.Forms.Label label13;
    }
}
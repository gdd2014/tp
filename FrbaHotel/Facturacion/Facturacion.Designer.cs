namespace FrbaHotel.Facturacion
{
    partial class Facturacion
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
            this.nombreYApellidoTextbox = new System.Windows.Forms.TextBox();
            this.nDocTextbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tDocTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tipoPagosCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nTarjTextbox = new System.Windows.Forms.TextBox();
            this.codSegTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tarjetaGroup = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tablaDeConceptos = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.totalTextbox = new System.Windows.Forms.TextBox();
            this.botonFacturar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.fFacDTP = new System.Windows.Forms.DateTimePicker();
            this.nFactTextbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tarjetaGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeConceptos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre y apellido:";
            // 
            // nombreYApellidoTextbox
            // 
            this.nombreYApellidoTextbox.Enabled = false;
            this.nombreYApellidoTextbox.Location = new System.Drawing.Point(112, 50);
            this.nombreYApellidoTextbox.Name = "nombreYApellidoTextbox";
            this.nombreYApellidoTextbox.Size = new System.Drawing.Size(148, 20);
            this.nombreYApellidoTextbox.TabIndex = 1;
            // 
            // nDocTextbox
            // 
            this.nDocTextbox.Enabled = false;
            this.nDocTextbox.Location = new System.Drawing.Point(436, 50);
            this.nDocTextbox.Name = "nDocTextbox";
            this.nDocTextbox.Size = new System.Drawing.Size(59, 20);
            this.nDocTextbox.TabIndex = 14;
            this.nDocTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(272, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Documento :";
            // 
            // tDocTextbox
            // 
            this.tDocTextbox.Enabled = false;
            this.tDocTextbox.Location = new System.Drawing.Point(342, 50);
            this.tDocTextbox.Name = "tDocTextbox";
            this.tDocTextbox.Size = new System.Drawing.Size(88, 20);
            this.tDocTextbox.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Medio de pago:";
            // 
            // tipoPagosCombo
            // 
            this.tipoPagosCombo.FormattingEnabled = true;
            this.tipoPagosCombo.Location = new System.Drawing.Point(99, 97);
            this.tipoPagosCombo.Name = "tipoPagosCombo";
            this.tipoPagosCombo.Size = new System.Drawing.Size(117, 21);
            this.tipoPagosCombo.TabIndex = 18;
            this.tipoPagosCombo.SelectedIndexChanged += new System.EventHandler(this.tipoPagosCombo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Número de tarjeta:";
            // 
            // nTarjTextbox
            // 
            this.nTarjTextbox.Location = new System.Drawing.Point(123, 29);
            this.nTarjTextbox.Name = "nTarjTextbox";
            this.nTarjTextbox.Size = new System.Drawing.Size(135, 20);
            this.nTarjTextbox.TabIndex = 20;
            this.nTarjTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // codSegTextbox
            // 
            this.codSegTextbox.Location = new System.Drawing.Point(390, 32);
            this.codSegTextbox.Name = "codSegTextbox";
            this.codSegTextbox.Size = new System.Drawing.Size(39, 20);
            this.codSegTextbox.TabIndex = 22;
            this.codSegTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(277, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Código de seguridad:";
            // 
            // tarjetaGroup
            // 
            this.tarjetaGroup.Controls.Add(this.codSegTextbox);
            this.tarjetaGroup.Controls.Add(this.label3);
            this.tarjetaGroup.Controls.Add(this.label4);
            this.tarjetaGroup.Controls.Add(this.nTarjTextbox);
            this.tarjetaGroup.Location = new System.Drawing.Point(222, 76);
            this.tarjetaGroup.Name = "tarjetaGroup";
            this.tarjetaGroup.Size = new System.Drawing.Size(448, 70);
            this.tarjetaGroup.TabIndex = 23;
            this.tarjetaGroup.TabStop = false;
            this.tarjetaGroup.Text = "Datos de la tarjeta";
            this.tarjetaGroup.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Cargos:";
            // 
            // tablaDeConceptos
            // 
            this.tablaDeConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDeConceptos.Location = new System.Drawing.Point(45, 176);
            this.tablaDeConceptos.Name = "tablaDeConceptos";
            this.tablaDeConceptos.Size = new System.Drawing.Size(576, 158);
            this.tablaDeConceptos.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(464, 363);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Total: ";
            // 
            // totalTextbox
            // 
            this.totalTextbox.Enabled = false;
            this.totalTextbox.Location = new System.Drawing.Point(505, 360);
            this.totalTextbox.Name = "totalTextbox";
            this.totalTextbox.Size = new System.Drawing.Size(88, 20);
            this.totalTextbox.TabIndex = 27;
            this.totalTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // botonFacturar
            // 
            this.botonFacturar.Location = new System.Drawing.Point(235, 374);
            this.botonFacturar.Name = "botonFacturar";
            this.botonFacturar.Size = new System.Drawing.Size(153, 23);
            this.botonFacturar.TabIndex = 28;
            this.botonFacturar.Text = "Facturar";
            this.botonFacturar.UseVisualStyleBackColor = true;
            this.botonFacturar.Click += new System.EventHandler(this.botonFacturar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(515, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Fecha: ";
            // 
            // fFacDTP
            // 
            this.fFacDTP.CustomFormat = "dd/MM/yyyy";
            this.fFacDTP.Enabled = false;
            this.fFacDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fFacDTP.Location = new System.Drawing.Point(561, 50);
            this.fFacDTP.Name = "fFacDTP";
            this.fFacDTP.Size = new System.Drawing.Size(109, 20);
            this.fFacDTP.TabIndex = 30;
            // 
            // nFactTextbox
            // 
            this.nFactTextbox.Location = new System.Drawing.Point(565, 12);
            this.nFactTextbox.Name = "nFactTextbox";
            this.nFactTextbox.Size = new System.Drawing.Size(105, 20);
            this.nFactTextbox.TabIndex = 32;
            this.nFactTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(495, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Factura Nº: ";
            // 
            // Facturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 414);
            this.Controls.Add(this.nFactTextbox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.fFacDTP);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.botonFacturar);
            this.Controls.Add(this.totalTextbox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tablaDeConceptos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tarjetaGroup);
            this.Controls.Add(this.tipoPagosCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tDocTextbox);
            this.Controls.Add(this.nDocTextbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nombreYApellidoTextbox);
            this.Controls.Add(this.label1);
            this.Name = "Facturacion";
            this.Text = "Facturacion";
            this.tarjetaGroup.ResumeLayout(false);
            this.tarjetaGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeConceptos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nombreYApellidoTextbox;
        private System.Windows.Forms.TextBox nDocTextbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tDocTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox tipoPagosCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nTarjTextbox;
        private System.Windows.Forms.TextBox codSegTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox tarjetaGroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView tablaDeConceptos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox totalTextbox;
        private System.Windows.Forms.Button botonFacturar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker fFacDTP;
        private System.Windows.Forms.TextBox nFactTextbox;
        private System.Windows.Forms.Label label9;
    }
}
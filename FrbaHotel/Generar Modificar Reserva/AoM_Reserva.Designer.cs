namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class AoM_Reserva
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
            this.regsCombo = new System.Windows.Forms.ComboBox();
            this.consultaGroup = new System.Windows.Forms.GroupBox();
            this.botonComsultar = new System.Windows.Forms.Button();
            this.tablaHabsDisp = new System.Windows.Forms.DataGridView();
            this.tablaHabsEnReserva = new System.Windows.Forms.DataGridView();
            this.botonAddHab = new System.Windows.Forms.Button();
            this.botonRemoveHab = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.clienteGroup = new System.Windows.Forms.GroupBox();
            this.botonAltaCli = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tablaDeClientes = new System.Windows.Forms.DataGridView();
            this.botonBuscarCli = new System.Windows.Forms.Button();
            this.emailTextbox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tDocCombo = new System.Windows.Forms.ComboBox();
            this.nDocTextbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.botonConfirmarReserva = new System.Windows.Forms.Button();
            this.modLabel = new System.Windows.Forms.Label();
            this.consultaGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaHabsDisp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaHabsEnReserva)).BeginInit();
            this.clienteGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha desde: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha hasta: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(449, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Regimen: ";
            // 
            // desdeDTP
            // 
            this.desdeDTP.CustomFormat = "dd/MM/yyyy";
            this.desdeDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.desdeDTP.Location = new System.Drawing.Point(99, 35);
            this.desdeDTP.Name = "desdeDTP";
            this.desdeDTP.Size = new System.Drawing.Size(109, 20);
            this.desdeDTP.TabIndex = 17;
            this.desdeDTP.ValueChanged += new System.EventHandler(this.desdeDTP_ValueChanged);
            // 
            // hastaDTP
            // 
            this.hastaDTP.CustomFormat = "dd/MM/yyyy";
            this.hastaDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.hastaDTP.Location = new System.Drawing.Point(320, 35);
            this.hastaDTP.Name = "hastaDTP";
            this.hastaDTP.Size = new System.Drawing.Size(109, 20);
            this.hastaDTP.TabIndex = 18;
            this.hastaDTP.ValueChanged += new System.EventHandler(this.hastaDTP_ValueChanged);
            // 
            // regsCombo
            // 
            this.regsCombo.FormattingEnabled = true;
            this.regsCombo.Location = new System.Drawing.Point(510, 35);
            this.regsCombo.Name = "regsCombo";
            this.regsCombo.Size = new System.Drawing.Size(140, 21);
            this.regsCombo.TabIndex = 19;
            // 
            // consultaGroup
            // 
            this.consultaGroup.Controls.Add(this.botonComsultar);
            this.consultaGroup.Controls.Add(this.regsCombo);
            this.consultaGroup.Controls.Add(this.label1);
            this.consultaGroup.Controls.Add(this.hastaDTP);
            this.consultaGroup.Controls.Add(this.label2);
            this.consultaGroup.Controls.Add(this.desdeDTP);
            this.consultaGroup.Controls.Add(this.label3);
            this.consultaGroup.Location = new System.Drawing.Point(26, 23);
            this.consultaGroup.Name = "consultaGroup";
            this.consultaGroup.Size = new System.Drawing.Size(801, 79);
            this.consultaGroup.TabIndex = 20;
            this.consultaGroup.TabStop = false;
            this.consultaGroup.Text = "Consultar disponibilidad";
            // 
            // botonComsultar
            // 
            this.botonComsultar.Location = new System.Drawing.Point(679, 30);
            this.botonComsultar.Name = "botonComsultar";
            this.botonComsultar.Size = new System.Drawing.Size(104, 23);
            this.botonComsultar.TabIndex = 20;
            this.botonComsultar.Text = "Consultar";
            this.botonComsultar.UseVisualStyleBackColor = true;
            this.botonComsultar.Click += new System.EventHandler(this.botonConsultar_Click);
            // 
            // tablaHabsDisp
            // 
            this.tablaHabsDisp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaHabsDisp.Location = new System.Drawing.Point(26, 185);
            this.tablaHabsDisp.Name = "tablaHabsDisp";
            this.tablaHabsDisp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaHabsDisp.Size = new System.Drawing.Size(390, 105);
            this.tablaHabsDisp.TabIndex = 21;
            this.tablaHabsDisp.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgv_RowPrePaint);
            // 
            // tablaHabsEnReserva
            // 
            this.tablaHabsEnReserva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaHabsEnReserva.Location = new System.Drawing.Point(507, 185);
            this.tablaHabsEnReserva.Name = "tablaHabsEnReserva";
            this.tablaHabsEnReserva.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaHabsEnReserva.Size = new System.Drawing.Size(390, 105);
            this.tablaHabsEnReserva.TabIndex = 22;
            this.tablaHabsEnReserva.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgv_RowPrePaint);
            // 
            // botonAddHab
            // 
            this.botonAddHab.Location = new System.Drawing.Point(434, 202);
            this.botonAddHab.Name = "botonAddHab";
            this.botonAddHab.Size = new System.Drawing.Size(57, 23);
            this.botonAddHab.TabIndex = 23;
            this.botonAddHab.Text = ">>";
            this.botonAddHab.UseVisualStyleBackColor = true;
            this.botonAddHab.Click += new System.EventHandler(this.botonAddHab_Click);
            // 
            // botonRemoveHab
            // 
            this.botonRemoveHab.Location = new System.Drawing.Point(434, 244);
            this.botonRemoveHab.Name = "botonRemoveHab";
            this.botonRemoveHab.Size = new System.Drawing.Size(57, 23);
            this.botonRemoveHab.TabIndex = 24;
            this.botonRemoveHab.Text = "<<";
            this.botonRemoveHab.UseVisualStyleBackColor = true;
            this.botonRemoveHab.Click += new System.EventHandler(this.botonRemoveHab_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(267, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Habitaciones disponibles en las fechas seleccionadas: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(524, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Habitaciones en la reserva actual: ";
            // 
            // clienteGroup
            // 
            this.clienteGroup.Controls.Add(this.botonAltaCli);
            this.clienteGroup.Controls.Add(this.label9);
            this.clienteGroup.Controls.Add(this.tablaDeClientes);
            this.clienteGroup.Controls.Add(this.botonBuscarCli);
            this.clienteGroup.Controls.Add(this.emailTextbox);
            this.clienteGroup.Controls.Add(this.label8);
            this.clienteGroup.Controls.Add(this.tDocCombo);
            this.clienteGroup.Controls.Add(this.nDocTextbox);
            this.clienteGroup.Controls.Add(this.label6);
            this.clienteGroup.Controls.Add(this.label7);
            this.clienteGroup.Enabled = false;
            this.clienteGroup.Location = new System.Drawing.Point(50, 328);
            this.clienteGroup.Name = "clienteGroup";
            this.clienteGroup.Size = new System.Drawing.Size(777, 191);
            this.clienteGroup.TabIndex = 27;
            this.clienteGroup.TabStop = false;
            this.clienteGroup.Text = "Cliente responsable de la reserva";
            // 
            // botonAltaCli
            // 
            this.botonAltaCli.Location = new System.Drawing.Point(635, 60);
            this.botonAltaCli.Name = "botonAltaCli";
            this.botonAltaCli.Size = new System.Drawing.Size(107, 23);
            this.botonAltaCli.TabIndex = 15;
            this.botonAltaCli.Text = "Darse de alta";
            this.botonAltaCli.UseVisualStyleBackColor = true;
            this.botonAltaCli.Click += new System.EventHandler(this.botonAltaCli_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(483, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "¿No es un cliente registrado?";
            // 
            // tablaDeClientes
            // 
            this.tablaDeClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDeClientes.Location = new System.Drawing.Point(109, 101);
            this.tablaDeClientes.Name = "tablaDeClientes";
            this.tablaDeClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaDeClientes.Size = new System.Drawing.Size(590, 76);
            this.tablaDeClientes.TabIndex = 13;
            this.tablaDeClientes.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgv_RowPrePaint);
            // 
            // botonBuscarCli
            // 
            this.botonBuscarCli.Location = new System.Drawing.Point(75, 61);
            this.botonBuscarCli.Name = "botonBuscarCli";
            this.botonBuscarCli.Size = new System.Drawing.Size(75, 23);
            this.botonBuscarCli.TabIndex = 12;
            this.botonBuscarCli.Text = "Buscar";
            this.botonBuscarCli.UseVisualStyleBackColor = true;
            this.botonBuscarCli.Click += new System.EventHandler(this.botonBuscarCli_Click);
            // 
            // emailTextbox
            // 
            this.emailTextbox.Location = new System.Drawing.Point(595, 34);
            this.emailTextbox.Name = "emailTextbox";
            this.emailTextbox.Size = new System.Drawing.Size(164, 20);
            this.emailTextbox.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(550, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "E-Mail:";
            // 
            // tDocCombo
            // 
            this.tDocCombo.FormattingEnabled = true;
            this.tDocCombo.Location = new System.Drawing.Point(130, 34);
            this.tDocCombo.Name = "tDocCombo";
            this.tDocCombo.Size = new System.Drawing.Size(121, 21);
            this.tDocCombo.TabIndex = 8;
            // 
            // nDocTextbox
            // 
            this.nDocTextbox.Location = new System.Drawing.Point(420, 34);
            this.nDocTextbox.Name = "nDocTextbox";
            this.nDocTextbox.Size = new System.Drawing.Size(100, 20);
            this.nDocTextbox.TabIndex = 9;
            this.nDocTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNums_KeyPressed);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(284, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Número de documento: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Tipo de documento: ";
            // 
            // botonConfirmarReserva
            // 
            this.botonConfirmarReserva.Enabled = false;
            this.botonConfirmarReserva.Location = new System.Drawing.Point(364, 525);
            this.botonConfirmarReserva.Name = "botonConfirmarReserva";
            this.botonConfirmarReserva.Size = new System.Drawing.Size(218, 23);
            this.botonConfirmarReserva.TabIndex = 28;
            this.botonConfirmarReserva.Text = "Confirmar reserva";
            this.botonConfirmarReserva.UseVisualStyleBackColor = true;
            this.botonConfirmarReserva.Click += new System.EventHandler(this.botonConfirmarReserva_Click);
            // 
            // modLabel
            // 
            this.modLabel.AutoSize = true;
            this.modLabel.Location = new System.Drawing.Point(271, 123);
            this.modLabel.Name = "modLabel";
            this.modLabel.Size = new System.Drawing.Size(388, 13);
            this.modLabel.TabIndex = 29;
            this.modLabel.Text = "Para modificar las fechas y/o regimen, retire las habitaciones de la reserva actu" +
                "al";
            this.modLabel.Visible = false;
            // 
            // AoM_Reserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 562);
            this.Controls.Add(this.modLabel);
            this.Controls.Add(this.botonConfirmarReserva);
            this.Controls.Add(this.clienteGroup);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.botonRemoveHab);
            this.Controls.Add(this.botonAddHab);
            this.Controls.Add(this.tablaHabsEnReserva);
            this.Controls.Add(this.tablaHabsDisp);
            this.Controls.Add(this.consultaGroup);
            this.Name = "AoM_Reserva";
            this.Text = "Alta de reserva";
            this.consultaGroup.ResumeLayout(false);
            this.consultaGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaHabsDisp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaHabsEnReserva)).EndInit();
            this.clienteGroup.ResumeLayout(false);
            this.clienteGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker desdeDTP;
        private System.Windows.Forms.DateTimePicker hastaDTP;
        private System.Windows.Forms.ComboBox regsCombo;
        private System.Windows.Forms.GroupBox consultaGroup;
        private System.Windows.Forms.Button botonComsultar;
        private System.Windows.Forms.DataGridView tablaHabsDisp;
        private System.Windows.Forms.DataGridView tablaHabsEnReserva;
        private System.Windows.Forms.Button botonAddHab;
        private System.Windows.Forms.Button botonRemoveHab;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox clienteGroup;
        private System.Windows.Forms.ComboBox tDocCombo;
        private System.Windows.Forms.TextBox nDocTextbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox emailTextbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button botonBuscarCli;
        private System.Windows.Forms.Button botonConfirmarReserva;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView tablaDeClientes;
        private System.Windows.Forms.Button botonAltaCli;
        private System.Windows.Forms.Label modLabel;
    }
}
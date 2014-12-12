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
            this.consultaGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaHabsDisp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaHabsEnReserva)).BeginInit();
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
            // 
            // hastaDTP
            // 
            this.hastaDTP.CustomFormat = "dd/MM/yyyy";
            this.hastaDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.hastaDTP.Location = new System.Drawing.Point(320, 35);
            this.hastaDTP.Name = "hastaDTP";
            this.hastaDTP.Size = new System.Drawing.Size(109, 20);
            this.hastaDTP.TabIndex = 18;
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
            this.tablaHabsDisp.Location = new System.Drawing.Point(26, 146);
            this.tablaHabsDisp.Name = "tablaHabsDisp";
            this.tablaHabsDisp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaHabsDisp.Size = new System.Drawing.Size(390, 105);
            this.tablaHabsDisp.TabIndex = 21;
            // 
            // tablaHabsEnReserva
            // 
            this.tablaHabsEnReserva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaHabsEnReserva.Location = new System.Drawing.Point(507, 146);
            this.tablaHabsEnReserva.Name = "tablaHabsEnReserva";
            this.tablaHabsEnReserva.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaHabsEnReserva.Size = new System.Drawing.Size(390, 105);
            this.tablaHabsEnReserva.TabIndex = 22;
            this.tablaHabsEnReserva.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgv_RowPrePaint);
            // 
            // botonAddHab
            // 
            this.botonAddHab.Location = new System.Drawing.Point(434, 163);
            this.botonAddHab.Name = "botonAddHab";
            this.botonAddHab.Size = new System.Drawing.Size(57, 23);
            this.botonAddHab.TabIndex = 23;
            this.botonAddHab.Text = ">>";
            this.botonAddHab.UseVisualStyleBackColor = true;
            this.botonAddHab.Click += new System.EventHandler(this.botonAddHab_Click);
            // 
            // botonRemoveHab
            // 
            this.botonRemoveHab.Location = new System.Drawing.Point(434, 205);
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
            this.label4.Location = new System.Drawing.Point(47, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(267, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Habitaciones disponibles en las fechas seleccionadas: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(524, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Habitaciones en la reserva actual: ";
            // 
            // AoM_Reserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 391);
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
    }
}
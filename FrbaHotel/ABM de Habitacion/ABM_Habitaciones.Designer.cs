namespace FrbaHotel.ABM_de_Habitacion
{
    partial class ABM_Habitaciones
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
            this.botonBuscar = new System.Windows.Forms.Button();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pisoTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tipoCombo = new System.Windows.Forms.ComboBox();
            this.numeroTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tablaDeHabitaciones = new System.Windows.Forms.DataGridView();
            this.botonNuevoHotel = new System.Windows.Forms.Button();
            this.botonModificar = new System.Windows.Forms.Button();
            this.botonCerrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // botonBuscar
            // 
            this.botonBuscar.Location = new System.Drawing.Point(86, 93);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(96, 23);
            this.botonBuscar.TabIndex = 12;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.UseVisualStyleBackColor = true;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(282, 93);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(53, 23);
            this.botonLimpiar.TabIndex = 13;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pisoTextbox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tipoCombo);
            this.groupBox1.Controls.Add(this.numeroTextbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(23, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 66);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // pisoTextbox
            // 
            this.pisoTextbox.Location = new System.Drawing.Point(156, 27);
            this.pisoTextbox.Name = "pisoTextbox";
            this.pisoTextbox.Size = new System.Drawing.Size(36, 20);
            this.pisoTextbox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Piso: ";
            // 
            // tipoCombo
            // 
            this.tipoCombo.FormattingEnabled = true;
            this.tipoCombo.Location = new System.Drawing.Point(244, 27);
            this.tipoCombo.Name = "tipoCombo";
            this.tipoCombo.Size = new System.Drawing.Size(131, 21);
            this.tipoCombo.TabIndex = 7;
            // 
            // numeroTextbox
            // 
            this.numeroTextbox.Location = new System.Drawing.Point(63, 25);
            this.numeroTextbox.Name = "numeroTextbox";
            this.numeroTextbox.Size = new System.Drawing.Size(36, 20);
            this.numeroTextbox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(204, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tipo: ";
            // 
            // tablaDeHabitaciones
            // 
            this.tablaDeHabitaciones.AccessibleDescription = "";
            this.tablaDeHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDeHabitaciones.Location = new System.Drawing.Point(33, 141);
            this.tablaDeHabitaciones.Name = "tablaDeHabitaciones";
            this.tablaDeHabitaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaDeHabitaciones.Size = new System.Drawing.Size(365, 105);
            this.tablaDeHabitaciones.TabIndex = 14;
            this.tablaDeHabitaciones.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgv_RowPrePaint);
            // 
            // botonNuevoHotel
            // 
            this.botonNuevoHotel.Location = new System.Drawing.Point(282, 266);
            this.botonNuevoHotel.Name = "botonNuevoHotel";
            this.botonNuevoHotel.Size = new System.Drawing.Size(101, 23);
            this.botonNuevoHotel.TabIndex = 17;
            this.botonNuevoHotel.Text = "Nueva Habitacion";
            this.botonNuevoHotel.UseVisualStyleBackColor = true;
            this.botonNuevoHotel.Click += new System.EventHandler(this.botonNuevoHotel_Click);
            // 
            // botonModificar
            // 
            this.botonModificar.Location = new System.Drawing.Point(153, 266);
            this.botonModificar.Name = "botonModificar";
            this.botonModificar.Size = new System.Drawing.Size(88, 23);
            this.botonModificar.TabIndex = 16;
            this.botonModificar.Text = "Modificar";
            this.botonModificar.UseVisualStyleBackColor = true;
            this.botonModificar.Click += new System.EventHandler(this.botonModificar_Click);
            // 
            // botonCerrar
            // 
            this.botonCerrar.Location = new System.Drawing.Point(42, 266);
            this.botonCerrar.Name = "botonCerrar";
            this.botonCerrar.Size = new System.Drawing.Size(66, 23);
            this.botonCerrar.TabIndex = 15;
            this.botonCerrar.Text = "Bajar";
            this.botonCerrar.UseVisualStyleBackColor = true;
            this.botonCerrar.Click += new System.EventHandler(this.botonCerrar_Click);
            // 
            // ABM_Habitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 303);
            this.Controls.Add(this.botonNuevoHotel);
            this.Controls.Add(this.botonModificar);
            this.Controls.Add(this.botonCerrar);
            this.Controls.Add(this.tablaDeHabitaciones);
            this.Controls.Add(this.botonBuscar);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.groupBox1);
            this.Name = "ABM_Habitaciones";
            this.Text = "ABM de Habitaciones";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeHabitaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox tipoCombo;
        private System.Windows.Forms.TextBox numeroTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox pisoTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView tablaDeHabitaciones;
        private System.Windows.Forms.Button botonNuevoHotel;
        private System.Windows.Forms.Button botonModificar;
        private System.Windows.Forms.Button botonCerrar;

    }
}
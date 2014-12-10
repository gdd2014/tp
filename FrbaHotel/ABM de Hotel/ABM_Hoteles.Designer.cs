namespace FrbaHotel.ABM_de_Hotel
{
    partial class ABM_Hoteles
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
            this.estrellasCombo = new System.Windows.Forms.ComboBox();
            this.paisTextbox = new System.Windows.Forms.TextBox();
            this.ciudadTextbox = new System.Windows.Forms.TextBox();
            this.nombreTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tablaDeHoteles = new System.Windows.Forms.DataGridView();
            this.botonNuevoHotel = new System.Windows.Forms.Button();
            this.botonModificar = new System.Windows.Forms.Button();
            this.botonCerrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeHoteles)).BeginInit();
            this.SuspendLayout();
            // 
            // botonBuscar
            // 
            this.botonBuscar.Location = new System.Drawing.Point(526, 50);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(96, 23);
            this.botonBuscar.TabIndex = 9;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.UseVisualStyleBackColor = true;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(547, 90);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(53, 23);
            this.botonLimpiar.TabIndex = 10;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.estrellasCombo);
            this.groupBox1.Controls.Add(this.paisTextbox);
            this.groupBox1.Controls.Add(this.ciudadTextbox);
            this.groupBox1.Controls.Add(this.nombreTextbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(28, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // estrellasCombo
            // 
            this.estrellasCombo.FormattingEnabled = true;
            this.estrellasCombo.Location = new System.Drawing.Point(366, 24);
            this.estrellasCombo.Name = "estrellasCombo";
            this.estrellasCombo.Size = new System.Drawing.Size(37, 21);
            this.estrellasCombo.TabIndex = 7;
            // 
            // paisTextbox
            // 
            this.paisTextbox.Location = new System.Drawing.Point(59, 64);
            this.paisTextbox.Name = "paisTextbox";
            this.paisTextbox.Size = new System.Drawing.Size(139, 20);
            this.paisTextbox.TabIndex = 6;
            // 
            // ciudadTextbox
            // 
            this.ciudadTextbox.Location = new System.Drawing.Point(295, 64);
            this.ciudadTextbox.Name = "ciudadTextbox";
            this.ciudadTextbox.Size = new System.Drawing.Size(139, 20);
            this.ciudadTextbox.TabIndex = 5;
            // 
            // nombreTextbox
            // 
            this.nombreTextbox.Location = new System.Drawing.Point(74, 24);
            this.nombreTextbox.Name = "nombreTextbox";
            this.nombreTextbox.Size = new System.Drawing.Size(209, 20);
            this.nombreTextbox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ciudad: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(307, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Estrellas: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "País: ";
            // 
            // tablaDeHoteles
            // 
            this.tablaDeHoteles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDeHoteles.Location = new System.Drawing.Point(40, 150);
            this.tablaDeHoteles.Name = "tablaDeHoteles";
            this.tablaDeHoteles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaDeHoteles.Size = new System.Drawing.Size(571, 160);
            this.tablaDeHoteles.TabIndex = 11;
            this.tablaDeHoteles.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgv_RowPrePaint);
            // 
            // botonNuevoHotel
            // 
            this.botonNuevoHotel.Location = new System.Drawing.Point(499, 335);
            this.botonNuevoHotel.Name = "botonNuevoHotel";
            this.botonNuevoHotel.Size = new System.Drawing.Size(101, 23);
            this.botonNuevoHotel.TabIndex = 14;
            this.botonNuevoHotel.Text = "Nuevo Hotel";
            this.botonNuevoHotel.UseVisualStyleBackColor = true;
            this.botonNuevoHotel.Click += new System.EventHandler(this.botonNuevoHotel_Click);
            // 
            // botonModificar
            // 
            this.botonModificar.Location = new System.Drawing.Point(268, 335);
            this.botonModificar.Name = "botonModificar";
            this.botonModificar.Size = new System.Drawing.Size(115, 23);
            this.botonModificar.TabIndex = 13;
            this.botonModificar.Text = "Modificar Hotel";
            this.botonModificar.UseVisualStyleBackColor = true;
            this.botonModificar.Click += new System.EventHandler(this.botonModificar_Click);
            // 
            // botonCerrar
            // 
            this.botonCerrar.Location = new System.Drawing.Point(49, 335);
            this.botonCerrar.Name = "botonCerrar";
            this.botonCerrar.Size = new System.Drawing.Size(108, 23);
            this.botonCerrar.TabIndex = 12;
            this.botonCerrar.Text = "Cerrar Hotel";
            this.botonCerrar.UseVisualStyleBackColor = true;
            this.botonCerrar.Click += new System.EventHandler(this.botonCerrar_Click);
            // 
            // ABM_Hoteles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 381);
            this.Controls.Add(this.botonNuevoHotel);
            this.Controls.Add(this.botonModificar);
            this.Controls.Add(this.botonCerrar);
            this.Controls.Add(this.tablaDeHoteles);
            this.Controls.Add(this.botonBuscar);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.groupBox1);
            this.Name = "ABM_Hoteles";
            this.Text = "ABM de Hoteles";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeHoteles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ciudadTextbox;
        private System.Windows.Forms.TextBox nombreTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox paisTextbox;
        private System.Windows.Forms.DataGridView tablaDeHoteles;
        private System.Windows.Forms.Button botonNuevoHotel;
        private System.Windows.Forms.Button botonModificar;
        private System.Windows.Forms.Button botonCerrar;
        private System.Windows.Forms.ComboBox estrellasCombo;
    }
}
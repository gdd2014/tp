namespace FrbaHotel.ABM_de_Cliente
{
    partial class ABM_Clientes
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tDocCombo = new System.Windows.Forms.ComboBox();
            this.emailTextbox = new System.Windows.Forms.TextBox();
            this.nDocTextbox = new System.Windows.Forms.TextBox();
            this.apellidoTextbox = new System.Windows.Forms.TextBox();
            this.nombreTextbox = new System.Windows.Forms.TextBox();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.tablaDeClientes = new System.Windows.Forms.DataGridView();
            this.botonEliminar = new System.Windows.Forms.Button();
            this.botonModificar = new System.Windows.Forms.Button();
            this.botonNuevoCliente = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeClientes)).BeginInit();
            this.SuspendLayout();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo de documento: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(325, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Número de documento: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(402, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "E-Mail:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tDocCombo);
            this.groupBox1.Controls.Add(this.emailTextbox);
            this.groupBox1.Controls.Add(this.nDocTextbox);
            this.groupBox1.Controls.Add(this.apellidoTextbox);
            this.groupBox1.Controls.Add(this.nombreTextbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(29, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(625, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // tDocCombo
            // 
            this.tDocCombo.FormattingEnabled = true;
            this.tDocCombo.Location = new System.Drawing.Point(171, 64);
            this.tDocCombo.Name = "tDocCombo";
            this.tDocCombo.Size = new System.Drawing.Size(121, 21);
            this.tDocCombo.TabIndex = 4;
            // 
            // emailTextbox
            // 
            this.emailTextbox.Location = new System.Drawing.Point(447, 24);
            this.emailTextbox.Name = "emailTextbox";
            this.emailTextbox.Size = new System.Drawing.Size(164, 20);
            this.emailTextbox.TabIndex = 3;
            // 
            // nDocTextbox
            // 
            this.nDocTextbox.Location = new System.Drawing.Point(461, 64);
            this.nDocTextbox.Name = "nDocTextbox";
            this.nDocTextbox.Size = new System.Drawing.Size(100, 20);
            this.nDocTextbox.TabIndex = 5;
            this.nDocTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nDocTextbox_KeyPressed);
            // 
            // apellidoTextbox
            // 
            this.apellidoTextbox.Location = new System.Drawing.Point(256, 24);
            this.apellidoTextbox.Name = "apellidoTextbox";
            this.apellidoTextbox.Size = new System.Drawing.Size(100, 20);
            this.apellidoTextbox.TabIndex = 2;
            // 
            // nombreTextbox
            // 
            this.nombreTextbox.Location = new System.Drawing.Point(74, 24);
            this.nombreTextbox.Name = "nombreTextbox";
            this.nombreTextbox.Size = new System.Drawing.Size(100, 20);
            this.nombreTextbox.TabIndex = 1;
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(587, 118);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(53, 23);
            this.botonLimpiar.TabIndex = 7;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // botonBuscar
            // 
            this.botonBuscar.Location = new System.Drawing.Point(302, 118);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(96, 23);
            this.botonBuscar.TabIndex = 6;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.UseVisualStyleBackColor = true;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // tablaDeClientes
            // 
            this.tablaDeClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDeClientes.Location = new System.Drawing.Point(40, 162);
            this.tablaDeClientes.Name = "tablaDeClientes";
            this.tablaDeClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaDeClientes.Size = new System.Drawing.Size(590, 173);
            this.tablaDeClientes.TabIndex = 8;
            this.tablaDeClientes.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgv_RowPrePaint);
            // 
            // botonEliminar
            // 
            this.botonEliminar.Location = new System.Drawing.Point(50, 366);
            this.botonEliminar.Name = "botonEliminar";
            this.botonEliminar.Size = new System.Drawing.Size(108, 23);
            this.botonEliminar.TabIndex = 9;
            this.botonEliminar.Text = "Eliminar Cliente";
            this.botonEliminar.UseVisualStyleBackColor = true;
            this.botonEliminar.Click += new System.EventHandler(this.botonEliminar_Click);
            // 
            // botonModificar
            // 
            this.botonModificar.Location = new System.Drawing.Point(287, 366);
            this.botonModificar.Name = "botonModificar";
            this.botonModificar.Size = new System.Drawing.Size(115, 23);
            this.botonModificar.TabIndex = 10;
            this.botonModificar.Text = "Modificar Cliente";
            this.botonModificar.UseVisualStyleBackColor = true;
            this.botonModificar.Click += new System.EventHandler(this.botonModificar_Click);
            // 
            // botonNuevoCliente
            // 
            this.botonNuevoCliente.Location = new System.Drawing.Point(539, 366);
            this.botonNuevoCliente.Name = "botonNuevoCliente";
            this.botonNuevoCliente.Size = new System.Drawing.Size(101, 23);
            this.botonNuevoCliente.TabIndex = 11;
            this.botonNuevoCliente.Text = "Nuevo Cliente";
            this.botonNuevoCliente.UseVisualStyleBackColor = true;
            this.botonNuevoCliente.Click += new System.EventHandler(this.botonNuevoCliente_Click);
            // 
            // ABM_Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 414);
            this.Controls.Add(this.botonNuevoCliente);
            this.Controls.Add(this.botonModificar);
            this.Controls.Add(this.botonEliminar);
            this.Controls.Add(this.tablaDeClientes);
            this.Controls.Add(this.botonBuscar);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.groupBox1);
            this.Name = "ABM_Clientes";
            this.Text = "ABM de Clientes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox tDocCombo;
        private System.Windows.Forms.TextBox emailTextbox;
        private System.Windows.Forms.TextBox nDocTextbox;
        private System.Windows.Forms.TextBox apellidoTextbox;
        private System.Windows.Forms.TextBox nombreTextbox;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.DataGridView tablaDeClientes;
        private System.Windows.Forms.Button botonEliminar;
        private System.Windows.Forms.Button botonModificar;
        private System.Windows.Forms.Button botonNuevoCliente;
    }
}
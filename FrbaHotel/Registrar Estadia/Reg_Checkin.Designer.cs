namespace FrbaHotel.Registrar_Estadia
{
    partial class Reg_Checkin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.botonRemoveHab = new System.Windows.Forms.Button();
            this.botonAddHab = new System.Windows.Forms.Button();
            this.tablaClientesEnEstadia = new System.Windows.Forms.DataGridView();
            this.tablaClientesTotal = new System.Windows.Forms.DataGridView();
            this.botonAltaCli = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.botonRegistrarEstadia = new System.Windows.Forms.Button();
            this.botonBuscarCli = new System.Windows.Forms.Button();
            this.tDocCombo = new System.Windows.Forms.ComboBox();
            this.nDocTextbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.tablaClientesEnEstadia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaClientesTotal)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(476, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Huéspedes en la estadía actual: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Clientes de la cadena: ";
            // 
            // botonRemoveHab
            // 
            this.botonRemoveHab.Location = new System.Drawing.Point(397, 222);
            this.botonRemoveHab.Name = "botonRemoveHab";
            this.botonRemoveHab.Size = new System.Drawing.Size(57, 23);
            this.botonRemoveHab.TabIndex = 30;
            this.botonRemoveHab.Text = "<<";
            this.botonRemoveHab.UseVisualStyleBackColor = true;
            this.botonRemoveHab.Click += new System.EventHandler(this.botonRemoveHab_Click);
            // 
            // botonAddHab
            // 
            this.botonAddHab.Location = new System.Drawing.Point(397, 180);
            this.botonAddHab.Name = "botonAddHab";
            this.botonAddHab.Size = new System.Drawing.Size(57, 23);
            this.botonAddHab.TabIndex = 29;
            this.botonAddHab.Text = ">>";
            this.botonAddHab.UseVisualStyleBackColor = true;
            this.botonAddHab.Click += new System.EventHandler(this.botonAddHab_Click);
            // 
            // tablaClientesEnEstadia
            // 
            this.tablaClientesEnEstadia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaClientesEnEstadia.Location = new System.Drawing.Point(479, 165);
            this.tablaClientesEnEstadia.Name = "tablaClientesEnEstadia";
            this.tablaClientesEnEstadia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaClientesEnEstadia.Size = new System.Drawing.Size(336, 105);
            this.tablaClientesEnEstadia.TabIndex = 28;
            this.tablaClientesEnEstadia.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgv_RowPrePaint);
            // 
            // tablaClientesTotal
            // 
            this.tablaClientesTotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaClientesTotal.Location = new System.Drawing.Point(26, 165);
            this.tablaClientesTotal.Name = "tablaClientesTotal";
            this.tablaClientesTotal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaClientesTotal.Size = new System.Drawing.Size(343, 105);
            this.tablaClientesTotal.TabIndex = 27;
            this.tablaClientesTotal.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgv_RowPrePaint);
            // 
            // botonAltaCli
            // 
            this.botonAltaCli.Location = new System.Drawing.Point(179, 276);
            this.botonAltaCli.Name = "botonAltaCli";
            this.botonAltaCli.Size = new System.Drawing.Size(97, 23);
            this.botonAltaCli.TabIndex = 34;
            this.botonAltaCli.Text = "Darse de alta";
            this.botonAltaCli.UseVisualStyleBackColor = true;
            this.botonAltaCli.Click += new System.EventHandler(this.botonAltaCli_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 282);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "¿No es un cliente registrado?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(574, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Registro de estadía: ";
            // 
            // botonRegistrarEstadia
            // 
            this.botonRegistrarEstadia.Location = new System.Drawing.Point(568, 280);
            this.botonRegistrarEstadia.Name = "botonRegistrarEstadia";
            this.botonRegistrarEstadia.Size = new System.Drawing.Size(186, 23);
            this.botonRegistrarEstadia.TabIndex = 36;
            this.botonRegistrarEstadia.Text = "Registrar estadía";
            this.botonRegistrarEstadia.UseVisualStyleBackColor = true;
            this.botonRegistrarEstadia.Click += new System.EventHandler(this.botonRegistrarEstadia_Click);
            // 
            // botonBuscarCli
            // 
            this.botonBuscarCli.Location = new System.Drawing.Point(271, 28);
            this.botonBuscarCli.Name = "botonBuscarCli";
            this.botonBuscarCli.Size = new System.Drawing.Size(75, 23);
            this.botonBuscarCli.TabIndex = 41;
            this.botonBuscarCli.Text = "Buscar";
            this.botonBuscarCli.UseVisualStyleBackColor = true;
            this.botonBuscarCli.Click += new System.EventHandler(this.botonBuscarCli_Click);
            // 
            // tDocCombo
            // 
            this.tDocCombo.FormattingEnabled = true;
            this.tDocCombo.Location = new System.Drawing.Point(133, 25);
            this.tDocCombo.Name = "tDocCombo";
            this.tDocCombo.Size = new System.Drawing.Size(121, 21);
            this.tDocCombo.TabIndex = 39;
            // 
            // nDocTextbox
            // 
            this.nDocTextbox.Location = new System.Drawing.Point(154, 52);
            this.nDocTextbox.Name = "nDocTextbox";
            this.nDocTextbox.Size = new System.Drawing.Size(100, 20);
            this.nDocTextbox.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Número de documento: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Tipo de documento: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.botonBuscarCli);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tDocCombo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.nDocTextbox);
            this.groupBox1.Location = new System.Drawing.Point(26, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 100);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda de clientes";
            // 
            // Reg_Checkin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 315);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.botonRegistrarEstadia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botonAltaCli);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.botonRemoveHab);
            this.Controls.Add(this.botonAddHab);
            this.Controls.Add(this.tablaClientesEnEstadia);
            this.Controls.Add(this.tablaClientesTotal);
            this.Name = "Reg_Checkin";
            this.Text = "Checkin";
            ((System.ComponentModel.ISupportInitialize)(this.tablaClientesEnEstadia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaClientesTotal)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button botonRemoveHab;
        private System.Windows.Forms.Button botonAddHab;
        private System.Windows.Forms.DataGridView tablaClientesEnEstadia;
        private System.Windows.Forms.DataGridView tablaClientesTotal;
        private System.Windows.Forms.Button botonAltaCli;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botonRegistrarEstadia;
        private System.Windows.Forms.Button botonBuscarCli;
        private System.Windows.Forms.ComboBox tDocCombo;
        private System.Windows.Forms.TextBox nDocTextbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
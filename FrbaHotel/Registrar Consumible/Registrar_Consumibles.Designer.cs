namespace FrbaHotel.Registrar_Consumible
{
    partial class Registrar_Consumibles
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.botonRemoveHab = new System.Windows.Forms.Button();
            this.botonAddHab = new System.Windows.Forms.Button();
            this.tablaConsEnEstadia = new System.Windows.Forms.DataGridView();
            this.tablaConsDisp = new System.Windows.Forms.DataGridView();
            this.botonConfirmar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.HabsCombo = new System.Windows.Forms.ComboBox();
            this.botonConfYfact = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablaConsEnEstadia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaConsDisp)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(290, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Consumibles de la estadía:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Consumibles Disponibles:";
            // 
            // botonRemoveHab
            // 
            this.botonRemoveHab.Location = new System.Drawing.Point(207, 86);
            this.botonRemoveHab.Name = "botonRemoveHab";
            this.botonRemoveHab.Size = new System.Drawing.Size(57, 23);
            this.botonRemoveHab.TabIndex = 30;
            this.botonRemoveHab.Text = "<<";
            this.botonRemoveHab.UseVisualStyleBackColor = true;
            this.botonRemoveHab.Click += new System.EventHandler(this.botonRemoveCons_Click);
            // 
            // botonAddHab
            // 
            this.botonAddHab.Location = new System.Drawing.Point(207, 45);
            this.botonAddHab.Name = "botonAddHab";
            this.botonAddHab.Size = new System.Drawing.Size(57, 23);
            this.botonAddHab.TabIndex = 29;
            this.botonAddHab.Text = ">>";
            this.botonAddHab.UseVisualStyleBackColor = true;
            this.botonAddHab.Click += new System.EventHandler(this.botonAddCons_Click);
            // 
            // tablaConsEnEstadia
            // 
            this.tablaConsEnEstadia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaConsEnEstadia.Location = new System.Drawing.Point(293, 39);
            this.tablaConsEnEstadia.Name = "tablaConsEnEstadia";
            this.tablaConsEnEstadia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaConsEnEstadia.Size = new System.Drawing.Size(265, 105);
            this.tablaConsEnEstadia.TabIndex = 28;
            this.tablaConsEnEstadia.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgv_RowPrePaint);
            // 
            // tablaConsDisp
            // 
            this.tablaConsDisp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaConsDisp.Location = new System.Drawing.Point(20, 39);
            this.tablaConsDisp.Name = "tablaConsDisp";
            this.tablaConsDisp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaConsDisp.Size = new System.Drawing.Size(164, 105);
            this.tablaConsDisp.TabIndex = 27;
            this.tablaConsDisp.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgv_RowPrePaint);
            // 
            // botonConfirmar
            // 
            this.botonConfirmar.Location = new System.Drawing.Point(306, 170);
            this.botonConfirmar.Name = "botonConfirmar";
            this.botonConfirmar.Size = new System.Drawing.Size(75, 23);
            this.botonConfirmar.TabIndex = 33;
            this.botonConfirmar.Text = "Confirmar";
            this.botonConfirmar.UseVisualStyleBackColor = true;
            this.botonConfirmar.Click += new System.EventHandler(this.botonConfirmar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Cargarlo a la habitación: ";
            // 
            // HabsCombo
            // 
            this.HabsCombo.FormattingEnabled = true;
            this.HabsCombo.Location = new System.Drawing.Point(154, 172);
            this.HabsCombo.Name = "HabsCombo";
            this.HabsCombo.Size = new System.Drawing.Size(75, 21);
            this.HabsCombo.TabIndex = 35;
            // 
            // botonConfYfact
            // 
            this.botonConfYfact.Location = new System.Drawing.Point(410, 170);
            this.botonConfYfact.Name = "botonConfYfact";
            this.botonConfYfact.Size = new System.Drawing.Size(134, 23);
            this.botonConfYfact.TabIndex = 36;
            this.botonConfYfact.Text = "Confirmar y facturar";
            this.botonConfYfact.UseVisualStyleBackColor = true;
            this.botonConfYfact.Click += new System.EventHandler(this.botonConfYfact_Click);
            // 
            // Registrar_Consumibles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 205);
            this.Controls.Add(this.botonConfYfact);
            this.Controls.Add(this.HabsCombo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botonConfirmar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.botonRemoveHab);
            this.Controls.Add(this.botonAddHab);
            this.Controls.Add(this.tablaConsEnEstadia);
            this.Controls.Add(this.tablaConsDisp);
            this.Name = "Registrar_Consumibles";
            this.Text = "Registrar Consumibles";
            ((System.ComponentModel.ISupportInitialize)(this.tablaConsEnEstadia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaConsDisp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button botonRemoveHab;
        private System.Windows.Forms.Button botonAddHab;
        private System.Windows.Forms.DataGridView tablaConsEnEstadia;
        private System.Windows.Forms.DataGridView tablaConsDisp;
        private System.Windows.Forms.Button botonConfirmar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox HabsCombo;
        private System.Windows.Forms.Button botonConfYfact;
    }
}
namespace FrbaHotel.Listado_Estadistico
{
    partial class Listados_Estadisticos
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
            this.comboAnio = new System.Windows.Forms.ComboBox();
            this.comboTrimestre = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboReporte = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listaDeResultados = new System.Windows.Forms.DataGridView();
            this.botonGenerarReporte = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listaDeResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Año: ";
            // 
            // comboAnio
            // 
            this.comboAnio.FormattingEnabled = true;
            this.comboAnio.Location = new System.Drawing.Point(62, 15);
            this.comboAnio.Name = "comboAnio";
            this.comboAnio.Size = new System.Drawing.Size(55, 21);
            this.comboAnio.TabIndex = 1;
            // 
            // comboTrimestre
            // 
            this.comboTrimestre.FormattingEnabled = true;
            this.comboTrimestre.Location = new System.Drawing.Point(214, 15);
            this.comboTrimestre.Name = "comboTrimestre";
            this.comboTrimestre.Size = new System.Drawing.Size(42, 21);
            this.comboTrimestre.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Trimestre: ";
            // 
            // comboReporte
            // 
            this.comboReporte.FormattingEnabled = true;
            this.comboReporte.Location = new System.Drawing.Point(352, 15);
            this.comboReporte.Name = "comboReporte";
            this.comboReporte.Size = new System.Drawing.Size(210, 21);
            this.comboReporte.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Top 5 de: ";
            // 
            // listaDeResultados
            // 
            this.listaDeResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaDeResultados.Location = new System.Drawing.Point(40, 66);
            this.listaDeResultados.Name = "listaDeResultados";
            this.listaDeResultados.Size = new System.Drawing.Size(680, 184);
            this.listaDeResultados.TabIndex = 6;
            // 
            // botonGenerarReporte
            // 
            this.botonGenerarReporte.Location = new System.Drawing.Point(592, 13);
            this.botonGenerarReporte.Name = "botonGenerarReporte";
            this.botonGenerarReporte.Size = new System.Drawing.Size(128, 23);
            this.botonGenerarReporte.TabIndex = 7;
            this.botonGenerarReporte.Text = "Generar Reporte";
            this.botonGenerarReporte.UseVisualStyleBackColor = true;
            this.botonGenerarReporte.Click += new System.EventHandler(this.botonGenerarReporte_Click);
            // 
            // Listados_Estadisticos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 280);
            this.Controls.Add(this.botonGenerarReporte);
            this.Controls.Add(this.listaDeResultados);
            this.Controls.Add(this.comboReporte);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboTrimestre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboAnio);
            this.Controls.Add(this.label1);
            this.Name = "Listados_Estadisticos";
            this.Text = "Listados Estadísticos";
            ((System.ComponentModel.ISupportInitialize)(this.listaDeResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboAnio;
        private System.Windows.Forms.ComboBox comboTrimestre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboReporte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView listaDeResultados;
        private System.Windows.Forms.Button botonGenerarReporte;
    }
}
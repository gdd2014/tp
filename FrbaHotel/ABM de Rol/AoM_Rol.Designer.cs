namespace FrbaHotel.ABM_de_Rol
{
    partial class AoM_Rol
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
            this.nombreRolTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.funcsListbox = new System.Windows.Forms.ListBox();
            this.activoCheckbox = new System.Windows.Forms.CheckBox();
            this.botonGuardar = new System.Windows.Forms.Button();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del Rol * :";
            // 
            // nombreRolTextbox
            // 
            this.nombreRolTextbox.Location = new System.Drawing.Point(111, 15);
            this.nombreRolTextbox.Name = "nombreRolTextbox";
            this.nombreRolTextbox.Size = new System.Drawing.Size(145, 20);
            this.nombreRolTextbox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Funcionalidades * :";
            // 
            // funcsListbox
            // 
            this.funcsListbox.FormattingEnabled = true;
            this.funcsListbox.Location = new System.Drawing.Point(111, 52);
            this.funcsListbox.Name = "funcsListbox";
            this.funcsListbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.funcsListbox.Size = new System.Drawing.Size(145, 147);
            this.funcsListbox.TabIndex = 2;
            // 
            // activoCheckbox
            // 
            this.activoCheckbox.AutoSize = true;
            this.activoCheckbox.Location = new System.Drawing.Point(15, 220);
            this.activoCheckbox.Name = "activoCheckbox";
            this.activoCheckbox.Size = new System.Drawing.Size(56, 17);
            this.activoCheckbox.TabIndex = 3;
            this.activoCheckbox.Text = "Activo";
            this.activoCheckbox.UseVisualStyleBackColor = true;
            // 
            // botonGuardar
            // 
            this.botonGuardar.Location = new System.Drawing.Point(37, 255);
            this.botonGuardar.Name = "botonGuardar";
            this.botonGuardar.Size = new System.Drawing.Size(75, 26);
            this.botonGuardar.TabIndex = 4;
            this.botonGuardar.Text = "Guardar";
            this.botonGuardar.UseVisualStyleBackColor = true;
            this.botonGuardar.Click += new System.EventHandler(this.botonGuardar_Click);
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(161, 255);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(75, 26);
            this.botonLimpiar.TabIndex = 5;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // AoM_Rol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 293);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.botonGuardar);
            this.Controls.Add(this.activoCheckbox);
            this.Controls.Add(this.funcsListbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nombreRolTextbox);
            this.Controls.Add(this.label1);
            this.Name = "AoM_Rol";
            this.Text = "Alta de Rol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nombreRolTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox funcsListbox;
        private System.Windows.Forms.CheckBox activoCheckbox;
        private System.Windows.Forms.Button botonGuardar;
        private System.Windows.Forms.Button botonLimpiar;
    }
}
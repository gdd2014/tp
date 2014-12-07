namespace FrbaHotel.ABM_de_Rol
{
    partial class ABM_Roles {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
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
            this.titulo = new System.Windows.Forms.Label();
            this.tablaDeRoles = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Location = new System.Drawing.Point(32, 21);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(184, 13);
            this.titulo.TabIndex = 0;
            this.titulo.Text = "Altas bajas y modificaciones de Roles";
            this.titulo.Click += new System.EventHandler(this.titulo_Click);
            // 
            // tablaDeRoles
            // 
            this.tablaDeRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDeRoles.Location = new System.Drawing.Point(35, 64);
            this.tablaDeRoles.Name = "tablaDeRoles";
            this.tablaDeRoles.Size = new System.Drawing.Size(444, 150);
            this.tablaDeRoles.TabIndex = 1;
            this.tablaDeRoles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaDeRoles_CellContentClick);
            // 
            // ABM_Roles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 298);
            this.Controls.Add(this.tablaDeRoles);
            this.Controls.Add(this.titulo);
            this.Name = "ABM_Roles";
            this.Text = "ABM de Roles";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeRoles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.DataGridView tablaDeRoles;


    }
}
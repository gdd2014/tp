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
            this.nombreDeRolTb = new System.Windows.Forms.TextBox();
            this.buscarButton = new System.Windows.Forms.Button();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.eliminarRolButton = new System.Windows.Forms.Button();
            this.modificarRolButton = new System.Windows.Forms.Button();
            this.nuevoRolButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Location = new System.Drawing.Point(32, 21);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(86, 13);
            this.titulo.TabIndex = 0;
            this.titulo.Text = "Nombre del Rol: ";
            this.titulo.Click += new System.EventHandler(this.titulo_Click);
            // 
            // tablaDeRoles
            // 
            this.tablaDeRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDeRoles.Location = new System.Drawing.Point(35, 64);
            this.tablaDeRoles.Name = "tablaDeRoles";
            this.tablaDeRoles.Size = new System.Drawing.Size(383, 150);
            this.tablaDeRoles.TabIndex = 1;
            this.tablaDeRoles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaDeRoles_CellContentClick);
            // 
            // nombreDeRolTb
            // 
            this.nombreDeRolTb.Location = new System.Drawing.Point(124, 18);
            this.nombreDeRolTb.Name = "nombreDeRolTb";
            this.nombreDeRolTb.Size = new System.Drawing.Size(100, 20);
            this.nombreDeRolTb.TabIndex = 2;
            this.nombreDeRolTb.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // buscarButton
            // 
            this.buscarButton.Location = new System.Drawing.Point(291, 16);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(75, 23);
            this.buscarButton.TabIndex = 3;
            this.buscarButton.Text = "Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(386, 16);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(75, 23);
            this.limpiarButton.TabIndex = 4;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            // 
            // eliminarRolButton
            // 
            this.eliminarRolButton.Location = new System.Drawing.Point(42, 246);
            this.eliminarRolButton.Name = "eliminarRolButton";
            this.eliminarRolButton.Size = new System.Drawing.Size(75, 23);
            this.eliminarRolButton.TabIndex = 5;
            this.eliminarRolButton.Text = "Eliminar Rol";
            this.eliminarRolButton.UseVisualStyleBackColor = true;
            // 
            // modificarRolButton
            // 
            this.modificarRolButton.Location = new System.Drawing.Point(134, 246);
            this.modificarRolButton.Name = "modificarRolButton";
            this.modificarRolButton.Size = new System.Drawing.Size(90, 23);
            this.modificarRolButton.TabIndex = 6;
            this.modificarRolButton.Text = "Modificar Rol";
            this.modificarRolButton.UseVisualStyleBackColor = true;
            // 
            // nuevoRolButton
            // 
            this.nuevoRolButton.Location = new System.Drawing.Point(386, 246);
            this.nuevoRolButton.Name = "nuevoRolButton";
            this.nuevoRolButton.Size = new System.Drawing.Size(75, 23);
            this.nuevoRolButton.TabIndex = 7;
            this.nuevoRolButton.Text = "Nuevo Rol";
            this.nuevoRolButton.UseVisualStyleBackColor = true;
            // 
            // ABM_Roles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 285);
            this.Controls.Add(this.nuevoRolButton);
            this.Controls.Add(this.modificarRolButton);
            this.Controls.Add(this.eliminarRolButton);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.buscarButton);
            this.Controls.Add(this.nombreDeRolTb);
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
        private System.Windows.Forms.TextBox nombreDeRolTb;
        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Button eliminarRolButton;
        private System.Windows.Forms.Button modificarRolButton;
        private System.Windows.Forms.Button nuevoRolButton;


    }
}
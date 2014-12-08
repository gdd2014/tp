using System.Windows.Forms;
namespace FrbaHotel.ABM_de_Usuario
{
    partial class ABM_Usuarios
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
            this.uNameLabel = new System.Windows.Forms.Label();
            this.uNameTextbox = new System.Windows.Forms.TextBox();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.tablaUsuarios = new System.Windows.Forms.DataGridView();
            this.botonNuevoUsuario = new System.Windows.Forms.Button();
            this.botonEliminarUsuario = new System.Windows.Forms.Button();
            this.botonModificarUsuario = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablaUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // uNameLabel
            // 
            this.uNameLabel.AutoSize = true;
            this.uNameLabel.Location = new System.Drawing.Point(27, 25);
            this.uNameLabel.Name = "uNameLabel";
            this.uNameLabel.Size = new System.Drawing.Size(101, 13);
            this.uNameLabel.TabIndex = 0;
            this.uNameLabel.Text = "Nombre de Usuario:";
            // 
            // uNameTextbox
            // 
            this.uNameTextbox.Location = new System.Drawing.Point(146, 22);
            this.uNameTextbox.Name = "uNameTextbox";
            this.uNameTextbox.Size = new System.Drawing.Size(100, 20);
            this.uNameTextbox.TabIndex = 1;
            // 
            // botonBuscar
            // 
            this.botonBuscar.Location = new System.Drawing.Point(286, 19);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(75, 23);
            this.botonBuscar.TabIndex = 2;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.UseVisualStyleBackColor = true;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(400, 19);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.botonLimpiar.TabIndex = 3;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // tablaUsuarios
            // 
            this.tablaUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaUsuarios.Location = new System.Drawing.Point(30, 72);
            this.tablaUsuarios.MultiSelect = false;
            this.tablaUsuarios.Name = "tablaUsuarios";
            this.tablaUsuarios.Size = new System.Drawing.Size(564, 150);
            this.tablaUsuarios.TabIndex = 4;
            this.tablaUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaUsuarios.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgv_RowPrePaint);
            // 
            // botonNuevoUsuario
            // 
            this.botonNuevoUsuario.Location = new System.Drawing.Point(494, 242);
            this.botonNuevoUsuario.Name = "botonNuevoUsuario";
            this.botonNuevoUsuario.Size = new System.Drawing.Size(100, 23);
            this.botonNuevoUsuario.TabIndex = 5;
            this.botonNuevoUsuario.Text = "Nuevo Usuario";
            this.botonNuevoUsuario.UseVisualStyleBackColor = true;
            this.botonNuevoUsuario.Click += new System.EventHandler(this.botonNuevoUsuario_Click);
            // 
            // botonEliminarUsuario
            // 
            this.botonEliminarUsuario.Location = new System.Drawing.Point(36, 242);
            this.botonEliminarUsuario.Name = "botonEliminarUsuario";
            this.botonEliminarUsuario.Size = new System.Drawing.Size(92, 23);
            this.botonEliminarUsuario.TabIndex = 6;
            this.botonEliminarUsuario.Text = "Eliminar Usuario";
            this.botonEliminarUsuario.UseVisualStyleBackColor = true;
            this.botonEliminarUsuario.Click += new System.EventHandler(this.botonEliminarUsuario_Click);
            // 
            // botonModificarUsuario
            // 
            this.botonModificarUsuario.Location = new System.Drawing.Point(155, 242);
            this.botonModificarUsuario.Name = "botonModificarUsuario";
            this.botonModificarUsuario.Size = new System.Drawing.Size(100, 23);
            this.botonModificarUsuario.TabIndex = 7;
            this.botonModificarUsuario.Text = "Modificar Usuario";
            this.botonModificarUsuario.UseVisualStyleBackColor = true;
            this.botonModificarUsuario.Click += new System.EventHandler(this.botonModificarUsuario_Click);
            // 
            // ABM_Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 286);
            this.Controls.Add(this.botonModificarUsuario);
            this.Controls.Add(this.botonEliminarUsuario);
            this.Controls.Add(this.botonNuevoUsuario);
            this.Controls.Add(this.tablaUsuarios);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.botonBuscar);
            this.Controls.Add(this.uNameTextbox);
            this.Controls.Add(this.uNameLabel);
            this.Name = "ABM_Usuarios";
            this.Text = "ABM de Usuarios";
            ((System.ComponentModel.ISupportInitialize)(this.tablaUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uNameLabel;
        private System.Windows.Forms.TextBox uNameTextbox;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.DataGridView tablaUsuarios;
        private System.Windows.Forms.Button botonNuevoUsuario;
        private Button botonEliminarUsuario;
        private Button botonModificarUsuario;
    }
}
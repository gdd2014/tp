namespace FrbaHotel.Menu_Principal
{
    partial class MenuPrincipalForm
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
            this.mensajeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mensajeLabel
            // 
            this.mensajeLabel.AutoSize = true;
            this.mensajeLabel.Location = new System.Drawing.Point(90, 9);
            this.mensajeLabel.Name = "mensajeLabel";
            this.mensajeLabel.Size = new System.Drawing.Size(101, 13);
            this.mensajeLabel.TabIndex = 0;
            this.mensajeLabel.Text = "¿Qué desea hacer?";
            // 
            // MenuPrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 204);
            this.Controls.Add(this.mensajeLabel);
            this.Name = "MenuPrincipalForm";
            this.Text = "G_N Administración Hotelera";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mensajeLabel;
    }
}
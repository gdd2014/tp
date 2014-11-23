using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel
{
    public partial class ventanaPrincipal : Form
    {
        public ventanaPrincipal()
        {
            InitializeComponent();
        }

        private void botonRoles_Click(object sender, EventArgs e) {
            // Create a new instance of the Form2 class
            ABM_de_Rol.ABM_Roles rolesForm = new ABM_de_Rol.ABM_Roles();

            // Show the settings form
            rolesForm.Show();
        }

    }
}

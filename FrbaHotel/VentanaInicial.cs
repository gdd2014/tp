using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel {
    public partial class ventanaInicial : Form {
        public ventanaInicial() {
            InitializeComponent();
        }

        private void botonLogin_Click(object sender, EventArgs e) {
            // Create a new instance of the Form2 class
            Login.LoginForm loginForm = new Login.LoginForm();

            // Show the settings form
            this.Hide();
            loginForm.Show();
        }

       
        private void botonGuest_Click(object sender, EventArgs e) {
            
            Menu_Principal.MenuPrincipalForm mainMenu = new Menu_Principal.MenuPrincipalForm(-1, 3, -1);

            // Show the settings form
            mainMenu.Show();
        }

    }
}

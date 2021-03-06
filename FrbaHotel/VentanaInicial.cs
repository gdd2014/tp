﻿using System;
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
            
            Login.LoginForm loginForm = new Login.LoginForm();

            this.Hide();
            loginForm.Show();
        }

       
        private void botonGuest_Click(object sender, EventArgs e) {
            
            Menu_Principal.MenuPrincipalForm mainMenu = new Menu_Principal.MenuPrincipalForm(-1, 3, -1);

            this.Hide();
            // Show the settings form
            mainMenu.Show();
        }

    }
}

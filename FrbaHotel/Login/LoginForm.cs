using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Utils;
using FrbaHotel.Menu_Principal;
using System.Data.SqlClient;

namespace FrbaHotel.Login {
    public partial class LoginForm : Form {
        public LoginForm() {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e) {
            String user = userTextbox.Text;
            String pwrd = StringUtils.getHashSha256(passwordTextbox.Text);

            SqlConnection con = ConnectionUtils.getOpenConnection();

            String loginQuery = "SELECT Usuario_Id FROM G_N.Usuarios WHERE Usuario_UserName=@un AND Usuario_Password=@pw" + ConnectionUtils.soloActivos();

            SqlCommand loginCmd = new SqlCommand(loginQuery, con);
            loginCmd.Parameters.AddWithValue("un", user);
            loginCmd.Parameters.AddWithValue("pw", pwrd);

            SqlDataReader reader = loginCmd.ExecuteReader();
            int userId = -1;
            if (reader.Read()) {
                userId = reader.GetInt32(0);
            }

            reader.Close();

            if (userId == -1) {
                MessageBox.Show("Usuario y/o contraseña incorrectos...");
            } else {
                // Verifico Roles...
                String rolesDeUsuarioQuery = "SELECT ur.Rol_Id FROM G_N.Usuarios_Roles ur JOIN G_N.Roles r ON ur.Rol_Id = r.Rol_Id " +
                                                "WHERE ur.Usuario_Id=@uid " + ConnectionUtils.soloActivos();
                SqlCommand rolesCmd = new SqlCommand(rolesDeUsuarioQuery, con);
                rolesCmd.Parameters.AddWithValue("uid", userId);

                List<int> roles = new List<int>();

                SqlDataReader rolesReader = rolesCmd.ExecuteReader();
                while (rolesReader.Read()) {
                    roles.Add(rolesReader.GetInt32(0));
                }
                rolesReader.Close();

                // Verifico Hoteles...
                String hotelesDeUsuarioQuery = "SELECT uh.Hotel_Id FROM G_N.Usuarios_Hoteles uh JOIN G_N.Hoteles h ON uh.Hotel_Id = h.Hotel_Id " +
                                                    "WHERE uh.Usuario_Id=@uid " + ConnectionUtils.soloActivos();
                SqlCommand hotelesCmd = new SqlCommand(hotelesDeUsuarioQuery, con);
                hotelesCmd.Parameters.AddWithValue("uid", userId);

                List<int> hoteles = new List<int>();
                SqlDataReader hotelesReader = hotelesCmd.ExecuteReader();
                while (hotelesReader.Read()) {
                    hoteles.Add(hotelesReader.GetInt32(0));
                }
                hotelesReader.Close();

                this.Close();

                // Verifico si tiene un rol y hotel o varios...
                if (roles.Count == 1 & hoteles.Count == 1) {
                    MenuPrincipalForm mpf = new MenuPrincipalForm(userId, roles.First(), hoteles.First());
                    mpf.Show();
                } else {
                    SeleccionDeRolYHotelForm srhf = new SeleccionDeRolYHotelForm(userId);
                    srhf.Show();
                }
            }

            con.Close();            
        }

    }
}

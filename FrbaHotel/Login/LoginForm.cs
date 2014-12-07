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

            SqlConnection con = DBUtils.getOpenConnection();

            String loginQuery = "SELECT Usuario_Id FROM G_N.Usuarios WHERE Usuario_UserName=@un AND Usuario_Password=@pw" + DBUtils.ySoloActivos();

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
                DBUtils.ejecutarSP1SoloParam("Registrar_Login_Fallido", "@Username", userTextbox.Text);
                MessageBox.Show("Usuario y/o contraseña incorrectos...");
            } else {
                // Verifico Roles...
                String rolesDeUsuarioQuery = "SELECT ur.Rol_Id FROM G_N.Usuarios_Roles ur JOIN G_N.Roles r ON ur.Rol_Id = r.Rol_Id " +
                                                "WHERE ur.Usuario_Id=" + userId + DBUtils.ySoloActivos();

                List<int> roles = DBUtils.queryRetornaIds(rolesDeUsuarioQuery);

                
                // Verifico Hoteles...
                String hotelesDeUsuarioQuery = "SELECT uh.Hotel_Id FROM G_N.Usuarios_Hoteles uh JOIN G_N.Hoteles h ON uh.Hotel_Id = h.Hotel_Id " +
                                                    "WHERE uh.Usuario_Id=" + userId + DBUtils.ySoloActivos();

                List<int> hoteles = DBUtils.queryRetornaIds(hotelesDeUsuarioQuery);
                
                this.Close();

                // Verifico si tiene un solo rol y hotel o varios...
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

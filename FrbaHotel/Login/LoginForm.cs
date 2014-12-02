using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Utils;
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

            String loginQuery = "SELECT Usuario_Id FROM G_N.Usuarios WHERE Usuario_UserName=@un AND Usuario_Password=@pw";

            SqlCommand loginCmd = new SqlCommand(loginQuery, con);
            loginCmd.Parameters.AddWithValue("un", user);
            loginCmd.Parameters.AddWithValue("pw", pwrd);

            SqlDataReader reader = loginCmd.ExecuteReader();
            int userId = -1;
            if (reader.Read()){
                userId = reader.GetInt32(0);
            }

            reader.Close();

            if (userId == -1) {
                MessageBox.Show("Usuario y/o contraseña incorrectos...");
            } else {
                String rolesDeUsuarioQuery = "SELECT Rol_Id FROM G_N.Usuarios_Roles WHERE Usuario_Id=@uid";
                SqlCommand rolesCmd = new SqlCommand(rolesDeUsuarioQuery, con);
                rolesCmd.Parameters.AddWithValue("uid", userId);

                List<int> roles = new List<int>();

                SqlDataReader rolesReader = rolesCmd.ExecuteReader();
                while (rolesReader.Read()) {
                    roles.Add(rolesReader.GetInt32(0));
                }

                if (roles.Count == 1) {
                    MessageBox.Show("Tiene un solo rol");
                } else {
                    MessageBox.Show("Debe elegir un rol");
                }
            }

            con.Close();            
        }

    }
}

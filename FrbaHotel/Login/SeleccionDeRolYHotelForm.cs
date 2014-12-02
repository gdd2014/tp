using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Utils;
using FrbaHotel.Menu_Principal;

namespace FrbaHotel.Login {
    public partial class SeleccionDeRolYHotelForm : Form {
        int userId;

        public SeleccionDeRolYHotelForm(int idDeUsuario) {
            this.userId = idDeUsuario;
            InitializeComponent();

            SqlConnection con = ConnectionUtils.getOpenConnection();

            // Lleno el combo de roles...
            String rolesQuery = "SELECT r.Rol_Id AS rolId, Rol_Nombre AS rolName FROM G_N.Roles r " + 
                                    "JOIN G_N.Usuarios_Roles ur ON r.Rol_Id = ur.Rol_Id " +
	                                "WHERE ur.Usuario_Id=@uid " + ConnectionUtils.soloActivos();

            SqlCommand rolesCmd = new SqlCommand(rolesQuery, con);
            rolesCmd.Parameters.AddWithValue("uid", userId);

            SqlDataReader rolesReader = rolesCmd.ExecuteReader();
            DataTable rolesDT = new DataTable();
            rolesDT.Columns.Add("rolId", typeof(string));
            rolesDT.Columns.Add("rolName", typeof(string));
            rolesDT.Load(rolesReader);

            rolesCombo.ValueMember = "rolId";
            rolesCombo.DisplayMember = "rolName";
            rolesCombo.DataSource = rolesDT;

            // Lleno el combo de hoteles...
            String hotelesQuery = "SELECT h.Hotel_Id AS hotelId, h.Hotel_Dom_Calle + ' ' + CAST(h.Hotel_Dom_Nro AS NVARCHAR) AS hotelDom FROM G_N.Hoteles h " +
                                     "JOIN G_N.Usuarios_Hoteles uh ON h.Hotel_Id = uh.Hotel_Id " +
                                     "WHERE uh.Usuario_Id=@uid " + ConnectionUtils.soloActivos();

            SqlCommand hotelesCmd = new SqlCommand(hotelesQuery, con);
            hotelesCmd.Parameters.AddWithValue("uid", userId);

            SqlDataReader hotelesReader = hotelesCmd.ExecuteReader();
            DataTable hotelesDT = new DataTable();
            hotelesDT.Columns.Add("hotelId", typeof(string));
            hotelesDT.Columns.Add("hotelDom", typeof(string));
            hotelesDT.Load(hotelesReader);

            hotelesCombo.ValueMember = "hotelId";
            hotelesCombo.DisplayMember = "hotelDom";
            hotelesCombo.DataSource = hotelesDT;

            con.Close();
        }

        private void botonContinuar_Click(object sender, EventArgs e) {
            int rolId = Int32.Parse(rolesCombo.SelectedValue.ToString());
            int hotelId = Int32.Parse(hotelesCombo.SelectedValue.ToString());

            MenuPrincipalForm mpf = new MenuPrincipalForm(userId, rolId, hotelId);

            this.Close();
            mpf.Show();
        }
        
    }
}

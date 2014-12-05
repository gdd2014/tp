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

            SqlConnection con = DBUtils.getOpenConnection();

            // Lleno el combo de roles...
            String rolesQuery = "SELECT r.Rol_Id AS rolId, Rol_Nombre AS rolName FROM G_N.Roles r " + 
                                    "JOIN G_N.Usuarios_Roles ur ON r.Rol_Id = ur.Rol_Id " +
	                                "WHERE ur.Usuario_Id=" + userId + DBUtils.ySoloActivos();

            DBUtils.llenarComboBox(rolesCombo, rolesQuery, "rolId", "rolName");

            // Lleno el combo de hoteles...
            String hotelesQuery = "SELECT h.Hotel_Id AS hotelId, h.Hotel_Dom_Calle + ' ' + CAST(h.Hotel_Dom_Nro AS NVARCHAR) AS hotelDom FROM G_N.Hoteles h " +
                                     "JOIN G_N.Usuarios_Hoteles uh ON h.Hotel_Id = uh.Hotel_Id " +
                                     "WHERE uh.Usuario_Id=" + userId + DBUtils.ySoloActivos();


            DBUtils.llenarComboBox(hotelesCombo, hotelesQuery, "hotelId", "hotelDom");
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

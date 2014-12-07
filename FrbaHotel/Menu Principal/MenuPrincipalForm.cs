using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using FrbaHotel.Utils;
using FrbaHotel.ABM_de_Usuario;

using System.Windows.Forms;

namespace FrbaHotel.Menu_Principal {
    public partial class MenuPrincipalForm : Form {

        int userId;
        int rolId;
        int hotelId;

        public MenuPrincipalForm(int userId, int rolId, int hotelId) {
            this.userId = userId;
            this.rolId = rolId;
            this.hotelId = hotelId;

            InitializeComponent();

            String funcionesPorRolQuery = "SELECT Funcionalidad_Id FROM G_N.Roles_Funcionalidades WHERE Rol_Id=" + rolId;

            List<int> funcionalidades = DBUtils.queryRetornaIds(funcionesPorRolQuery);

            botonAbmUsuarios.Enabled = funcionalidades.Contains(12);
        }

        private void botonAbmUsuarios_Click(object sender, EventArgs e) {
            ABM_Usuarios uf = new ABM_Usuarios(userId, rolId, hotelId);
            uf.Show();

        }

      
    }
}

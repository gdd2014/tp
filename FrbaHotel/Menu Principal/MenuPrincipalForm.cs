using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using FrbaHotel.Utils;
using FrbaHotel.ABM_de_Usuario;
using FrbaHotel.ABM_de_Rol;
using FrbaHotel.ABM_de_Cliente;
using FrbaHotel.ABM_de_Hotel;

using System.Windows.Forms;

namespace FrbaHotel.Menu_Principal {
    public partial class MenuPrincipalForm : Form {

        Decimal userId;
        Decimal rolId;
        Decimal hotelId;

        public MenuPrincipalForm(Decimal userId, Decimal rolId, Decimal hotelId) {
            this.userId = userId;
            this.rolId = rolId;
            this.hotelId = hotelId;

            InitializeComponent();

            String funcionesPorRolQuery = "SELECT Funcionalidad_Id FROM G_N.Roles_Funcionalidades WHERE Rol_Id=" + rolId;

            List<int> funcionalidades = DBUtils.queryRetornaInts(funcionesPorRolQuery);

            botonAbmUsuarios.Enabled = funcionalidades.Contains(12);
            botonAbmRoles.Enabled = funcionalidades.Contains(13);
            botonAbmClientes.Enabled = funcionalidades.Contains(1);
            botonAbmHoteles.Enabled = funcionalidades.Contains(2);
        }

        private void botonAbmUsuarios_Click(object sender, EventArgs e) {
            ABM_Usuarios uf = new ABM_Usuarios(userId, rolId, hotelId);
            uf.Show();
        }

        private void botonABMRoles_Click(object sender, EventArgs e) {
            ABM_Roles rf = new ABM_Roles();
            rf.Show();
        }

        private void botonAbmClientes_Click(object sender, EventArgs e) {
            ABM_Clientes cf = new ABM_Clientes();
            cf.Show();
        }

        private void botonAbmHoteles_Click(object sender, EventArgs e) {
            ABM_Hoteles hf = new ABM_Hoteles(userId.ToString());
            hf.Show();
        }

      
    }
}

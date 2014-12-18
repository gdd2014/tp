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
using FrbaHotel.ABM_de_Habitacion;
using FrbaHotel.ABM_de_Regimen;
using FrbaHotel.Generar_Modificar_Reserva;
using FrbaHotel.Registrar_Estadia;
using FrbaHotel.Registrar_Consumible;

using System.Windows.Forms;

namespace FrbaHotel.Menu_Principal {
    public partial class MenuPrincipalForm : Form {

        String userId;
        String rolId;
        String hotelId;

        public MenuPrincipalForm(Decimal userId, Decimal rolId, Decimal hotelId) {
            if (userId != -1) this.userId = userId.ToString(); else this.userId = "";
            if (rolId != -1) this.rolId = rolId.ToString(); else this.rolId = "";
            if (hotelId != -1) this.hotelId = hotelId.ToString(); else this.hotelId = "";

            InitializeComponent();

            String funcionesPorRolQuery = "SELECT Funcionalidad_Id FROM G_N.Roles_Funcionalidades WHERE Rol_Id=" + rolId;

            List<int> funcionalidades = DBUtils.queryRetornaInts(funcionesPorRolQuery);

            botonAbmUsuarios.Enabled = funcionalidades.Contains(12);
            botonAbmRoles.Enabled = funcionalidades.Contains(13);
            botonAbmClientes.Enabled = funcionalidades.Contains(1);
            botonAbmHoteles.Enabled = funcionalidades.Contains(2);
            botonAbmHabitaciones.Enabled = funcionalidades.Contains(3);
            botonAbmRegimenes.Enabled = funcionalidades.Contains(4);
            BotonAdmReservas.Enabled = funcionalidades.Contains(5) && funcionalidades.Contains(6) && funcionalidades.Contains(7);
            botonAdmEstadias.Enabled = funcionalidades.Contains(8);
            botonRegCons.Enabled = funcionalidades.Contains(9);
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

        private void botonAbmHabitaciones_Click(object sender, EventArgs e) {
            ABM_Habitaciones hf = new ABM_Habitaciones(hotelId.ToString());
            hf.Show();
        }

        private void botonAbmRegimenes_Click(object sender, EventArgs e) {
            ABM_Regimenes rf = new ABM_Regimenes();
            rf.Show();
        }

        private void BotonAdmReservas_Click(object sender, EventArgs e) {
            if (this.hotelId == "") {
                Seleccion_Hotel sh = new Seleccion_Hotel(userId);
                sh.Show();
            } else {
                Admin_Reservas ar = new Admin_Reservas(hotelId, userId);
                ar.Show();
            }
        }

        private void botomAdmEstadias_Click(object sender, EventArgs e) {
            Admin_Estadias ests = new Admin_Estadias(hotelId);
            ests.Show();
        }

        private void botonRegCons_Click(object sender, EventArgs e) {
            Elegir_Estadia rc = new Elegir_Estadia();
            rc.Show();
        }
       
      
    }
}

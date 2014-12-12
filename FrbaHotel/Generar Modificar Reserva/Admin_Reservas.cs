using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Generar_Modificar_Reserva {

    public partial class Admin_Reservas : Form {

        String hotelId;
        String userId;

        public Admin_Reservas(String hotelId, String userId) {
            this.hotelId = hotelId;
            this.userId = userId;
            InitializeComponent();
        }

        private void botonGenReserva_Click(object sender, EventArgs e) {
            AoM_Reserva aomr = new AoM_Reserva(hotelId, userId);
            aomr.Show();
        }
    }
}

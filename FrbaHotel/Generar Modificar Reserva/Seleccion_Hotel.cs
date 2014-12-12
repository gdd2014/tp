using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Utils;
using FrbaHotel.Generar_Modificar_Reserva;

namespace FrbaHotel.Generar_Modificar_Reserva {
    
    public partial class Seleccion_Hotel : Form {

        String userId;

        public Seleccion_Hotel(String userId) {
            InitializeComponent();
            this.userId = userId;

            // Lleno el combo de hoteles...
            String hotelesQuery = "SELECT h.Hotel_Id AS hotelId, h.Hotel_Dom_Calle + ' ' + CAST(h.Hotel_Dom_Nro AS NVARCHAR) AS hotelDom FROM G_N.Hoteles h ";


            DBUtils.llenarComboBox(hotelesCombo, hotelesQuery, "hotelId", "hotelDom");
        }

        private void botonContinuar_Click(object sender, EventArgs e) {
            String hotelId = UIUtils.valorSeleccionado(hotelesCombo);

            Admin_Reservas ar = new Admin_Reservas(hotelId, this.userId);

            this.Close();
            ar.Show();
        }
    }
}

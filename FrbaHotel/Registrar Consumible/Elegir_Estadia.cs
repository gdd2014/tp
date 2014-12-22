using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Utils;

namespace FrbaHotel.Registrar_Consumible {

    public partial class Elegir_Estadia : Form {

        String hotelId;

        public Elegir_Estadia(String hotelId) {
            this.hotelId = hotelId;
            InitializeComponent();
        }

        private void botonContinuar_Click(object sender, EventArgs e) {
            List<String> errores = validar();
            UIUtils.mostrarErrores(errores);

            if (errores.Count == 0) {
                Registrar_Consumibles rc = new Registrar_Consumibles(codReservaTextbox.Text);

                this.Close();
                rc.Show();
            }
            
        }

        private List<String> validar() {
            List<String> errores = new List<String>();
            UIUtils.validarTextboxCompleto(codReservaTextbox, "Código de Reserva", errores);

            if (errores.Count == 0) {
                int ests = DBUtils.queryRetornaInt("SELECT COUNT(*) FROM G_N.Estadias e JOIN G_N.Reservas r ON e.Estadia_Reserva_Codigo = r.Reserva_Codigo " +
                                                                     " WHERE e.Estadia_Reserva_Codigo=" + codReservaTextbox.Text +
                                                                       " AND G_N.Hotel_De_Reserva(r.Reserva_Codigo)=" + hotelId);
                int facts = DBUtils.queryRetornaInt("SELECT COUNT(*) FROM G_N.Facturas WHERE Factura_Estadia_Reserva_Codigo=" + codReservaTextbox.Text);

                if (ests == 0) {
                    errores.Add("No se encontró la estadía seleccionada, ¿ya hizo el checkin?");
                }
                else if (facts > 0) {
                    errores.Add("La estadia seleccionada ya se encuentra facturada.");
                }
            }


            return errores;
        }

            

        private void soloNumeros(object sender, KeyPressEventArgs e) {
            UIUtils.soloNumeros(e);
        }
    }
}

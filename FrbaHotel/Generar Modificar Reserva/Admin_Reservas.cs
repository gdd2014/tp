using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Utils;
using FrbaHotel.Cancelar_Reserva;

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
            AoM_Reserva aomr = new AoM_Reserva(hotelId, userId, "");
            aomr.Show();
        }

        private void botonCancelar_Click(object sender, EventArgs e) {
            List<String> errores = validarReserva();
            UIUtils.mostrarErrores(errores);

            if (errores.Count == 0) {
                Cancel_Reserva crf = new Cancel_Reserva(codReservaTextbox.Text, userId);
                crf.Show();
            }
        }

       

        private void botonModificar_Click(object sender, EventArgs e) {
            List<String> errores = validarReserva();
            UIUtils.mostrarErrores(errores);

            if (errores.Count == 0) {
                AoM_Reserva modForm = new AoM_Reserva(hotelId, userId, codReservaTextbox.Text);
                modForm.Show();
            }
        }

        private List<String> validarReserva() {
            List<String> errores = new List<string>();

            UIUtils.validarTextboxCompleto(codReservaTextbox, "Código de reserva", errores);

            if (errores.Count == 0) {
                DateTime fInicio = DBUtils.queryRetornaDate("SELECT Reserva_Fecha_Inicio FROM G_N.Reservas WHERE Reserva_Codigo=" + codReservaTextbox.Text + " AND Reserva_Fecha_Cancelacion IS NULL");

                if (fInicio == DateTime.MinValue) {
                    errores.Add("No existe reserva asociada al código seleccionado");
                } else {
                    if (fInicio <= DateTime.Today) {
                        errores.Add("Solo es posible cancelar o modificar reservas hasta un día antes del comienzo de la misma.");
                    }
                }
            }

            return errores;
        }

        private void soloNumeros(object sender, KeyPressEventArgs e) {
            UIUtils.soloNumeros(e);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Utils;

namespace FrbaHotel.Registrar_Estadia {

    public partial class Admin_Estadias : Form {

        String hotelId;

        public Admin_Estadias(String hotelId) {
            this.hotelId = hotelId;
            InitializeComponent();
        }

        private void botonCheckin_Click(object sender, EventArgs e) {
            DateTime fInicio = DBUtils.queryRetornaDate("SELECT Reserva_Fecha_Inicio FROM G_N.Reservas WHERE Reserva_Codigo=" + codReservaTextbox.Text + 
                                                                         " AND Reserva_Fecha_Cancelacion IS NULL" +
                                                                         " AND G_N.Hotel_De_Reserva(Reserva_Codigo)=" + this.hotelId);
            List<String> errores = validarReservaParaCheckin(fInicio);
            UIUtils.mostrarErrores(errores);

            if (errores.Count == 0) {
                Reg_Checkin checkin = new Reg_Checkin(codReservaTextbox.Text);
                checkin.Show();
            }
            
        }

        private void botonCheckout_Click(object sender, EventArgs e) {
            DateTime fInicio = DBUtils.queryRetornaDate("SELECT Reserva_Fecha_Inicio FROM G_N.Reservas WHERE Reserva_Codigo=" + codReservaTextbox.Text + 
                                                                        " AND Reserva_Fecha_Cancelacion IS NULL" +
                                                                        " AND G_N.Hotel_De_Reserva(Reserva_Codigo)=" + this.hotelId);
            DateTime fFin = DBUtils.queryRetornaDate("SELECT Reserva_Fecha_Fin FROM G_N.Reservas WHERE Reserva_Codigo=" + codReservaTextbox.Text + 
                                                                        " AND Reserva_Fecha_Cancelacion IS NULL" +
                                                                        " AND G_N.Hotel_De_Reserva(Reserva_Codigo)=" + this.hotelId);

            List<String> errores = validarReservaParaCheckout(fInicio, fFin);
            UIUtils.mostrarErrores(errores);

            if (errores.Count == 0) {
                if (fFin != DateTime.Today) {
                    DialogResult dr = MessageBox.Show("Por más que se retire antes de tiempo deberá abonar la totalidad de su reserva. ¿Desea continuar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes) {
                        DBUtils.actualizar("Estadias", new List<String>() { "Estadia_Fecha_Fin" }, new List<String>() { DBUtils.stringify(ConversionUtils.dateTimeAStr(DateTime.Today)) }, "Estadia_Reserva_Codigo", codReservaTextbox.Text);
                    }
                } else {
                    DBUtils.actualizar("Estadias", new List<String>() { "Estadia_Fecha_Fin" }, new List<String>() { DBUtils.stringify(ConversionUtils.dateTimeAStr(DateTime.Today)) }, "Estadia_Reserva_Codigo", codReservaTextbox.Text);
                }

                MessageBox.Show("Checkout informado exitosamente");
            }
        }
        
        private List<String> validarReservaParaCheckin(DateTime fInicio) {
            List<String> errores = new List<String>();

            UIUtils.validarTextboxCompleto(codReservaTextbox, "Código de reserva", errores);

            if (errores.Count == 0) {

                if (fInicio == DateTime.MinValue) {
                    errores.Add("No existe reserva asociada al código seleccionado en este hotel.");
                } else if (fInicio != DateTime.Today) {
                    errores.Add("Solo es posible registrar checkins de reservas que comienzan en el día de la fecha");
                } else {
                     int existeEstadia = DBUtils.queryRetornaInt("SELECT COUNT (*) FROM G_N.Estadias WHERE Estadia_Reserva_Codigo=" + codReservaTextbox.Text);
                     if (existeEstadia != 0) {
                         errores.Add("Ya registró el checkin para la reserva ingresada.");
                     }
                }
            }

            return errores;
        }

        private List<String> validarReservaParaCheckout(DateTime fInicio, DateTime fFin) {
            List<String> errores = new List<String>();

            UIUtils.validarTextboxCompleto(codReservaTextbox, "Código de reserva", errores);

            if (errores.Count == 0) {

                if (fInicio == DateTime.MinValue) {
                    errores.Add("No existe reserva asociada al código seleccionado");
                } else if (fInicio > DateTime.Today || fFin < DateTime.Today) {
                    errores.Add("Solo es posible registrar checkouts de estadias de reservas actuales");
                }
                else {
                    int existeEstadia = DBUtils.queryRetornaInt("SELECT COUNT (*) FROM G_N.Estadias WHERE Estadia_Reserva_Codigo=" + codReservaTextbox.Text);
                    if (existeEstadia != 0) {
                        DateTime chechout = DBUtils.queryRetornaDate("SELECT Estadia_Fecha_Fin FROM G_N.Estadias WHERE Estadia_Reserva_Codigo=" + codReservaTextbox.Text);
                        if (chechout != DateTime.MinValue) {
                            errores.Add("Ya registró el checkout de la estadia seleccionada");
                        }
                    }
                    else {
                        errores.Add("Debe registrar el checkin antes del checkout.");
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

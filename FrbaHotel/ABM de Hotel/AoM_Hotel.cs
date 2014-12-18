using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Utils;

namespace FrbaHotel.ABM_de_Hotel {
    public partial class AoM_Hotel : Form {

        private String userId;
        private String hotelModificandoId;

        public AoM_Hotel(String userId, String hotelModificandoId) {
            this.userId = userId;
            this.hotelModificandoId = hotelModificandoId;
            
            InitializeComponent();

            String regimenesQuery = "SELECT Regimen_Id AS regId, Regimen_Descripcion AS regDesc FROM G_N.Regimenes";
            DBUtils.llenarComboBox(regimenesLisbox, regimenesQuery, "regId", "regDesc");

            UIUtils.llenarComboConNumeros(1, 5, estrellasCombo);

            fCreacionDTP.Enabled = false;
            botonLimpiar.Enabled = !esModificacion();

            if (this.esModificacion()) {
                this.Text = "Modificación de Hotel";

                // Lleno los campos con los del hotel que estoy modificando...
                DataRow hotelDataRow = DBUtils.levantarRegistroBD("Hoteles", campos(), "Hotel_Id", hotelModificandoId);
                
                nombreTextbox.Text = (String) hotelDataRow.ItemArray[0];
                emailTextbox.Text = (String) hotelDataRow.ItemArray[1];
                telTextbox.Text = DBUtils.levantarNullSafe(hotelDataRow.ItemArray[2]);
                paisTextbox.Text = (String) hotelDataRow.ItemArray[3];
                ciudadTextbox.Text = (String) hotelDataRow.ItemArray[4];
                calleTextbox.Text = (String) hotelDataRow.ItemArray[5];
                numeroTextbox.Text = ((Decimal) hotelDataRow.ItemArray[6]).ToString();
                estrellasCombo.SelectedValue = ((Decimal) hotelDataRow.ItemArray[7]).ToString();
                fCreacionDTP.Value = (DateTime) hotelDataRow.ItemArray[8];

                List<int> regs = DBUtils.queryRetornaInts("SELECT Regimen_Id FROM G_N.Hoteles_Regimenes WHERE Hotel_Id=" + hotelModificandoId);
                regimenesLisbox.ClearSelected();
                UIUtils.seleccionarItems(regimenesLisbox, regs);
            }
        }

        private List<String> campos() {
            List<String> campos = new List<String>();

            campos.Add("Hotel_Nombre"); // 0
            campos.Add("Hotel_Mail"); // 1
            campos.Add("Hotel_Telefono"); // 2
            campos.Add("Hotel_Pais"); // 3
            campos.Add("Hotel_Ciudad"); // 4
            campos.Add("Hotel_Dom_Calle"); // 5
            campos.Add("Hotel_Dom_Nro"); // 6
            campos.Add("Hotel_Estrellas"); // 7
            campos.Add("Hotel_Fecha_Creacion"); // 8

            return campos;
        }

        private List<String> valores() {
            List<String> valores = new List<String>();

            valores.Add(DBUtils.stringify(nombreTextbox.Text));
            valores.Add(DBUtils.stringify(emailTextbox.Text));
            valores.Add(DBUtils.stringify(telTextbox.Text));
            valores.Add(DBUtils.stringify(paisTextbox.Text));
            valores.Add(DBUtils.stringify(ciudadTextbox.Text));
            valores.Add(DBUtils.stringify(calleTextbox.Text));
            valores.Add(numeroTextbox.Text);
            valores.Add(UIUtils.valorSeleccionado(estrellasCombo));
            valores.Add(DBUtils.stringify(ConversionUtils.dateTimeAStr(fCreacionDTP.Value)));

            return valores;
        }

        private Boolean esModificacion() {
            return hotelModificandoId != null && hotelModificandoId != "";
        }

        private void botonLimpiar_Click(object sender, EventArgs e) {
            nombreTextbox.Text = "";
            emailTextbox.Text = "";
            telTextbox.Text = "";
            paisTextbox.Text = "";
            ciudadTextbox.Text = "";
            calleTextbox.Text = "";
            numeroTextbox.Text = "";
            estrellasCombo.SelectedValue = "";
            regimenesLisbox.ClearSelected();
        }

        private void botonGuardar_Click(object sender, EventArgs e) {
            List<String> errores = validarForm();
            UIUtils.mostrarErrores(errores);

            if (errores.Count == 0) {
                String idAsignado = hotelModificandoId;

                if (esModificacion()) {
                    DBUtils.actualizar("Hoteles", campos(), valores(), "Hotel_Id", idAsignado);
                } else {
                    idAsignado = DBUtils.insertarIdentity("Hoteles", campos(), valores());
                    
                    // Le asigno el hotel al usuario actual
                    DBUtils.ejecutarQuery("INSERT INTO G_N.Usuarios_Hoteles VALUES (" + userId + ", " + idAsignado + ")");
                }

                DBUtils.insertarNxNs("Hoteles_Regimenes", "Hotel_Id", idAsignado, "regId", UIUtils.valoresSeleccionados(regimenesLisbox));

                if (esModificacion()) {
                    MessageBox.Show("Hotel modificado exitosamente...");
                }
                else {
                    MessageBox.Show("Hotel generado exitosamente...");
                }

                this.Close();
            }
        }

        private List<String> validarForm() {
            List<String> errores = new List<String>();

            UIUtils.validarTextboxCompleto(nombreTextbox, "Nombre", errores);
            UIUtils.validarTextboxCompleto(emailTextbox, "E-mail", errores);
            UIUtils.validarTextboxCompleto(calleTextbox, "Calle", errores);
            UIUtils.validarTextboxCompleto(numeroTextbox, "Número", errores);
            UIUtils.validarTextboxCompleto(paisTextbox, "País", errores);
            UIUtils.validarTextboxCompleto(ciudadTextbox, "Ciudad", errores);

            UIUtils.validarComboCompleto(estrellasCombo, "Estrellas", errores);
            UIUtils.validarComboCompleto(regimenesLisbox, "Regímenes", errores);

            if (esModificacion()) {
                // Valido que no se quiten regimenes con reservas futuras o actuales
                List<int> regsNecesarios = DBUtils.queryRetornaInts("SELECT * FROM G_N.Regimenes_Necesarios_Hotel(" + hotelModificandoId + ")");

                foreach (int reg in regsNecesarios) {
                    if (!UIUtils.valoresSeleccionados(regimenesLisbox).Contains(reg.ToString())) {
                        errores.Add("No se puede quitar el regimen " + UIUtils.textoDeUnValorDeListbox(regimenesLisbox, reg.ToString()) + " ya que existen reservas asociadas al mismo");
                    }
                }
            }
               

            return errores;
        }

        public void soloNums_KeyPressed(object sender, KeyPressEventArgs e) {
            UIUtils.soloNumeros(e);
        }
    }
}

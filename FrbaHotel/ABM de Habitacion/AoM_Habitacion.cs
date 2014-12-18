using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Utils;

namespace FrbaHotel.ABM_de_Habitacion {

    public partial class AoM_Habitacion : Form {

        String hotelId;
        String habModificandoId;

        public AoM_Habitacion(String hotelId, String habModificandoId) {

            this.hotelId = hotelId;
            this.habModificandoId = habModificandoId;
            InitializeComponent();

            String tipoQuery = "SELECT Habitacion_Tipo_Codigo AS hCod, Habitacion_Tipo_Descripcion AS hDesc FROM G_N.Habitacion_Tipos";
            DBUtils.llenarComboBox(tipoCombo, tipoQuery, "hCod", "hDesc");
            tipoCombo.SelectedValue = "";
      
            activoCheckbox.Checked = true;
            botonLimpiar.Enabled = !esModificacion();

            if (this.esModificacion()) {
                tipoCombo.Enabled = false;
                this.Text = "Modificación de Habitación";

                // Lleno los campos con los de la habitación que estoy modificando...
                DataRow clienteDataRow = DBUtils.levantarRegistroBD("Habitaciones", campos(), "Habitacion_Id", habModificandoId);

                numeroTextbox.Text = ((Decimal) clienteDataRow.ItemArray[0]).ToString();
                pisoTextbox.Text = ((Decimal) clienteDataRow.ItemArray[1]).ToString();

                tipoCombo.SelectedValue = ((int) clienteDataRow.ItemArray[3]).ToString();
                descTextbox.Text = (String) clienteDataRow.ItemArray[4];

                frontalCheckbox.Checked = ConversionUtils.charABool((String)clienteDataRow.ItemArray[2]);
                activoCheckbox.Checked = ConversionUtils.estadoABool((String) clienteDataRow.ItemArray[5]);
                
            }
        }

        private Boolean esModificacion() {
            return habModificandoId != null && habModificandoId != "";
        }

        private List<String> campos() {
            List<String> campos = new List<String>();

            campos.Add("Habitacion_Numero"); // 0
            campos.Add("Habitacion_Piso"); // 1
            campos.Add("Habitacion_Es_Frente"); // 2
            campos.Add("Habitacion_Tipo_Codigo"); // 3
            campos.Add("Habitacion_Descripcion"); // 4
            campos.Add("Estado"); // 5
            campos.Add("Habitacion_Hotel_Id");

            return campos;
        }

        private List<String> valores() {
            List<String> valores = new List<String>();

            valores.Add(numeroTextbox.Text);
            valores.Add(pisoTextbox.Text);
            valores.Add(ConversionUtils.boolAChar(frontalCheckbox.Checked));
            valores.Add(UIUtils.valorSeleccionado(tipoCombo));
            valores.Add(DBUtils.stringify(descTextbox.Text));

            valores.Add(ConversionUtils.boolAEstado(activoCheckbox.Checked));

            valores.Add(this.hotelId);

            return valores;
        }

        private void botonLimpiar_Click(object sender, EventArgs e) {
            numeroTextbox.Text = "";
            pisoTextbox.Text = "";
            frontalCheckbox.Checked = false;
            tipoCombo.SelectedValue = "";
            descTextbox.Text = "";
            activoCheckbox.Checked = true;
        }


        public void soloNums_KeyPressed(object sender, KeyPressEventArgs e) {
            UIUtils.soloNumeros(e);
        }

        private void botonGuardar_Click(object sender, EventArgs e) {
            List<String> errores = validarForm();
            UIUtils.mostrarErrores(errores);

            if (errores.Count == 0) {
                String idAsignado = habModificandoId;

                if (esModificacion()) {
                    DBUtils.actualizar("Habitaciones", campos(), valores(), "Habitacion_Id", idAsignado);
                } else {
                    idAsignado = DBUtils.insertarIdentity("Habitaciones", campos(), valores());
                }

                if (esModificacion()) {
                    MessageBox.Show("Habitación modificada exitosamente...");
                }
                else {
                    MessageBox.Show("Habitación generada exitosamente...");
                }

                this.Close();
            }
        }

        private List<String> validarForm() {
            List<String> errores = new List<String>();

            UIUtils.validarTextboxCompleto(numeroTextbox, "Numero", errores);
            UIUtils.validarTextboxCompleto(pisoTextbox, "Piso", errores);
            UIUtils.validarComboCompleto(tipoCombo, "Tipo", errores);
            UIUtils.validarUnicidadExtraCond(numeroTextbox, "Habitaciones", "Habitacion_Numero", "Habitacion_Id", habModificandoId, " AND Habitacion_Hotel_Id=" + this.hotelId, errores);

            return errores;
        }
    }
}

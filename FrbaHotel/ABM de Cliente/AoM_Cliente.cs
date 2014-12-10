using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Utils;

namespace FrbaHotel.ABM_de_Cliente {
    public partial class AoM_Cliente : Form {

        private String clienteModificandoId;

        public AoM_Cliente(String cliModificandoId) {
            this.clienteModificandoId = cliModificandoId;
            
            InitializeComponent();
        }

        private void AoM_Cliente_Load(object sender, EventArgs e) {
            String tDocQuery = "SELECT Documento_Tipo_Id AS tDocId, Documento_Tipo_Descripcion AS tDocDesc FROM G_N.Documento_Tipos";

            DBUtils.llenarComboBox(tDocCombo, tDocQuery, "tDocId", "tDocDesc");

            activoCheckbox.Checked = true;
            botonLimpiar.Enabled = !esModificacion();

            if (this.esModificacion()) {
                this.Text = "Modificación de Cliente";

                // Lleno los campos con los del cliente que estoy modificando...
                DataRow clienteDataRow = DBUtils.levantarRegistroBD("Clientes", campos(), "Cliente_Id", clienteModificandoId);

                tDocCombo.SelectedValue = ((int) clienteDataRow.ItemArray[0]).ToString();
                nDocTextbox.Text = ((Decimal) clienteDataRow.ItemArray[1]).ToString();
                apellidoTextbox.Text = (String) clienteDataRow.ItemArray[2];
                nombreTextbox.Text = (String) clienteDataRow.ItemArray[3];
                fNacDTP.Value = (DateTime) clienteDataRow.ItemArray[4];
                emailTextbox.Text = (String) clienteDataRow.ItemArray[5];
                telTextbox.Text = DBUtils.levantarNullSafe(clienteDataRow.ItemArray[6]);

                paisTextbox.Text = DBUtils.levantarNullSafe(clienteDataRow.ItemArray[7]);
                localidadTextbox.Text = DBUtils.levantarNullSafe(clienteDataRow.ItemArray[8]);
                calleTextbox.Text = DBUtils.levantarNullSafe(clienteDataRow.ItemArray[9]);
                numeroTextbox.Text = ((Decimal) clienteDataRow.ItemArray[10]).ToString();
                pisoTextbox.Text = ((Decimal) clienteDataRow.ItemArray[11]).ToString();
                deptoTextbox.Text = DBUtils.levantarNullSafe(clienteDataRow.ItemArray[12]);
                nacionalidadTextbox.Text = DBUtils.levantarNullSafe(clienteDataRow.ItemArray[13]);

                Boolean mailRepe = (String) clienteDataRow.ItemArray[14] == "T";
                Boolean docuRepe = (String) clienteDataRow.ItemArray[15] == "T";

                activoCheckbox.Checked = ConversionUtils.estadoABool((String) clienteDataRow.ItemArray[16]);

                if (mailRepe) {
                    MessageBox.Show("El mail de éste cliente se encuentra duplicado en el sistema");
                }

                if (docuRepe) {
                    MessageBox.Show("El tipo y número de documento de éste cliente se encuentra duplicado en el sistema");
                }
            }
        }

        private Boolean esModificacion() {
            return clienteModificandoId != null && clienteModificandoId != "";
        }

        private void botonLimpiar_Click(object sender, EventArgs e) {
            nombreTextbox.Text = "";
            apellidoTextbox.Text = "";
            tDocCombo.SelectedValue = "";
            nDocTextbox.Text = "";
            emailTextbox.Text = "";
            telTextbox.Text = "";
            nacionalidadTextbox.Text = "";
            calleTextbox.Text = "";
            numeroTextbox.Text = "";
            paisTextbox.Text = "";
            pisoTextbox.Text = "";
            deptoTextbox.Text = "";
            localidadTextbox.Text = "";
            fNacDTP.Value = DateTime.Now;
            activoCheckbox.Checked = true;
        }

        private void botonGuardar_Click(object sender, EventArgs e) {
            List<String> errores = validarForm();
            UIUtils.mostrarErrores(errores);

            if (errores.Count == 0) {
                String idAsignado = clienteModificandoId;

                if (esModificacion()) {
                    DBUtils.actualizar("Clientes", campos(), valores(), "Cliente_Id", idAsignado);
                } else {
                    DBUtils.insertar("Clientes", campos(), valores());
                    idAsignado = DBUtils.queryRetornaInts("SELECT Cliente_Id FROM G_N.Clientes WHERE Cliente_Mail=" + DBUtils.stringify(emailTextbox.Text) +
                                                                                              " AND Cliente_Documento_Nro=" + nDocTextbox.Text).First().ToString();
                }

                if (esModificacion()) {
                    MessageBox.Show("Cliente modificado exitosamente...");
                }
                else {
                    MessageBox.Show("Cliente generado exitosamente...");
                }

                this.Close();
            }
        }

        private List<String> validarForm() {
            List<String> errores = new List<String>();

            UIUtils.validarTextboxCompleto(nombreTextbox, "Nombre", errores);
            UIUtils.validarTextboxCompleto(apellidoTextbox, "Apellido", errores);
            UIUtils.validarTextboxCompleto(nDocTextbox, "Número de documento", errores);
            UIUtils.validarTextboxCompleto(emailTextbox, "Email", errores);
            UIUtils.validarTextboxCompleto(telTextbox, "Teléfono", errores);
            UIUtils.validarTextboxCompleto(nacionalidadTextbox, "Nacionalidad", errores);

            UIUtils.validarTextboxCompleto(calleTextbox, "Calle", errores);
            UIUtils.validarTextboxCompleto(numeroTextbox, "Número de Calle", errores);
            UIUtils.validarTextboxCompleto(paisTextbox, "País", errores);
            UIUtils.validarTextboxCompleto(pisoTextbox, "Piso", errores);
            UIUtils.validarTextboxCompleto(deptoTextbox, "Departamento", errores);
            UIUtils.validarTextboxCompleto(localidadTextbox, "Localidad", errores);
           
            UIUtils.validarUnicidad(emailTextbox, "Clientes", "Cliente_Mail", "Cliente_Id", clienteModificandoId, errores);
            UIUtils.validarUnicidadTipoYNumDoc(tDocCombo, nDocTextbox, "Clientes", "Cliente_Documento_Tipo_Id", "Cliente_Documento_Nro", "Cliente_Id", clienteModificandoId, errores);         

            UIUtils.validarFechaAnteriorAHoy(fNacDTP, "nacimiento", errores);

            UIUtils.validarComboCompleto(tDocCombo, "Tipo de documento", errores);
 

            return errores;
        }

        private List<String> campos() {
            List<String> campos = new List<String>();

            campos.Add("Cliente_Documento_Tipo_Id"); // 0
            campos.Add("Cliente_Documento_Nro"); // 1
            campos.Add("Cliente_Apellido"); // 2
            campos.Add("Cliente_Nombre"); // 3
            campos.Add("Cliente_Fecha_Nac"); // 4
            campos.Add("Cliente_Mail"); // 5
            campos.Add("Cliente_Telefono"); // 6
            campos.Add("Cliente_Dom_Pais"); // 7
            campos.Add("Cliente_Dom_Localidad"); // 8
            campos.Add("Cliente_Dom_Calle"); // 9
            campos.Add("Cliente_Dom_Nro_Calle"); // 10
            campos.Add("Cliente_Piso"); // 11
            campos.Add("Cliente_Depto"); // 12
            campos.Add("Cliente_Nacionalidad"); // 13
            campos.Add("Cliente_Mail_Repetido"); // 14
            campos.Add("Cliente_Documento_Repetido"); // 15
            campos.Add("Estado"); // 16

            return campos;
        } 

        private List<String> valores() {
            List<String> valores = new List<String>();

            valores.Add(UIUtils.valorSeleccionado(tDocCombo));
            valores.Add(nDocTextbox.Text);

            valores.Add(DBUtils.stringify(apellidoTextbox.Text));
            valores.Add(DBUtils.stringify(apellidoTextbox.Text));

            valores.Add(DBUtils.stringify(ConversionUtils.dateTimeAStr(fNacDTP.Value)));

            valores.Add(DBUtils.stringify(emailTextbox.Text));
            valores.Add(DBUtils.stringify(telTextbox.Text));

            valores.Add(DBUtils.stringify(paisTextbox.Text));
            valores.Add(DBUtils.stringify(localidadTextbox.Text)); 
            valores.Add(DBUtils.stringify(calleTextbox.Text));
            valores.Add(DBUtils.stringify(numeroTextbox.Text));
            valores.Add(DBUtils.stringify(pisoTextbox.Text));
            valores.Add(DBUtils.stringify(deptoTextbox.Text));
            valores.Add(DBUtils.stringify(nacionalidadTextbox.Text));

            valores.Add(DBUtils.stringify("F"));
            valores.Add(DBUtils.stringify("F"));
            
            valores.Add(ConversionUtils.boolAEstado(activoCheckbox.Checked));

            return valores;
        }

        public void soloNums_KeyPressed(object sender, KeyPressEventArgs e) {
            UIUtils.soloNumeros(e);
        }
    }
}

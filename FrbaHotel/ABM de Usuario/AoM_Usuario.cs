using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Utils;

namespace FrbaHotel.ABM_de_Usuario {
    public partial class AoM_Usuario : Form {

        private String usuarioModificandoId;
        private String pswActual;
        
        public AoM_Usuario(String usuarioModificandoId) {
            this.usuarioModificandoId = usuarioModificandoId;
            InitializeComponent();
        }

        private Boolean esModificacion() {
            return usuarioModificandoId != null && usuarioModificandoId != "";
        }

        private void AoM_Usuario_Load(object sender, EventArgs e) {
            String rolQuery = "SELECT r.Rol_Id AS rolId, Rol_Nombre AS rolName FROM G_N.Roles r " +
                                    DBUtils.soloActivos();

            String hotelQuery = "SELECT h.Hotel_Id AS hotelId, h.Hotel_Dom_Calle + ' ' + CAST(h.Hotel_Dom_Nro AS NVARCHAR) AS hotelDom FROM G_N.Hoteles h " +
                                    DBUtils.soloActivos();

            String tDocQuery = "SELECT Documento_Tipo_Id AS tDocId, Documento_Tipo_Descripcion AS tDocDesc FROM G_N.Documento_Tipos";

            DBUtils.llenarComboBox(rolesListBox, rolQuery, "rolId", "rolName");
            DBUtils.llenarComboBox(hotelesListBox, hotelQuery, "hotelId", "hotelDom");
            DBUtils.llenarComboBox(tDocCombo, tDocQuery, "tDocId", "tDocDesc");

            activoCheckbox.Checked = true;
            botonLimpiar.Enabled = !esModificacion();
            rolesListBox.ClearSelected();
            hotelesListBox.ClearSelected();

            if (this.esModificacion()) {
                this.Text = "Modificación de Usuario";
                // Lleno los campos con los del usuario que estoy modificando...

                DataRow userDataRow = DBUtils.levantarRegistroBD("Usuarios", campos(), "Usuario_Id", usuarioModificandoId);

                this.pswActual = (String)userDataRow.ItemArray[1];

                uNameTextbox.Text = (String) userDataRow.ItemArray[0];
                pswTextbox.Text = this.pswActual;
                rPswTextbox.Text = this.pswActual;
                nombreCompletoTextbox.Text = (String) userDataRow.ItemArray[2];
                tDocCombo.SelectedValue = ((int) userDataRow.ItemArray[3]).ToString();
                nDocTextbox.Text = ((Decimal) userDataRow.ItemArray[4]).ToString();
                emailTextbox.Text = (String) userDataRow.ItemArray[5];
                telTextbox.Text = DBUtils.levantarNullSafe(userDataRow.ItemArray[6]);
                domicilioTextBox.Text = (String) userDataRow.ItemArray[7];
                fNacDTP.Value = (DateTime) userDataRow.ItemArray[8];
                activoCheckbox.Checked = ConversionUtils.estadoABool((String)userDataRow.ItemArray[9]);

                List<int> roles = DBUtils.queryRetornaInts("SELECT Rol_Id FROM G_N.Usuarios_Roles WHERE Usuario_Id=" + usuarioModificandoId);
                rolesListBox.ClearSelected();
                UIUtils.seleccionarItems(rolesListBox, roles);

                List<int> hoteles = DBUtils.queryRetornaInts("SELECT Hotel_Id FROM G_N.Usuarios_Hoteles WHERE Usuario_Id=" + usuarioModificandoId);
                hotelesListBox.ClearSelected();
                UIUtils.seleccionarItems(hotelesListBox, hoteles);
            }
        }

        private void botonGuardar_Click(object sender, EventArgs e) {
            List<String> errores = validarForm();
            UIUtils.mostrarErrores(errores);

            if (errores.Count == 0) {
                String idAsignado = usuarioModificandoId;

                if (esModificacion()) {
                    DBUtils.actualizar("Usuarios", campos(), valores(), "Usuario_Id", idAsignado);
                } else {
                    DBUtils.insertar("Usuarios", campos(), valores());
                    idAsignado = DBUtils.queryRetornaInts("SELECT Usuario_Id FROM G_N.Usuarios WHERE Usuario_UserName=" + DBUtils.stringify(uNameTextbox.Text)).First().ToString();
                }
                DBUtils.insertarNxNs("Usuarios_Roles", "Usuario_Id", idAsignado, "rolId", UIUtils.valoresSeleccionados(rolesListBox));
                DBUtils.insertarNxNs("Usuarios_Hoteles", "Usuario_Id", idAsignado, "hotelId", UIUtils.valoresSeleccionados(hotelesListBox));

                if (esModificacion()) {
                    MessageBox.Show("Usuario modificado exitosamente...");
                }
                else {
                    MessageBox.Show("Usuario generado exitosamente...");
                }
                
                this.Close();
            }
        }

        private List<String> validarForm() {
            List<String> errores = new List<String>();

            UIUtils.validarTextboxCompleto(uNameTextbox, "Nombre de usuario", errores);
            UIUtils.validarTextboxCompleto(nombreCompletoTextbox, "Nombre Completo", errores);
            UIUtils.validarTextboxCompleto(pswTextbox, "Contraseña", errores);
            UIUtils.validarTextboxCompleto(emailTextbox, "Email", errores);
            UIUtils.validarTextboxCompleto(domicilioTextBox, "Domicilio", errores);
            UIUtils.validarTextboxCompleto(telTextbox, "Teléfono", errores);
            UIUtils.validarTextboxCompleto(nDocTextbox, "Número de Documento", errores);

            UIUtils.validarUnicidad(uNameTextbox, "Usuarios", "Usuario_userName", "Usuario_Id", usuarioModificandoId, errores);            

            UIUtils.validarFechaAnteriorAHoy(fNacDTP, "nacimiento", errores);

            UIUtils.validarComboCompleto(rolesListBox, "Roles", errores);
            UIUtils.validarComboCompleto(hotelesListBox, "Hoteles", errores);

            UIUtils.validarContraseniasCoinciden(pswTextbox, rPswTextbox, errores);

            return errores;
        }

        private List<String> campos() {
            List<String> campos = new List<String>();

            campos.Add("Usuario_UserName");
            campos.Add("Usuario_Password");
            campos.Add("Usuario_Nombre_Completo");
            campos.Add("Usuario_Documento_Tipo_Id");
            campos.Add("Usuario_Documento_Nro");
            campos.Add("Usuario_Mail");
            campos.Add("Usuario_Telefono");
            campos.Add("Usuario_Direccion");
            campos.Add("Usuario_Fecha_Nac");
            campos.Add("Estado");

            return campos;
        }

        private List<String> valores() {
            List<String> valores = new List<String>();
            String pswText = pswTextbox.Text;

            valores.Add(DBUtils.stringify(uNameTextbox.Text));
            if (esModificacion() && pswText == pswActual) {
                valores.Add(DBUtils.stringify(pswText));
            } else {
                valores.Add(DBUtils.stringify(StringUtils.getHashSha256(pswText)));
            }
            valores.Add(DBUtils.stringify(nombreCompletoTextbox.Text));
            valores.Add(UIUtils.valorSeleccionado(tDocCombo));
            valores.Add(nDocTextbox.Text);
            valores.Add(DBUtils.stringify(emailTextbox.Text));
            valores.Add(DBUtils.stringify(telTextbox.Text));
            valores.Add(DBUtils.stringify(domicilioTextBox.Text));
            valores.Add(DBUtils.stringify(ConversionUtils.dateTimeAStr(fNacDTP.Value)));
            valores.Add(ConversionUtils.boolAEstado(activoCheckbox.Checked));

            return valores;
        }

        private void nDocTextbox_KeyPressed(object sender, KeyPressEventArgs e) {
            UIUtils.soloNumeros(e);
        }

        private void botonLimpiar_Click(object sender, EventArgs e) {
            uNameTextbox.Text = "";
            pswTextbox.Text = "";
            rPswTextbox.Text = "";
            tDocCombo.SelectedValue = "";
            nDocTextbox.Text = "";
            fNacDTP.Value = DateTime.Now;
            nombreCompletoTextbox.Text = "";
            emailTextbox.Text = "";
            domicilioTextBox.Text = "";
            telTextbox.Text = "";
            activoCheckbox.Checked = true;
            rolesListBox.ClearSelected();
            hotelesListBox.ClearSelected();
        }
    }
}

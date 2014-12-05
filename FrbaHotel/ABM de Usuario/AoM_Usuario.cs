using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Utils;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class AoM_Usuario : Form {
        public AoM_Usuario() {
            InitializeComponent();
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
        }

        private void botonGuardar_Click(object sender, EventArgs e) {
            List<String> errores = validarForm();
            UIUtils.mostrarErrores(errores);

            if (errores.Count == 0) {
                DBUtils.insertar("Usuarios", campos(), valores());
                String idAsignado = DBUtils.queryRetornaIds("SELECT Usuario_Id FROM G_N.Usuarios WHERE Usuario_UserName=" + DBUtils.stringify(uNameTextbox.Text)).First().ToString();
                
                DBUtils.insertarFKs("Usuarios_Roles", "Usuario_Id", idAsignado, "rolId", UIUtils.valoresSeleccionados(rolesListBox));

                MessageBox.Show("Usuario generado exitosamente...");
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

            UIUtils.validarUnicidad(uNameTextbox, "Usuarios", "Usuario_userName", errores);

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

            valores.Add(DBUtils.stringify(uNameTextbox.Text));
            valores.Add(DBUtils.stringify(StringUtils.getHashSha256(pswTextbox.Text)));
            valores.Add(DBUtils.stringify(nombreCompletoTextbox.Text));
            valores.Add(tDocCombo.SelectedValue.ToString());
            valores.Add(nDocTextbox.Text);
            valores.Add(DBUtils.stringify(emailTextbox.Text));
            valores.Add(DBUtils.stringify(telTextbox.Text));
            valores.Add(DBUtils.stringify(domicilioTextBox.Text));
            valores.Add(DBUtils.stringify(fNacDTP.Value.ToString("yyyy-MM-dd")));
            valores.Add(DBUtils.boolAEstado(activoCheckbox.Checked));

            return valores;
        }
    }
}

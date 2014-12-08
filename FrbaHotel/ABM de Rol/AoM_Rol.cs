using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Utils;

namespace FrbaHotel.ABM_de_Rol {

    public partial class AoM_Rol : Form {

        private String rolModificandoId;

        public AoM_Rol(String rModificandoId) {
            this.rolModificandoId = rModificandoId;
            InitializeComponent();

            String funcionalidadesQuery = "SELECT Funcionalidad_Id AS funcId, Funcionalidad_Nombre AS funcName FROM G_N.Funcionalidades";
            DBUtils.llenarComboBox(funcsListbox, funcionalidadesQuery, "funcId", "funcName");
        
            activoCheckbox.Checked = true;
            botonLimpiar.Enabled = !esModificacion();
            funcsListbox.ClearSelected();

            if (this.esModificacion()) {
                this.Text = "Modificación de Rol";
                // Lleno los campos con los ceñl usuario que estoy modificando...

                DataRow rolDataRow = DBUtils.levantarRegistroBD("Roles", campos(), "Rol_Id", rolModificandoId);

                nombreRolTextbox.Text = (String) rolDataRow.ItemArray[0];
                activoCheckbox.Checked = ConversionUtils.estadoABool((String) rolDataRow.ItemArray[1]);

                List<int> funcs = DBUtils.queryRetornaIds("SELECT Funcionalidad_Id FROM G_N.Roles_Funcionalidades WHERE Rol_Id=" + rolModificandoId);
                funcsListbox.ClearSelected();
                UIUtils.seleccionarItems(funcsListbox, funcs);
            }

        }

        private Boolean esModificacion() {
            return rolModificandoId != null;
        }

        private void botonGuardar_Click(object sender, EventArgs e) {
            List<String> errores = validarForm();
            UIUtils.mostrarErrores(errores);

            if (errores.Count == 0) {
                String idAsignado = rolModificandoId;

                if (esModificacion()) {
                    DBUtils.actualizar("Roles", campos(), valores(), "Rol_Id", idAsignado);
                }
                else {
                    DBUtils.insertar("Roles", campos(), valores());
                    idAsignado = DBUtils.queryRetornaIds("SELECT Rol_Id FROM G_N.Roles WHERE Rol_Nombre=" + DBUtils.stringify(nombreRolTextbox.Text)).First().ToString();
                }
                
                DBUtils.insertarNxNs("Roles_Funcionalidades", "Rol_Id", idAsignado, "funcId", UIUtils.valoresSeleccionados(funcsListbox));

                if (esModificacion()) {
                    MessageBox.Show("Rol modificado exitosamente...");
                }
                else {
                    MessageBox.Show("Rol generado exitosamente...");
                }

                this.Close();
            }
        }

        private List<String> validarForm() {
            List<String> errores = new List<String>();

            UIUtils.validarTextboxCompleto(nombreRolTextbox, "Nombre de rol", errores);
            if (!esModificacion()){
                UIUtils.validarUnicidad(nombreRolTextbox, "Roles", "Rol_Nombre", errores);
            }

            UIUtils.validarComboCompleto(funcsListbox, "Funcionalidades", errores);

            return errores;
        }

        private List<String> campos() {
            List<String> cs = new List<String>();
            cs.Add("Rol_Nombre");
            cs.Add("Estado");

            return cs;
        }

        private List<String> valores() {
            List<String> vs = new List<String>();
            vs.Add(DBUtils.stringify(nombreRolTextbox.Text));
            vs.Add(ConversionUtils.boolAEstado(activoCheckbox.Checked));

            return vs;
        }

        private void botonLimpiar_Click(object sender, EventArgs e) {
            nombreRolTextbox.Text = "";
            funcsListbox.ClearSelected();
            activoCheckbox.Checked = true;
        }
    }
}

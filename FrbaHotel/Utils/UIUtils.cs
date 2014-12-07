using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace FrbaHotel.Utils {
    
    static class UIUtils {
        
        public static void mostrarErrores(List<String> errores) {
            if (errores.Count > 0) {
                String errs = String.Join("\n * ", errores.ToArray());
                MessageBox.Show("Corrija los siguientes errores antes de continuar: \n \n * " + errs, "Errores de validación...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static List<String> validarTextboxCompleto(TextBox tb, String nombreDelCampo, List<String> errores) {
            if (tb.Text.Length == 0) {
                errores.Add("Complete el campo " + nombreDelCampo + ".");
            }
            return errores;
        }

        public static List<String> validarComboCompleto(ListControl cb, String nombreDelCampo, List<String> errores) {
            if (cb.SelectedValue == null || cb.SelectedValue.ToString().Length == 0) {
                errores.Add("Complete el combo " + nombreDelCampo + ".");
            }
            return errores;
        }

        public static List<String> validarContraseniasCoinciden(TextBox p1, TextBox p2, List<String> errores) {
            if (p1.Text != p2.Text) {
                errores.Add("Las contraseñas no coinciden");
            }
            return errores;
        }

        public static List<String> validarUnicidad(TextBox tb, String tabla, String campo, List<String> errores) {
            String value = tb.Text;
            if (tb.Text == "") return errores;

            String query = "SELECT " + campo + " FROM G_N." + tabla + " WHERE " + campo + "='" + value + "'";

            List<String> valoresExistentes = DBUtils.queryRetornaStrings(query);

            if (valoresExistentes.Count > 0) {
                errores.Add("El valor " + value + " ya existe en el sistema");
            }
            return errores;
        }

        public static List<String> valoresSeleccionados(ListBox lb) {
            List<String> valores = new List<String>();
            foreach (DataRowView item in lb.SelectedItems) {
                valores.Add(item[lb.ValueMember].ToString());
            }
            return valores;
        }

        public static void seleccionarItems(ListBox lb, List<int> valoresASeleccionar) {
            List<DataRowView> seleccionados = new List<DataRowView>();
            foreach (DataRowView item in lb.Items) {
                String valor = item[lb.ValueMember].ToString();
                if (valoresASeleccionar.Contains(Convert.ToInt32(valor))) {
                    seleccionados.Add(item);
                }
            }
            foreach (DataRowView item in seleccionados) {
                lb.SelectedItems.Add(item);
            }
        }
   
    }
}

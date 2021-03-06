﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace FrbaHotel.Utils {
    
    static class UIUtils {

        //Para que el textBox solo permita el tipeo de numeros
        public static void soloNumeros(KeyPressEventArgs e) {
            if (char.IsLetter(e.KeyChar) || //Letras
                char.IsSymbol(e.KeyChar) || //Símbolos
                char.IsWhiteSpace(e.KeyChar) || //Espacios
                char.IsPunctuation(e.KeyChar)) //Puntuacion
                e.Handled = true; //No permitir
        }

        //Para que el textBox solo permita el tipeo de letras
        public static void soloLetras(KeyPressEventArgs e) {
            if (char.IsNumber(e.KeyChar) || //Numeros
                char.IsSymbol(e.KeyChar) || //Símbolos
                char.IsPunctuation(e.KeyChar)) //Puntuacion
                e.Handled = true; //No permitir
        }
        
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

        public static List<String> validarFechaAnteriorAHoy(DateTimePicker dtp, String fechaDe, List<String> errores) {
            if (dtp.Value == null) {
                errores.Add("Complete el campo fecha de " + fechaDe + ".");
            } else if (dtp.Value >= DateTime.Today) {
                errores.Add("La fecha de " + fechaDe + " debe ser anterior al día de hoy.");
            }
            return errores;
        }

        public static List<String> validarFechaPosteriorAAyer(DateTimePicker dtp, String fechaDe, List<String> errores) {
            if (dtp.Value == null) {
                errores.Add("Complete el campo fecha de " + fechaDe + ".");
            }
            else if (dtp.Value < DateTime.Today) {
                errores.Add("La fecha de " + fechaDe + " debe ser posterior al día de hoy.");
            }
            return errores;
        }

        public static List<String> validarFechaAnteriorAOtra(DateTimePicker dtp1, DateTimePicker dtp2, String n1, String n2, List<String> errores) {
            if (dtp1.Value == null || dtp1.Value == null) {
                errores.Add("Complete ambos campos de fechas.");
            }
            else if (dtp1.Value >= dtp2.Value){
                errores.Add("La fecha " + n1 + " debe ser anterior a la fecha " + n2 + ".");
            }
            return errores;
        }

        public static List<String> validarUnicidadDeId(TextBox tb, String tabla, String campo, List<String> errores) {
            String value = tb.Text;
            if (tb.Text == "") return errores;

            String query = "SELECT " + campo + " FROM G_N." + tabla + " WHERE " + campo + "=" + value + "";
                                                                        

            List<String> valoresExistentes = DBUtils.queryRetornaStrings(query);

            if (valoresExistentes.Count > 0) {
                errores.Add("El valor " + value + " ya existe en el sistema");
            }

            return errores;
        }

        public static List<String> validarUnicidad(TextBox tb, String tabla, String campo, String campoId, String valorId, List<String> errores) {
            return validarUnicidadExtraCond(tb, tabla, campo, campoId, valorId, "", errores);
        }

        public static List<String> validarUnicidadExtraCond(TextBox tb, String tabla, String campo, String campoId, String valorId, String extraCond, List<String> errores) {
            String value = tb.Text;
            if (tb.Text == "") return errores;

            String vid = valorId;
            if (vid == "") vid = "''";
            String query = "SELECT " + campo + " FROM G_N." + tabla + " WHERE " + campo + "='" + value + "'" +
                                                                        " AND " + campoId + "<>" + vid + " " + extraCond;

            List<String> valoresExistentes = DBUtils.queryRetornaStrings(query);

            if (valoresExistentes.Count > 0) {
                errores.Add("El valor " + value + " ya existe en el sistema");
            }

            return errores;
        }

        public static List<String> validarUnicidadTipoYNumDoc(ComboBox tDoc, TextBox nDoc, String tabla, String campoTDoc, String campoNDoc, String campoId, String valorId, List<String> errores) {
            String num = nDoc.Text;
            String tipo = valorSeleccionado(tDoc);

            if (num == "" || tipo == "") return errores;
            
            String vid = valorId;
            if (vid == "") vid = "''";

            String query = "SELECT " + campoTDoc + " FROM G_N." + tabla + " WHERE " + campoTDoc + "=" + tipo +
                                                                            " AND " + campoNDoc + "=" + num +
                                                                            " AND " + campoId + "<>" + vid ;

            List<int> valoresExistentes = DBUtils.queryRetornaInts(query);

            if (valoresExistentes.Count > 0) {
                errores.Add("El documento " + num + " para el tipo seleccionado ya existe en otro usuario");
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

        public static String valorSeleccionado(ComboBox cb) {
            if (cb.SelectedValue == null) {
                return "";
            }
            else {
                return cb.SelectedValue.ToString();
            }
        }

        public static String textoDeUnValorDeListbox(ListBox lb, String valor) {
            foreach(DataRowView item in lb.Items) {
                if (item[lb.ValueMember].ToString() == valor) {
                    return item[lb.DisplayMember].ToString();
                }
            }

            return "";
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

        public static void llenarComboConNumeros(int desde, int hasta, ComboBox cb) {
            List<NumYDesc> valores = new List<NumYDesc>();
            for (int i = desde; i <= hasta; i++) {
                valores.Add(new NumYDesc() { num = i.ToString() });
            }   
             
            cb.DataSource = valores;
            cb.ValueMember = "num";
            cb.DisplayMember = "desc";
            cb.SelectedValue = "";
        }
   
    }
}

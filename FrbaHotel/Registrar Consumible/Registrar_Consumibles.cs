using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Utils;

namespace FrbaHotel.Registrar_Consumible {

    public partial class Registrar_Consumibles : Form {

        String codReserva;

        DataTable consDispDT;
        DataTable consEnEstadiaDT;

        String query = "SELECT Consumible_Codigo AS Id, Consumible_Descripcion AS Consumible FROM G_N.Consumibles";

        public Registrar_Consumibles(String codRes) {
            this.codReserva = codRes;
            InitializeComponent();

            consDispDT = DBUtils.llenarDataGridView(tablaConsDisp, query);
            consEnEstadiaDT = DBUtils.llenarDataGridView(tablaConsEnEstadia, query + " WHERE 1 = 2");
            consEnEstadiaDT.Columns.Add("Cantidad");

            configurarTablaDeConsumibles(tablaConsDisp);
            configurarTablaDeConsumibles(tablaConsEnEstadia);

            DBUtils.llenarComboBox(HabsCombo, "SELECT rh.Habitacion_Id AS Id, h.Habitacion_Numero AS Nro " +
                                                    "FROM G_N.Habitaciones h " +
                                                    "JOIN G_N.Reservas_Habitaciones rh ON h.Habitacion_Id = rh.Habitacion_Id " +
                                                      "WHERE rh.Reserva_Codigo = " + codRes, "Id", "Nro");
            
        }

        private void configurarTablaDeConsumibles(DataGridView dgv) {
            dgv.Columns["Id"].Visible = false;
        }

        private void botonAddCons_Click(object sender, EventArgs e) {
            if (tablaConsDisp.SelectedRows.Count == 1) {
                AgregarConsumible(consEnEstadiaDT, GridUtils.GetSelectedDataRows(tablaConsDisp));
            } else {
                MessageBox.Show("Por favor seleccione un consumible.");
            }
        }

        private void botonRemoveCons_Click(object sender, EventArgs e) {
            if (tablaConsEnEstadia.SelectedRows.Count == 1) {
                QuitarConsumible(consEnEstadiaDT, GridUtils.GetSelectedDataRows(tablaConsEnEstadia));
            } else {
                MessageBox.Show("Por favor seleccione un consumible.");
            }
        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e) {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        private void botonConfirmar_Click(object sender, EventArgs e) {
            List<String> errores = validar();
            UIUtils.mostrarErrores(errores);

            if (errores.Count == 0) {
                foreach (DataGridViewRow dr in tablaConsEnEstadia.Rows) {
                    if (dr.Cells["Id"].Value != null)
                        DBUtils.ejecutarQuery("INSERT INTO G_N.Estadias_Consumibles(Estadia_Reserva_Codigo, Consumible_Codigo, Consumible_Cantidad, Habitacion_Id)" +
                                                 " VALUES (" + codReserva + "," + dr.Cells["Id"].Value.ToString() + "," + dr.Cells["Cantidad"].Value.ToString() + "," + UIUtils.valorSeleccionado(HabsCombo) + ")");
                }

                MessageBox.Show("Consumibles agregados satisfactoriamente.");
                this.Close();
            }
        }

        private List<String> validar() {
            List<String> errores = new List<String>();

            UIUtils.validarComboCompleto(HabsCombo, "Habitacion", errores);

            return errores;
        }

        public static void AgregarConsumible(DataTable dt, DataRow[] rows) {

            foreach (DataRow drToAdd in rows) {
                int cant = 1;
                List<DataRow> drsToRemove = new List<DataRow>();
                foreach (DataRow dr in dt.Rows) {
                    // Mismo Id
                    if (drToAdd.ItemArray[0].ToString() == dr.ItemArray[0].ToString()) {
                        drsToRemove.Add(dr);
                        cant = Int32.Parse((String) dr.ItemArray[2]) + 1;
                    }

                }

                GridUtils.RemoveRows(dt, drsToRemove.ToArray());
                List<object> currCells = drToAdd.ItemArray.ToList();
                currCells.Add(cant.ToString());
                dt.Rows.Add(currCells.ToArray());
            }
        }

        public static void QuitarConsumible(DataTable dt, DataRow[] rows) {

            foreach (DataRow drToRemove in rows) {
                int cant = Int32.Parse((String) drToRemove.ItemArray[2]);

                object[] items = (object[]) drToRemove.ItemArray.Clone();
                dt.Rows.Remove(drToRemove);
                if (cant > 1) {
                    items[2] = (cant - 1).ToString();
                    dt.Rows.Add(items);
                } 

            } 
        }
    }
}

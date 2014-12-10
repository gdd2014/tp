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

    public partial class ABM_Habitaciones : Form {

        String hotelId;
        String query;

        public ABM_Habitaciones(String hotelId) {

            this.hotelId = hotelId;

            this.query = "SELECT TOP 50 Habitacion_Id AS Id, " +
                             " h.Habitacion_Numero AS Numero, " +
                             " h.Habitacion_Piso AS Piso, " +
                             " ht.Habitacion_Tipo_Descripcion AS Tipo, " +
                             " Estado " +
                         " FROM G_N.Habitaciones h" +
                         " JOIN G_N.Habitacion_Tipos ht ON h.Habitacion_Tipo_Codigo = ht.Habitacion_Tipo_Codigo " +
                         " WHERE h.Habitacion_Hotel_Id = " + hotelId;
                        
            InitializeComponent();

            DBUtils.llenarDataGridView(tablaDeHabitaciones, query);
            this.tablaDeHabitaciones.Columns["Id"].Visible = false;
            this.tablaDeHabitaciones.Columns["Numero"].Width = 50;
            this.tablaDeHabitaciones.Columns["Piso"].Width = 45;
            this.tablaDeHabitaciones.Columns["Tipo"].Width = 110;

            String tipoQuery = "SELECT Habitacion_Tipo_Codigo AS hCod, Habitacion_Tipo_Descripcion AS hDesc FROM G_N.Habitacion_Tipos";
            DBUtils.llenarComboBox(tipoCombo, tipoQuery, "hCod", "hDesc");
            tipoCombo.SelectedValue = "";
        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e) {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        private void botonLimpiar_Click(object sender, EventArgs e) {
            numeroTextbox.Text = "";
            pisoTextbox.Text = "";
            tipoCombo.SelectedValue = "";
        }

        private void botonBuscar_Click(object sender, EventArgs e) {
            DBUtils.llenarDataGridView(tablaDeHabitaciones, query +
                  " AND h.Habitacion_Numero LIKE '%" + numeroTextbox.Text + "%'" +
                  " AND h.Habitacion_Piso LIKE '%" + pisoTextbox.Text + "%'" +
                  " AND h.Habitacion_Tipo_Codigo LIKE '%" + UIUtils.valorSeleccionado(tipoCombo) + "%'");
        }

        private void botonCerrar_Click(object sender, EventArgs e) {
            if (tablaDeHabitaciones.SelectedRows.Count == 1) {
                DialogResult dr = MessageBox.Show("¿Está seguro que desea bajar la habitación seleccionada?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes) {
                    String hid = tablaDeHabitaciones.SelectedRows[0].Cells[0].Value.ToString();
                    DBUtils.borradoLogico("Habitaciones", "Habitacion_Id", hid);
                }
            }
            else {
                MessageBox.Show("Por favor seleccione una habitación");
            }
        }

        private void botonModificar_Click(object sender, EventArgs e) {
            if (tablaDeHabitaciones.SelectedRows.Count == 1) {           
                String hid = tablaDeHabitaciones.SelectedRows[0].Cells[0].Value.ToString();
                AoM_Habitacion mf = new AoM_Habitacion(hotelId, hid);
                mf.Show();
            }
            else {
                MessageBox.Show("Por favor seleccione una habitación");
            }
        }

        private void botonNuevoHotel_Click(object sender, EventArgs e) {
            AoM_Habitacion mf = new AoM_Habitacion(hotelId, "");
            mf.Show();
        }
    }
}

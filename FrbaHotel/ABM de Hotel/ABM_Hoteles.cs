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

    public partial class ABM_Hoteles : Form {

        String userId;

        String query = "SELECT TOP 50 Hotel_Id AS Id, " +
                             " Hotel_Nombre AS Nombre, " +
                             " Hotel_Estrellas AS Estrellas, " +
                             " Hotel_Pais AS Pais, " +
                             " Hotel_Ciudad AS Ciudad FROM G_N.Hoteles ";
        
        public ABM_Hoteles(String userId) {
            this.userId = userId;

            InitializeComponent();

            UIUtils.llenarComboConNumeros(1, 5, estrellasCombo);

            DBUtils.llenarDataGridView(tablaDeHoteles, query);

            this.tablaDeHoteles.Columns["Id"].Visible = false;
            this.tablaDeHoteles.Columns["Nombre"].Width = 250;
            this.tablaDeHoteles.Columns["Estrellas"].Width = 60;
            this.tablaDeHoteles.Columns["Pais"].Width = 100;
            this.tablaDeHoteles.Columns["Ciudad"].Width = 100;
        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e) {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        private void botonBuscar_Click(object sender, EventArgs e) {
            DBUtils.llenarDataGridView(tablaDeHoteles, query +
                " WHERE Hotel_Nombre LIKE '%" + nombreTextbox.Text + "%'" +
                  " AND Hotel_Estrellas LIKE '%" + UIUtils.valorSeleccionado(estrellasCombo) + "%'" +
                  " AND Hotel_Pais LIKE '%" + paisTextbox.Text + "%'" +
                  " AND Hotel_Ciudad LIKE '%" + ciudadTextbox.Text + "%'");
        }

        private void botonLimpiar_Click(object sender, EventArgs e) {
            nombreTextbox.Text = "";
            estrellasCombo.SelectedValue = "";
            paisTextbox.Text = "";
            ciudadTextbox.Text = "";
        }

        private void botonModificar_Click(object sender, EventArgs e) {
            if (tablaDeHoteles.SelectedRows.Count == 1) {
                String hid = tablaDeHoteles.SelectedRows[0].Cells[0].Value.ToString();
                AoM_Hotel modificacionForm = new AoM_Hotel(userId, hid);
                modificacionForm.Show();
            }
            else {
                MessageBox.Show("Por favor seleccione un hotel");
            }
        }

        private void botonNuevoHotel_Click(object sender, EventArgs e) {
            AoM_Hotel altaForm = new AoM_Hotel(userId, "");
            altaForm.Show();
        }

        private void botonCerrar_Click(object sender, EventArgs e) {
            if (tablaDeHoteles.SelectedRows.Count == 1) {
                String hid = tablaDeHoteles.SelectedRows[0].Cells[0].Value.ToString();
                B_Hotel bajaForm = new B_Hotel(hid);
                bajaForm.Show();
            }
            else {
                MessageBox.Show("Por favor seleccione un hotel");
            }
        }
    }
}

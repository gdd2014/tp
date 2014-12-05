using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Utils;

namespace FrbaHotel.ABM_de_Usuario {
    public partial class ABM_Usuarios : Form {

        int userId;
        int rolId;
        int hotelId;

        String query = "SELECT Usuario_Id AS Id, " +
                             " Usuario_userName AS Usuario, " +
                             " Usuario_Nombre_Completo AS Nombre, " +
                             " Usuario_Mail AS Email, " +
                             " Estado FROM G_N.Usuarios";


        public ABM_Usuarios(int userId, int rolId, int hotelId) {
            this.userId = userId;
            this.rolId = rolId;
            this.hotelId = hotelId;

            InitializeComponent();
            uNameTextbox.Text = "";
            DBUtils.llenarDataGridView(tablaUsuarios, query);

            this.tablaUsuarios.Columns["Id"].Visible = false;
            this.tablaUsuarios.Columns["Nombre"].Width = 150;
            this.tablaUsuarios.Columns["Email"].Width = 200;
            this.tablaUsuarios.Columns["Estado"].Width = 60;
        }

        private void botonLimpiar_Click(object sender, EventArgs e) {
            uNameTextbox.Text = "";
        }

        private void botonBuscar_Click(object sender, EventArgs e) {
            DBUtils.llenarDataGridView(tablaUsuarios, query + " WHERE Usuario_userName LIKE '%" + uNameTextbox.Text + "%'");
        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e) {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        private void botonNuevoUsuario_Click(object sender, EventArgs e) {
            AoM_Usuario altaForm = new AoM_Usuario();
            altaForm.Show();
        }

        private void botonEliminarUsuario_Click(object sender, EventArgs e) {
            if (tablaUsuarios.SelectedRows.Count == 1) {
                DialogResult dr = MessageBox.Show("¿Está seguro que desea eliminar el usuario seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes) {
                    String uid = tablaUsuarios.SelectedRows[0].Cells[0].Value.ToString();
                    DBUtils.borradoLogico("Usuarios", "Usuario_Id", uid);
                }
            } else {
                MessageBox.Show("Por favor seleccione un usuario");
            }
        
        }

    }
}
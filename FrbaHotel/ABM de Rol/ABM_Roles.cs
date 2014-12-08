using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Utils;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class ABM_Roles : Form {


        String query = "SELECT Rol_Id AS Id, " +
                             " Rol_Nombre AS Rol, " +
                             " Estado FROM G_N.Roles";

        public ABM_Roles() {
            InitializeComponent();

            DBUtils.llenarDataGridView(tablaDeRoles, query);

            this.tablaDeRoles.Columns["Id"].Visible = false;
            this.tablaDeRoles.Columns["Rol"].Width = 275;
            this.tablaDeRoles.Columns["Estado"].Width = 60;
        }

        private void buscarButton_Click(object sender, EventArgs e) {
            DBUtils.llenarDataGridView(tablaDeRoles, query + " WHERE Rol_Nombre LIKE '%" + nombreDeRolTb.Text + "%'");
        }

        private void limpiarButton_Click(object sender, EventArgs e) {
            nombreDeRolTb.Text = "";
        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e) {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        private void eliminarRolButton_Click(object sender, EventArgs e) {
            if (tablaDeRoles.SelectedRows.Count == 1) {
                DialogResult dr = MessageBox.Show("¿Está seguro que desea eliminar el rol seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes) {
                    String rid = tablaDeRoles.SelectedRows[0].Cells[0].Value.ToString();
                    DBUtils.borradoLogico("Roles", "Rol_Id", rid);
                }
            } else {
                MessageBox.Show("Por favor seleccione un rol");
            }
        }

        private void modificarRolButton_Click(object sender, EventArgs e) {
            if (tablaDeRoles.SelectedRows.Count == 1) {
                String rid = tablaDeRoles.SelectedRows[0].Cells[0].Value.ToString();
                AoM_Rol modificacionForm = new AoM_Rol(rid);
                modificacionForm.Show();
            }
            else {
                MessageBox.Show("Por favor seleccione un rol");
            }
        }

        private void nuevoRolButton_Click(object sender, EventArgs e) {
            AoM_Rol altaForm = new AoM_Rol(null);
            altaForm.Show();
        }

    }
}
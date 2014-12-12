using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Utils;

namespace FrbaHotel.ABM_de_Cliente {

    public partial class ABM_Clientes : Form {
        
        public static String query = "SELECT TOP 50 c.Cliente_Id AS Id, " +
                                         " c.Cliente_Nombre + ' ' + c.Cliente_Apellido AS Nombre, " +
                                         " td.Documento_Tipo_Descripcion AS TipoDocumento, " +
                                         " c.Cliente_Documento_Nro AS NumeroDocumento, " +
                                         " c.Cliente_Mail AS Email, " +
                                         " Estado " +
                                     " FROM G_N.Clientes c " +
                                      "JOIN G_N.Documento_Tipos td ON c.Cliente_Documento_Tipo_Id = td.Documento_Tipo_Id ";

        public ABM_Clientes() {
            InitializeComponent();

            DBUtils.llenarDataGridView(tablaDeClientes, query);

            configuararTablaClientes(tablaDeClientes);

            String tDocQuery = "SELECT Documento_Tipo_Id AS tDocId, Documento_Tipo_Descripcion AS tDocDesc FROM G_N.Documento_Tipos";
            DBUtils.llenarComboBox(tDocCombo, tDocQuery, "tDocId", "tDocDesc");
            tDocCombo.SelectedValue = "";
        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e) {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        private void botonBuscar_Click(object sender, EventArgs e) {
            DBUtils.llenarDataGridView(tablaDeClientes, query + 
                " WHERE c.Cliente_Nombre LIKE '%" + nombreTextbox.Text + "%'" +
                  " AND c.Cliente_Apellido LIKE '%" + apellidoTextbox.Text + "%'" +
                  " AND c.Cliente_Mail LIKE '%" + emailTextbox.Text + "%'" +
                  " AND c.Cliente_Documento_Tipo_Id LIKE '%" + UIUtils.valorSeleccionado(tDocCombo) + "%'" +
                  " AND c.Cliente_Documento_Nro LIKE '%" + nDocTextbox.Text + "%'");
        }

        private void nDocTextbox_KeyPressed(object sender, KeyPressEventArgs e) {
            UIUtils.soloNumeros(e);
        }

        private void botonLimpiar_Click(object sender, EventArgs e) {
            nombreTextbox.Text = "";
            apellidoTextbox.Text = "";
            emailTextbox.Text = "";
            tDocCombo.SelectedValue = "";
            nDocTextbox.Text = "";
        }

        private void botonEliminar_Click(object sender, EventArgs e) {
            if (tablaDeClientes.SelectedRows.Count == 1) {
                DialogResult dr = MessageBox.Show("¿Está seguro que desea eliminar el cliente seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes) {
                    String cid = tablaDeClientes.SelectedRows[0].Cells[0].Value.ToString();
                    DBUtils.borradoLogico("Clientes", "Cliente_Id", cid);
                }
            } else {
                MessageBox.Show("Por favor seleccione un cliente");
            }
        }

        private void botonModificar_Click(object sender, EventArgs e) {
            if (tablaDeClientes.SelectedRows.Count == 1) {
                String cid = tablaDeClientes.SelectedRows[0].Cells[0].Value.ToString();
                AoM_Cliente modificacionForm = new AoM_Cliente(cid);
                modificacionForm.Show();
            }
            else
            {
                MessageBox.Show("Por favor seleccione un cliente");
            }
        }

        private void botonNuevoCliente_Click(object sender, EventArgs e) {
            AoM_Cliente altaForm = new AoM_Cliente("");
            altaForm.Show();
        }

        public static void configuararTablaClientes(DataGridView tablaDeClientes) {
            tablaDeClientes.Columns["Id"].Visible = false;
            tablaDeClientes.Columns["Nombre"].Width = 150;
            tablaDeClientes.Columns["TipoDocumento"].Width = 70;
            tablaDeClientes.Columns["NumeroDocumento"].Width = 70;
            tablaDeClientes.Columns["Email"].Width = 175;
            tablaDeClientes.Columns["TipoDocumento"].HeaderText = "Tipo de documento";
            tablaDeClientes.Columns["NumeroDocumento"].HeaderText = "Número de documento";
            tablaDeClientes.Columns["Estado"].Width = 60;
        }
    }
}

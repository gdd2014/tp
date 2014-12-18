using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Utils;
using FrbaHotel.ABM_de_Cliente;

namespace FrbaHotel.Registrar_Estadia {

    public partial class Reg_Checkin : Form {

        String codReserva;
        int ocupantes;
        int capacidadDeReserva;

        DataTable clientesTotalDT;
        DataTable clientesEstadíaDT;

        String baseQuery = "SELECT TOP 50 c.Cliente_Id AS Id, " +
                                 " c.Cliente_Nombre + ' ' + c.Cliente_Apellido AS Nombre, " +
                                 " dt.Documento_Tipo_Descripcion AS Tipo, " +
                                 " c.Cliente_Documento_Nro AS Numero" +
                              " FROM G_N.Clientes c JOIN G_N.Documento_Tipos dt ON c.Cliente_Documento_Tipo_Id = dt.Documento_Tipo_Id "; 

        public Reg_Checkin(String codReserva) {
            this.ocupantes = 1;
            this.capacidadDeReserva = DBUtils.queryRetornaInt("SELECT G_N.Capacidad_De_Reserva(" + codReserva + ")");
            this.codReserva = codReserva;
            InitializeComponent();

            String clientesEnReservaQuery = "SELECT Reserva_Cliente_Id From G_N.Reservas WHERE Reserva_Codigo=" + codReserva;

            clientesTotalDT = DBUtils.llenarDataGridView(tablaClientesTotal, baseQuery);
            clientesEstadíaDT = DBUtils.llenarDataGridView(tablaClientesEnEstadia, baseQuery + " WHERE c.Cliente_Id IN (" + clientesEnReservaQuery + ")");

            this.configurarTablaClientes(tablaClientesTotal);
            this.configurarTablaClientes(tablaClientesEnEstadia);

            String tDocQuery = "SELECT Documento_Tipo_Id AS tDocId, Documento_Tipo_Descripcion AS tDocDesc FROM G_N.Documento_Tipos";
            DBUtils.llenarComboBox(tDocCombo, tDocQuery, "tDocId", "tDocDesc");
        }

        private void botonAltaCli_Click(object sender, EventArgs e) {
            AoM_Cliente cf = new AoM_Cliente("");
            cf.Show();
        }

        private void configurarTablaClientes(DataGridView dgv) {
            dgv.Columns["Id"].Visible = false;
            dgv.Columns["Nombre"].Width = 136;
            dgv.Columns["Tipo"].Width = 75;
            dgv.Columns["Numero"].Width = 70;
        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e) {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        private void botonAddHab_Click(object sender, EventArgs e) {
            if (tablaClientesTotal.SelectedRows.Count == 1) {
                if (yaTieneAlCliente(tablaClientesTotal.SelectedRows[0].Cells[0].Value.ToString(), tablaClientesEnEstadia)) {
                    MessageBox.Show("El cliente seeccionado ya está cargado en la estadía.");
                } else if (ocupantes < capacidadDeReserva) {
                    ocupantes++;
                    GridUtils.MoveRows(clientesTotalDT, clientesEstadíaDT, GridUtils.GetSelectedDataRows(tablaClientesTotal));
                } else {
                    MessageBox.Show("Ya están tomados los " + capacidadDeReserva.ToString() + " lugares reservados.");
                }
            }
            else {
                MessageBox.Show("Por favor seleccione un cliente.");
            }
        }

        private Boolean yaTieneAlCliente(String clienteId, DataGridView dgv) {
            Boolean loTiene = false;
            foreach (DataGridViewRow r in dgv.SelectedRows) {
                if (r.Cells[0].Value.ToString() == clienteId) {
                    loTiene = true;
                }
            }
            return loTiene;
        }

        private void botonBuscarCli_Click(object sender, EventArgs e) {
            clientesTotalDT = DBUtils.llenarDataGridView(tablaClientesTotal, baseQuery +
                                        " WHERE c.Cliente_Documento_Tipo_Id LIKE '%" + UIUtils.valorSeleccionado(tDocCombo) + "%'" +
                                          " AND c.Cliente_Documento_Nro LIKE '%" + nDocTextbox.Text + "%'" + DBUtils.ySoloActivos());
        }

        private void botonRemoveHab_Click(object sender, EventArgs e) {
            if (tablaClientesTotal.SelectedRows.Count == 1) {
                GridUtils.MoveRows(clientesEstadíaDT, clientesTotalDT, GridUtils.GetSelectedDataRows(tablaClientesEnEstadia));
                ocupantes--;
            } else {
                MessageBox.Show("Por favor seleccione un cliente.");
            }
        }

        private void botonRegistrarEstadia_Click(object sender, EventArgs e) {
            List<String> errores = validarForm();
            UIUtils.mostrarErrores(errores);

            if (errores.Count == 0) {
                DBUtils.insertar("Estadias", campos(), valores());

                List<String> cliIds = new List<String>();
                foreach (DataGridViewRow row in tablaClientesEnEstadia.Rows) {
                    object v = row.Cells["Id"].Value;
                    if (v != null) {
                        cliIds.Add(v.ToString());
                    }
                }
                DBUtils.insertarNxNs("Estadias_Clientes", "Estadia_Reserva_Codigo", codReserva, "Cliente_Id", cliIds);

                DBUtils.actualizar("Reservas", new List<String>() { "Reserva_Estado_Id" }, new List<String>() { "6" }, "Reserva_Codigo", codReserva);

                MessageBox.Show("Checkin registrado satisfactoriamente.");
                this.Close();
            }


        }

        private List<String> campos() {
            List<String> camps = new List<String>();
            camps.Add("Estadia_Reserva_Codigo");
            camps.Add("Estadia_Fecha_Inicio");

            return camps;
        }


        private List<String> valores() {
            List<String> valores = new List<String>();
            
            valores.Add(codReserva);
            valores.Add(DBUtils.stringify(ConversionUtils.dateTimeAStr(DateTime.Today)));

            return valores;
        }

        private List<String> validarForm() {
            List<String> errores = new List<String>();

            return errores;
        }
            
    }
}

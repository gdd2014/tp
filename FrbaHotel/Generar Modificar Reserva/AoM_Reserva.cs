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

namespace FrbaHotel.Generar_Modificar_Reserva {

    public partial class AoM_Reserva : Form {

        String hotelId;
        String userId;

        String habsQuery;

        DataTable habsDispDT;
        DataTable habsEnReservaDT;

        Decimal costoDeReserva;
       
        public AoM_Reserva(String hotelId, String userId) {
            InitializeComponent();

            this.hotelId = hotelId;
            this.userId = userId;

            this.costoDeReserva = 0;

            habsQuery = "SELECT h.Habitacion_Id AS Id, " +
                             " h.Habitacion_Numero AS Numero, " +
                             " h.Habitacion_Piso AS Piso, " +
                             " ht.Habitacion_Tipo_Descripcion AS Tipo, " +
                             " ht.Habitacion_Tipo_Capacidad AS Capacidad, " +
                             " ho.Hotel_Estrellas AS estrellas, " +
                             " h.Habitacion_Es_Frente AS esFrente " +
                       " FROM G_N.Habitaciones h " +
                       " JOIN G_N.Habitacion_Tipos ht ON h.Habitacion_Tipo_Codigo = ht.Habitacion_Tipo_Codigo " +
                       " JOIN G_N.Hoteles ho ON h.Habitacion_Hotel_Id = ho.Hotel_Id " +
                       " WHERE h.Habitacion_Hotel_Id = " + this.hotelId;

            String regimenesQuery = "SELECT r.Regimen_Id AS regId, r.Regimen_Descripcion AS regDesc FROM G_N.Regimenes r " + 
                                        " JOIN G_N.Hoteles_Regimenes hr ON r.Regimen_Id = hr.Regimen_Id " +
                                        " WHERE hr.Hotel_Id = " + hotelId;

            DBUtils.llenarComboBox(regsCombo, regimenesQuery, "regId", "regDesc");

            habsDispDT = this.configurarTablaHabs(tablaHabsDisp);
            habsEnReservaDT = this.configurarTablaHabs(tablaHabsEnReserva);

            String tDocQuery = "SELECT Documento_Tipo_Id AS tDocId, Documento_Tipo_Descripcion AS tDocDesc FROM G_N.Documento_Tipos";
            DBUtils.llenarComboBox(tDocCombo, tDocQuery, "tDocId", "tDocDesc");
            tDocCombo.SelectedValue = "";

        }
        
        private void botonConsultar_Click(object sender, EventArgs e) {
            List<String> errores = validarConsulta();
            UIUtils.mostrarErrores(errores);

            if (errores.Count == 0) {
                habsDispDT = DBUtils.llenarDataGridView(tablaHabsDisp, habsQuery + " ORDER BY 2");
            }
        }

        private List<String> validarConsulta() {
            List<String> errores = new List<String>();

            UIUtils.validarFechaAnteriorAOtra(desdeDTP, hastaDTP, "desde", "hasta", errores);
            UIUtils.validarFechaPosteriorAAyer(desdeDTP, "desde", errores);

            UIUtils.validarComboCompleto(regsCombo, "Regímenes", errores);

            return errores;
        }


        private DataTable configurarTablaHabs(DataGridView dgv) {

            DataTable dt = DBUtils.llenarDataGridView(dgv, habsQuery + " AND 1 = 2");

            dgv.Columns["Id"].Visible = false;
            dgv.Columns["estrellas"].Visible = false;
            dgv.Columns["Capacidad"].Visible = false;
            dgv.Columns["Numero"].Width = 65;
            dgv.Columns["Piso"].Width = 55;
            dgv.Columns["Tipo"].Width = 95;
            dgv.Columns["esFrente"].HeaderText = "¿Es frontal? S/N";
            dgv.Columns["esFrente"].Width = 110;

            return dt;
        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e) {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        private void botonAddHab_Click(object sender, EventArgs e) {
            if (tablaHabsDisp.SelectedRows.Count == 1) {

                Decimal precio = calcularPrecio(tablaHabsDisp);
                costoDeReserva += precio;

                DialogResult dr = MessageBox.Show("El costo por noche de la habitacion seleccionada es " + precio.ToString("0.##") + " dólares \n ¿Desea continuar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes) {
                    consultaGroup.Enabled = false;
                    clienteGroup.Enabled = true;
                    botonConfirmarReserva.Enabled = true;
                    GridUtils.MoveRows(habsDispDT, habsEnReservaDT, GridUtils.GetSelectedDataRows(tablaHabsDisp));
                }
                mostrarCosto();
        
            } else {
                MessageBox.Show("Por favor seleccione una habitación.");
            }

        }

        private Decimal calcularPrecio(DataGridView dgv) {
            Decimal precioBase = DBUtils.queryRetornaDecimals("SELECT Regimen_Precio FROM G_N.Regimenes WHERE Regimen_Id=" + UIUtils.valorSeleccionado(regsCombo)).First();
            Decimal capacidad = Decimal.Parse(dgv.SelectedRows[0].Cells[4].Value.ToString());
            Decimal estrellas = Decimal.Parse(dgv.SelectedRows[0].Cells[5].Value.ToString());

            return precioBase * capacidad * estrellas;
        }

        private void botonRemoveHab_Click(object sender, EventArgs e) {
            if (tablaHabsEnReserva.SelectedRows.Count == 1) {
                Decimal precio = calcularPrecio(tablaHabsEnReserva);
                costoDeReserva -= precio;
                GridUtils.MoveRows(habsEnReservaDT, habsDispDT, GridUtils.GetSelectedDataRows(tablaHabsEnReserva));
                if (habsEnReservaDT.Rows.Count == 0) {
                    consultaGroup.Enabled = true;
                    clienteGroup.Enabled = false;
                    botonConfirmarReserva.Enabled = false;
                }
                mostrarCosto();
            } else {
                MessageBox.Show("Por favor seleccione una habitación.");
            }
            
        }

        private void mostrarCosto() {
            if (costoDeReserva != 0) {
                MessageBox.Show("El costo de su reserva es ahora de " + costoDeReserva.ToString("0.##") + " dólares por noche.");
            }
        }

        private void botonBuscarCli_Click(object sender, EventArgs e) {
            DBUtils.llenarDataGridView(tablaDeClientes, ABM_Clientes.query +
                " WHERE c.Cliente_Mail LIKE '%" + emailTextbox.Text + "%'" +
                  " AND c.Cliente_Documento_Tipo_Id LIKE '%" + UIUtils.valorSeleccionado(tDocCombo) + "%'" +
                  " AND c.Cliente_Documento_Nro LIKE '%" + nDocTextbox.Text + "%'");
            ABM_Clientes.configuararTablaClientes(tablaDeClientes);
        }

        private void botonAltaCli_Click(object sender, EventArgs e) {
            AoM_Cliente acf = new AoM_Cliente("");
            acf.Show();
        }

        public void soloNums_KeyPressed(object sender, KeyPressEventArgs e) {
            UIUtils.soloNumeros(e);
        }

        private void botonConfirmarReserva_Click(object sender, EventArgs e) {
            if (tablaDeClientes.SelectedRows.Count == 1) {
                DBUtils.insertar("Reservas", campos(), valores());
            } else {
                MessageBox.Show("Por favor seleccione un cliente.");
            }
        }

        private List<String> campos() {
            List<String> campos = new List<String>();

            campos.Add("Reserva_Cliente_Id");
            campos.Add("Reserva_Regimen_Id");
            campos.Add("Reserva_Fecha_Inicio");
            campos.Add("Reserva_Fecha_Fin");
            campos.Add("Reserva_Usuario_Id");
            campos.Add("Reserva_Estado_Id");

            return campos;
        }



       
    }
}
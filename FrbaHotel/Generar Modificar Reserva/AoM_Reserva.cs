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

        String reservaModId;

        String habsQuery;

        DataTable habsDispDT;
        DataTable habsEnReservaDT;

        Decimal costoDeReserva;

        String cliId;

        String baseQuery = "SELECT h.Habitacion_Id AS Id, " +
                             " h.Habitacion_Numero AS Numero, " +
                             " h.Habitacion_Piso AS Piso, " +
                             " ht.Habitacion_Tipo_Descripcion AS Tipo, " +
                             " ht.Habitacion_Tipo_Capacidad AS Capacidad, " +
                             " ho.Hotel_Estrellas AS estrellas, " +
                             " h.Habitacion_Es_Frente AS esFrente " +
                       " FROM G_N.Habitaciones h " +
                       " JOIN G_N.Habitacion_Tipos ht ON h.Habitacion_Tipo_Codigo = ht.Habitacion_Tipo_Codigo " +
                       " JOIN G_N.Hoteles ho ON h.Habitacion_Hotel_Id = ho.Hotel_Id ";
       
        public AoM_Reserva(String hotelId, String userId, String reservaModificandoId) {
            InitializeComponent();

            this.hotelId = hotelId;
            this.userId = userId;
            this.reservaModId = reservaModificandoId;

            this.costoDeReserva = 0;

            habsQuery = baseQuery +
                       " WHERE h.Habitacion_Hotel_Id = " + this.hotelId +
                         " AND G_N.Hab_Tiene_Reservas_en_Periodo(h.Habitacion_Id, {fDesde}, {fHasta}) = 0 ";

            habsDispDT = this.configurarTablaHabs(tablaHabsDisp);
            habsEnReservaDT = this.configurarTablaHabs(tablaHabsEnReserva);

            String tDocQuery = "SELECT Documento_Tipo_Id AS tDocId, Documento_Tipo_Descripcion AS tDocDesc FROM G_N.Documento_Tipos";
            DBUtils.llenarComboBox(tDocCombo, tDocQuery, "tDocId", "tDocDesc");
            tDocCombo.SelectedValue = "";

            int selReg = -1;
            if (esModificacion()) {
                
                modLabel.Visible = true;
                consultaGroup.Enabled = false;
                clienteGroup.Enabled = true;
                botonConfirmarReserva.Enabled = true;

                // Cambio el id del hotel por el original de la reserva
                hotelId = DBUtils.queryRetornaInt("SELECT G_N.Hotel_De_Reserva(" + reservaModId + ")").ToString();

                // MessageBox.Show("Se encuentra modificando una reserva del hotel: " + hotelId);

                // Lleno los campos con los valores de la reserva actual
                List<String> cmps = new List<String>();
                cmps.Add("Reserva_Cliente_Id");
                cmps.Add("Reserva_Regimen_Id");
                cmps.Add("Reserva_Fecha_Inicio");
                cmps.Add("Reserva_Fecha_Fin");

                DataRow rdr = DBUtils.levantarRegistroBD("Reservas", cmps, "Reserva_Codigo", reservaModId);

                cliId = ((int) rdr.ItemArray[0]).ToString();
                selReg = (int) rdr.ItemArray[1];
                desdeDTP.Value = (DateTime) rdr.ItemArray[2];
                hastaDTP.Value = (DateTime) rdr.ItemArray[3];

                // Lleno con las habs disponibes
                String qFinal = habsQuery.Replace("{fDesde}", DBUtils.stringify(ConversionUtils.dateTimeAStr(desdeDTP.Value)))
                                         .Replace("{fHasta}", DBUtils.stringify(ConversionUtils.dateTimeAStr(hastaDTP.Value)));
                habsDispDT = DBUtils.llenarDataGridView(tablaHabsDisp, qFinal + " ORDER BY 2");

                String habsEnReservaQuery = baseQuery +
                  " WHERE h.Habitacion_Id IN (SELECT Habitacion_Id FROM G_N.Reservas_Habitaciones WHERE Reserva_Codigo=" + reservaModId + ")";

                habsEnReservaDT = DBUtils.llenarDataGridView(tablaHabsEnReserva, habsEnReservaQuery + " ORDER BY 2");

                // Lleno el combo de regimenes necesario para el calculode precio de reservas..
                String regimenesQuery = "SELECT r.Regimen_Id AS regId, r.Regimen_Descripcion AS regDesc FROM G_N.Regimenes r " +
                            " JOIN G_N.Hoteles_Regimenes hr ON r.Regimen_Id = hr.Regimen_Id " +
                            " WHERE hr.Hotel_Id = " + hotelId;

                DBUtils.llenarComboBox(regsCombo, regimenesQuery, "regId", "regDesc");
                regsCombo.SelectedValue = selReg;


                costoDeReserva = 0;
                // Calculo el costo de la reserva actual
                foreach (DataGridViewRow dgvr in tablaHabsEnReserva.Rows) {
                    costoDeReserva += calcularPrecio(dgvr);
                }

                // Obtengo el cliente autor de la reserva
                DBUtils.llenarDataGridView(tablaDeClientes, ABM_Clientes.query + " WHERE Cliente_Id=" + cliId);
            } else {
                String regimenesQuery = "SELECT r.Regimen_Id AS regId, r.Regimen_Descripcion AS regDesc FROM G_N.Regimenes r " +
                        " JOIN G_N.Hoteles_Regimenes hr ON r.Regimen_Id = hr.Regimen_Id " + 
                        " WHERE hr.Hotel_Id = " + hotelId;

                DBUtils.llenarComboBox(regsCombo, regimenesQuery, "regId", "regDesc");
                regsCombo.SelectedValue = selReg;
            }

            
            
        }

        private Boolean esModificacion() {
            return reservaModId != null && reservaModId != "";
        }
        
        private void botonConsultar_Click(object sender, EventArgs e) {
            List<String> errores = validarConsulta();
            UIUtils.mostrarErrores(errores);

            if (errores.Count == 0) {
                String qFinal = habsQuery.Replace("{fDesde}", DBUtils.stringify(ConversionUtils.dateTimeAStr(desdeDTP.Value)))
                                         .Replace("{fHasta}", DBUtils.stringify(ConversionUtils.dateTimeAStr(hastaDTP.Value)));
                habsDispDT = DBUtils.llenarDataGridView(tablaHabsDisp, qFinal + " ORDER BY 2");

                if (habsDispDT.Rows.Count == 0) {
                    MessageBox.Show("Lamentablemente no se encontraron habitaciones disponibles en el período solicitado.");
                }
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
            String qFinal = habsQuery.Replace("{fDesde}", DBUtils.stringify(ConversionUtils.dateTimeAStr(DateTime.Today)))
                                     .Replace("{fHasta}", DBUtils.stringify(ConversionUtils.dateTimeAStr(DateTime.Today.AddDays(1))));

            // Configuro columnas sin valores
            DataTable dt = DBUtils.llenarDataGridView(dgv, qFinal + " AND 1 = 2");

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

                Decimal precio = calcularPrecio(tablaHabsDisp.SelectedRows[0]);
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

        private Decimal calcularPrecio(DataGridViewRow dgvr) {
            if (dgvr.Cells[4].Value == null) {
                // fila sin datos
                return 0;
            }

            Decimal precioBase = DBUtils.queryRetornaDecimals("SELECT Regimen_Precio FROM G_N.Regimenes WHERE Regimen_Id=" + UIUtils.valorSeleccionado(regsCombo)).First();
            Decimal capacidad = Decimal.Parse(dgvr.Cells[4].Value.ToString());
            Decimal estrellas = Decimal.Parse(dgvr.Cells[5].Value.ToString());

            return (precioBase + (estrellas * 10)) * capacidad;
        }

        private void botonRemoveHab_Click(object sender, EventArgs e) {
            if (tablaHabsEnReserva.SelectedRows.Count == 1) {
                Decimal precio = calcularPrecio(tablaHabsEnReserva.SelectedRows[0]);
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
                  " AND c.Cliente_Documento_Nro LIKE '%" + nDocTextbox.Text + "%'" + DBUtils.ySoloActivos());
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

                String rid = reservaModId;
                if (!esModificacion()) {
                    rid = DBUtils.insertarIdentity("Reservas", campos(), valores());
                } else {
                    DBUtils.actualizar("Reservas", campos(), valores(), "Reserva_Codigo", reservaModId);
                }
                

                List<String> habIds = new List<String>();
                foreach (DataGridViewRow row in tablaHabsEnReserva.Rows) {
                    object v = row.Cells["Id"].Value;
                    if (v != null) {
                        habIds.Add(v.ToString());
                    }
                }
                DBUtils.insertarNxNs("Reservas_Habitaciones", "Reserva_Codigo", rid, "Habitacion_Id", habIds);

                if (!esModificacion()) {
                    MessageBox.Show("Reserva generada exitosamente. Su código de reserva es: " + rid);
                } else {
                    MessageBox.Show("Reserva modificada exitosamente.");
                }

                DBUtils.ejecutarSP("Bajar_Reservas_De_Ayer_Por_No_Show", new List<String>(), new List<String>());
                this.Close();
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
            campos.Add("Reserva_Precio_Por_Noche");

            return campos;
        }

        private List<String> valores() {
            List<String> valores = new List<String>();

            valores.Add(tablaDeClientes.SelectedRows[0].Cells[0].Value.ToString());
            valores.Add(UIUtils.valorSeleccionado(regsCombo));
            valores.Add(DBUtils.stringify(ConversionUtils.dateTimeAStr(desdeDTP.Value)));
            valores.Add(DBUtils.stringify(ConversionUtils.dateTimeAStr(hastaDTP.Value)));

            String uid;
            if (userId != "") {
                uid = userId;
            } else {
                // Usuario guest generico
                uid = "2";
            }

            valores.Add(uid);

            if (esModificacion()) {
                valores.Add("2");
            } else {
                valores.Add("1");
            }

            valores.Add(costoDeReserva.ToString("0.##"));

            return valores;
        }

        private void desdeDTP_ValueChanged(object sender, EventArgs e) {
            // vacio la tabla de habs disponibles
            configurarTablaHabs(tablaHabsDisp);
        }

        private void hastaDTP_ValueChanged(object sender, EventArgs e) {
            // vacio la tabla de habs disponibles
            configurarTablaHabs(tablaHabsDisp);
        }

    }
}
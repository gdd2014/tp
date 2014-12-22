using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Utils;

namespace FrbaHotel.Facturacion {
    
    public partial class Facturacion : Form {

        String codRes;
        DataTable conceptosDT;
        Decimal totalConsumibles;
        Decimal totalEstadia;
        Decimal total;
        String regimenId;

        public Facturacion(String codReserva) {
            this.codRes = codReserva;
            InitializeComponent();

            String queryDeCliente = "SELECT c.Cliente_Nombre + ' ' + c.Cliente_Apellido, " +
                                          " dt.Documento_Tipo_Descripcion, " + 
                                          " c.Cliente_Documento_Nro, " + 
                                          " r.Reserva_Regimen_Id " +
                                      " FROM G_N.Reservas r JOIN G_N.Clientes c ON c.Cliente_Id = r.Reserva_Cliente_Id " + 
                                                          " JOIN G_N.Documento_Tipos dt on c.Cliente_Documento_Tipo_Id = dt.Documento_Tipo_Id " +
                                      " WHERE r.Reserva_Codigo=" + codReserva;

            DataRow clienteRow = DBUtils.levantarRegistroBD(queryDeCliente);

            nombreYApellidoTextbox.Text = (String) clienteRow.ItemArray[0];
            tDocTextbox.Text = (String) clienteRow.ItemArray[1];
            nDocTextbox.Text = ((Decimal) clienteRow.ItemArray[2]).ToString();
            regimenId = ((Int32) clienteRow.ItemArray[3]).ToString();

            String tPagosQuery = "SELECT Pago_Tipo_Id AS pagoTipoId, Pago_Tipo_Descripcion AS pagoTipoDesc FROM G_N.Pago_Tipos";
            DBUtils.llenarComboBox(tipoPagosCombo, tPagosQuery, "pagoTipoId", "pagoTipoDesc");

            String consQuery = "SELECT c.Consumible_Codigo AS Id, " +
                                     " SUM(ec.Consumible_Cantidad) AS Cantidad, " +
                                     " c.Consumible_Descripcion AS Concepto, " +
                                     " c.Consumible_Precio AS Precio_Unitario, " +
                                     " SUM(ec.Consumible_Cantidad) * c.Consumible_Precio AS Subtotal " +
                                        " FROM G_N.Estadias_Consumibles ec " +
                                        " JOIN G_N.Consumibles c ON ec.Consumible_Codigo = c.Consumible_Codigo " +
                                        " WHERE Estadia_Reserva_codigo= " + codRes + 
                                     " GROUP BY c.Consumible_Codigo, c.Consumible_Descripcion, c.Consumible_Precio ";

            conceptosDT = DBUtils.llenarDataGridView(tablaDeConceptos, consQuery);

            String resYEstsQuery = "SELECT r.Reserva_Precio_Por_Noche, " +
                                         " DATEDIFF(DAY, r.Reserva_Fecha_Inicio, r.Reserva_Fecha_Fin) AS diasReserva, " +
                                         " DATEDIFF(DAY, e.Estadia_Fecha_Inicio, e.Estadia_Fecha_Fin) AS diasDeEstadia " +
                                    " FROM G_N.Reservas r " +
                                    " JOIN G_N.Estadias e ON r.Reserva_Codigo = e.Estadia_Reserva_Codigo " +
                                    " WHERE r.Reserva_codigo=" + codRes;

            DataRow estadiaReservaRow = DBUtils.levantarRegistroBD(resYEstsQuery);
            Decimal precioPorNoche = (Decimal) estadiaReservaRow.ItemArray[0];
            int diasDeReserva = (int)estadiaReservaRow.ItemArray[1];
            int diasDeEstadia = (int)estadiaReservaRow.ItemArray[2];

            List<object> estadia = new List<object>() { null, diasDeEstadia.ToString(), "Noches de alojamiento", precioPorNoche.ToString(), (precioPorNoche * diasDeEstadia).ToString() };
            conceptosDT.Rows.Add(estadia.ToArray());

            if (diasDeEstadia != diasDeReserva) {
                int dias = diasDeReserva - diasDeEstadia;
                List<object> reserva = new List<object>() { null, dias.ToString(), "Noches reservadas pero no utilizadas", precioPorNoche.ToString(), (precioPorNoche * dias).ToString() };
                conceptosDT.Rows.Add(reserva.ToArray());
            }

            totalConsumibles = 0;
            totalEstadia = 0;
            foreach (DataGridViewRow dr in tablaDeConceptos.Rows) {
                if (dr.Cells[4].Value != null) {
                    if (dr.Cells[0].Value != null && dr.Cells[0].Value.ToString() != "") {
                        totalConsumibles += Decimal.Parse(dr.Cells[4].Value.ToString());
                    } else {
                        totalEstadia += Decimal.Parse(dr.Cells[4].Value.ToString());
                    }
                    
                } 
            }

            total = totalEstadia + totalConsumibles;
            if (regimenId == "1") {
                List<object> descuentoAllInclusive = new List<object>() { null, "1", "Descuento por regimen de estadía", (-totalConsumibles).ToString(), (-totalConsumibles).ToString() };
                conceptosDT.Rows.Add(descuentoAllInclusive.ToArray());
                total -= totalConsumibles;
            }

            totalTextbox.Text = total.ToString();

            tablaDeConceptos.Columns["Id"].Visible = false;
            tablaDeConceptos.Columns["Cantidad"].Width = 75;
            tablaDeConceptos.Columns["Concepto"].Width = 250;
            tablaDeConceptos.Columns["Precio_Unitario"].HeaderText = "Precio Unitario";
            tablaDeConceptos.Columns["Precio_Unitario"].Width = 100;
            tablaDeConceptos.Columns["Subtotal"].Width = 80;
        }

        private void tipoPagosCombo_SelectedIndexChanged(object sender, EventArgs e) {
            tarjetaGroup.Visible = UIUtils.valorSeleccionado(tipoPagosCombo) == "2";
        }

        private void botonFacturar_Click(object sender, EventArgs e) {
            List<String> errores = validar();
            UIUtils.mostrarErrores(errores);

            if (errores.Count == 0) {
                DBUtils.insertar("Facturas", campos(), valores());

                // Renglones
                foreach (DataGridViewRow dr in tablaDeConceptos.Rows) {
                    if (dr.Cells[4].Value != null) {
                        List<String> vals = new List<String>();
                        vals.Add(nFactTextbox.Text);
                        
                        // Es consumible
                        if (dr.Cells[0].Value != null && dr.Cells[0].Value.ToString() != "") {
                            vals.Add(dr.Cells[0].Value.ToString());
                        } else {
                            vals.Add("NULL");
                        }

                        vals.Add(dr.Cells[1].Value.ToString());
                        vals.Add(((Decimal)(dr.Cells[4].Value)).ToString("0.##"));
                        
                        DBUtils.insertar("Factura_Items", camposDeItem(), vals);
                    }
                }

                MessageBox.Show("Factura generada exitosamente.");

                this.Close();
            }

        }

        private List<String> camposDeItem() {
            List<String> campos = new List<String>();
            campos.Add("Factura_Item_Factura_Nro");
            campos.Add("Factura_Item_Consumible_Codigo");
            campos.Add("Factura_Item_Cantidad");
            campos.Add("Factura_Item_Monto");

            return campos;
        }

        private List<String> campos() {
            List<String> campos = new List<String>();
            campos.Add("Factura_Nro");
            campos.Add("Factura_Fecha");
            campos.Add("Factura_Total");
            campos.Add("Factura_Estadia_Reserva_Codigo");
            campos.Add("Factura_Pago_Tipo_Id");
            campos.Add("Factura_Tarjeta_Numero");
            campos.Add("Factura_Tarjeta_Cod_Seg");
            return campos;
        }

        private List<String> valores() {
            List<String> valores = new List<String>();
            valores.Add(nFactTextbox.Text);
            valores.Add(DBUtils.stringify(ConversionUtils.dateTimeAStr(fFacDTP.Value)));
            valores.Add(total.ToString("0.##"));
            valores.Add(codRes);
            valores.Add(UIUtils.valorSeleccionado(tipoPagosCombo));

            if (UIUtils.valorSeleccionado(tipoPagosCombo) == "2") {
                valores.Add(nTarjTextbox.Text);
                valores.Add(codSegTextbox.Text);
            }
            else {
                valores.Add("NULL");
                valores.Add("NULL");
            }

            return valores;
        }

        private List<String> validar() {
            List<String> errores = new List<String>();
            UIUtils.validarComboCompleto(tipoPagosCombo, "Medio de pago", errores);
            UIUtils.validarTextboxCompleto(nFactTextbox, "Número de factura", errores);
            UIUtils.validarUnicidadDeId(nFactTextbox, "Facturas", "Factura_Nro", errores);
            
            // Tarjeta de crédito
            if (UIUtils.valorSeleccionado(tipoPagosCombo) == "2") {
                UIUtils.validarTextboxCompleto(nTarjTextbox, "Número de tarjeta", errores);
                UIUtils.validarTextboxCompleto(codSegTextbox, "Código de seguridad", errores);
            }

            return errores;
        }

        private void soloNumeros(object sender, KeyPressEventArgs e) {
            UIUtils.soloNumeros(e);
        }
    }
}

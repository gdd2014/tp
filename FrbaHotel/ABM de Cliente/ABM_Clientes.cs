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
        
        String query = "SELECT TOP 50 c.Cliente_Id AS Id, " +
                             " c.Cliente_Nombre + ' ' + c.Cliente_Apellido AS Nombre, " +
                             " td.Documento_Tipo_Descripcion AS TipoDocumento, " +
                             " c.Cliente_Documento_Nro AS NumeroDocumento, " +
                             " c.Cliente_Mail AS Email, " +
                             " Estado FROM G_N.Clientes c " +
                                     "JOIN G_N.Documento_Tipos td ON c.Cliente_Documento_Tipo_Id = td.Documento_Tipo_Id ";

        public ABM_Clientes() {
            InitializeComponent();

            DBUtils.llenarDataGridView(tablaDeClientes, query);

            this.tablaDeClientes.Columns["Id"].Visible = false;
            this.tablaDeClientes.Columns["Nombre"].Width = 150;
            this.tablaDeClientes.Columns["TipoDocumento"].Width = 70;
            this.tablaDeClientes.Columns["NumeroDocumento"].Width = 70;
            this.tablaDeClientes.Columns["Email"].Width = 175;
            this.tablaDeClientes.Columns["TipoDocumento"].HeaderText = "Tipo de documento";
            this.tablaDeClientes.Columns["NumeroDocumento"].HeaderText = "Número de documento";
            this.tablaDeClientes.Columns["Estado"].Width = 60;
        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e) {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }
    }
}

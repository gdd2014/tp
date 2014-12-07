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

namespace FrbaHotel.ABM_de_Rol
{
    public partial class ABM_Roles : Form {
        public ABM_Roles() {
            InitializeComponent();
        }

        System.Data.SqlClient.SqlConnection con;

        private void Form1_Load(object sender, EventArgs e) {
            con = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = "Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;Persist Security Info=True;User ID=gd;Password=gd2014";

            String query = "SELECT Hotel_Dom_Calle AS Dirección, Hotel_Estrellas AS Estrellas FROM G_N.Hoteles";

            con.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, con);
            dataAdapter.SelectCommand.CommandTimeout = 600;
            dataAdapter.Fill(dataSet);
            tablaDeRoles.DataSource = dataSet.Tables[0];

            con.Close();
            
        }

        private void tablaDeRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void titulo_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
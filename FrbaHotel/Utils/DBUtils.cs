using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace FrbaHotel.Utils {
    static class DBUtils {

        public static SqlConnection getOpenConnection() {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;Persist Security Info=True;User ID=gd;Password=gd2014";
        
            con.Open();

            return con;
        }

        public static List<int> queryRetornaIds(String query) {
            SqlConnection con = getOpenConnection();
            SqlCommand cmd = new SqlCommand(query, con);

            List<int> ids = new List<int>();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                ids.Add(reader.GetInt32(0));
            }

            reader.Close();
            con.Close();

            return ids;
        }

        public static void llenarDataGridView(DataGridView dgv, String query) {
            SqlConnection con = getOpenConnection();

            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, con);
            dataAdapter.SelectCommand.CommandTimeout = 600;
            dataAdapter.Fill(dataSet);
            dgv.DataSource = dataSet.Tables[0];
        }

        public static void llenarComboBox(ComboBox cb, String query, String valueMember, String displayMember) {
            SqlConnection con = getOpenConnection();
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add(valueMember, typeof(string));
            dt.Columns.Add(displayMember, typeof(string));
            dt.Load(reader);

            cb.ValueMember = valueMember;
            cb.DisplayMember = displayMember;
            cb.DataSource = dt;

            reader.Close();
            con.Close();
        }

        public static String soloActivos() {
            return " AND Estado = 'A'";
        }
    }
}
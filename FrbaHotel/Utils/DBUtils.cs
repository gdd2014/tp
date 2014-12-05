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

        public static void borradoLogico(String tabla, String columnaIdentificadora, String valor) {
            ejecutarQuery("UPDATE G_N." + tabla + " SET Estado='N' WHERE " + columnaIdentificadora + "=" + valor);
        }

        public static void insertar(String tabla, List<String> campos, List<String> valores) {
            String query = "INSERT INTO G_N." + tabla + "(" + String.Join(",", campos.ToArray()) + ")" +
                               " VALUES (" + String.Join(",", valores.ToArray()) + ")";

            SqlConnection con = getOpenConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void insertarFKs(String tabla, String campoLocal, String valorLocal, String campoFK, List<String> valoresFK) {
            String queryLimpiado = "DELETE FROM G_N." + tabla + " WHERE " + campoLocal + "=" + valorLocal;
            ejecutarQuery(queryLimpiado);

            foreach (String fk in valoresFK) {
                String queryInsertFK = "INSERT INTO G_N." + tabla + " VALUES(" + valorLocal + "," + fk + ")";
                ejecutarQuery(queryInsertFK);
            }
        }

        public static String stringify(String baseStr) {
            return "'" + baseStr + "'";
        }

        public static String boolAEstado(Boolean checkeado) {
            String character;
            if (checkeado) {
                character = "'A'"; 
            } else character = "'N'";

            return character;
        }

        public static void ejecutarQuery(String query) {
            SqlConnection con = getOpenConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
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

        public static List<String> queryRetornaStrings(String query) {
            SqlConnection con = getOpenConnection();
            SqlCommand cmd = new SqlCommand(query, con);

            List<String> result = new List<String>();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                result.Add(reader.GetString(0));
            }

            reader.Close();
            con.Close();

            return result;
        }

        public static void llenarDataGridView(DataGridView dgv, String query) {
            SqlConnection con = getOpenConnection();

            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, con);
            dataAdapter.SelectCommand.CommandTimeout = 600;
            dataAdapter.Fill(dataSet);
            dgv.DataSource = dataSet.Tables[0];
        }

        public static void llenarComboBox(ListControl cb, String query, String valueMember, String displayMember) {
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

        public static String ySoloActivos() {
            return " AND Estado = 'A'";
        }

        public static String soloActivos() {
            return " WHERE Estado = 'A'";
        }
    }
}
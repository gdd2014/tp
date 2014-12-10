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

        public static void actualizar(String tabla, List<String> campos, List<String> valores, String campoId, String valorId) {
            String query = "UPDATE G_N." + tabla + " SET " + StringUtils.aCampoIgualValor(campos, valores) +
                                "WHERE " + campoId + "=" + valorId;

            SqlConnection con = getOpenConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void insertarNxNs(String tabla, String campoLocal, String valorLocal, String campoFK, List<String> valoresFK) {
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

        public static String levantarNullSafe(Object obj) {
            if (obj == null || obj is DBNull) return "";
            
            return (String) obj;
        }

        public static void ejecutarSP(String nombre, List<String> pars, List<String> vals) {
            SqlConnection con = getOpenConnection();

            SqlCommand cmd = new SqlCommand("G_N." + nombre, con);
            cmd.CommandType = CommandType.StoredProcedure;

            for (int i = 0; i < pars.Count; i++) {
                cmd.Parameters.AddWithValue(pars.ElementAt(i), vals.ElementAt(i));
            }

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public static void ejecutarSP1SoloParam(String nombre, String param, String valor) {
            ejecutarSP(nombre, new List<String>() { param }, new List<String>() { valor });
        }

        public static void ejecutarQuery(String query) {
            SqlConnection con = getOpenConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static List<int> queryRetornaInts(String query) {
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
                try {
                    result.Add(reader.GetString(0));
                } catch (Exception e) {
                    result.Add(reader.GetDecimal(0).ToString());
                }
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

        public static DataRow levantarRegistroBD(String tabla, List<String> campos, String campoId, String valorId) {
            SqlConnection con = getOpenConnection();

            DataTable dt = new DataTable();

            String q = "SELECT " + String.Join(",", campos.ToArray()) + " FROM G_N." + tabla + " WHERE " + campoId + "=" + valorId;

            SqlCommand comando = new SqlCommand(q, con);
            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            adapter.Fill(dt);

            con.Close();

            return dt.Rows[0];
        }

        public static String ySoloActivos() {
            return " AND Estado = 'A'";
        }

        public static String soloActivos() {
            return " WHERE Estado = 'A'";
        }
    }
}
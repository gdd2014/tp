using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace FrbaHotel.Utils {
    static class ConnectionUtils {

        public static SqlConnection getOpenConnection() {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;Persist Security Info=True;User ID=gd;Password=gd2014";
        
            con.Open();

            return con;
        }

        public static String soloActivos() {
            return " AND Estado = 'A'";
        }
    }
}

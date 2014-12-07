using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Utils {
    static class ConversionUtils {

        public static DateTime strADateTime(String s) {
            return DateTime.ParseExact(s, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        }

        public static String dateTimeAStr(DateTime dt) {
            return dt.ToString("yyyy-MM-dd");
        }

        public static Boolean estadoABool(String checkeado) {
            return checkeado == "A";
        }

        public static String boolAEstado(Boolean checkeado) {
            String character;
            if (checkeado) {
                character = "'A'";
            }
            else character = "'N'";

            return character;
        }
    }
}

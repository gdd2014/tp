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

        public static Boolean charABool(String character) {
            return character == "S";
        }

        public static String boolAChar(Boolean boool) {
            String character;
            if (boool) {
                character = "'S'";
            }
            else character = "'N'";

            return character;
        }


        public static Boolean IntABool(int entero) {
            return entero != 0;
        }

        public static int boolAInt(Boolean boool) {
            int entero;
            if (boool) {
                entero = 1;
            }
            else entero = 0;

            return entero;
        }
    }
}

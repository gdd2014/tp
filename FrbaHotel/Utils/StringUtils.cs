﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace FrbaHotel.Utils {
    static class StringUtils {
        public static string getHashSha256(string text) {

            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash) {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
}

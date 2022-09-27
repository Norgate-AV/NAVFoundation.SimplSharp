using System;

namespace NAVFoundation.SimplSharp {
    public static class Regex {
        public static short IsMatch(string value, string pattern) {
            return Convert.ToInt16(System.Text.RegularExpressions.Regex.IsMatch(value, pattern));
        }

        public static short IsValidIPAddress(string value) {
            const string pattern = "^(0[0-7]{10,11}|0(x|X)[0-9a-fA-F]{8}|(\\b4\\d{8}[0-5]\\b|\\b[1-3]?\\d{8}\\d?\\b)|((2[0-5][0-5]|1\\d{2}|[1-9]\\d?)|(0(x|X)[0-9a-fA-F]{2})|(0[0-7]{3}))(\\.((2[0-5][0-5]|1\\d{2}|\\d\\d?)|(0(x|X)[0-9a-fA-F]{2})|(0[0-7]{3}))){3})$";
            return Convert.ToInt16(System.Text.RegularExpressions.Regex.IsMatch(value, pattern));
        }

        public static short IsValidHostAddress(string value) {
            const string pattern = "^([a-zA-Z0-9]|[a-zA-Z0-9][a-zA-Z0-9\\-]{0,61}[a-zA-Z0-9])(\\.([a-zA-Z0-9]|[a-zA-Z0-9][a-zA-Z0-9\\-]{0,61}[a-zA-Z0-9]))*$";
            return Convert.ToInt16(System.Text.RegularExpressions.Regex.IsMatch(value, pattern));
        }
    }

    
}
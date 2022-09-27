using Crestron.SimplSharp;

namespace NAVFoundation.SimplSharp {
    public static class ErrorLogEntry {
        public static void Error(string message) {
            if (message.Length <= 0)
                return;

            ErrorLog.Error(message);
        }

        public static void Warn(string message) {
            if (message.Length <= 0)
                return;

            ErrorLog.Warn(message);
        }

        public static void Notice(string message) {
            if (message.Length <= 0)
                return;

            ErrorLog.Notice(message);
        }

        public static void Info(string message) {
            if (message.Length <= 0)
                return;

            ErrorLog.Info(message);
        }

        public static void Ok(string message) {
            if (message.Length <= 0)
                return;

            ErrorLog.Ok(message);
        }
    }
}
using System;
using System.Text;
using Crestron.SimplSharp;
using Crestron.SimplSharp.CrestronSockets;

namespace NAVFoundation.SimplSharp {
    public class PingUtility {
        private bool _busy;

        public delegate void PingResultReceivedEventHandler(short result);

        public PingResultReceivedEventHandler PingResultReceived { get; set; }

        public void Ping(string host) {
            if (host.Length <= 0 || _busy) return;

            _busy = true;

            short result = -1;
            var response = string.Empty;

            var command = "ping " + host + "\n";

            if (CrestronConsole.SendControlSystemCommand(command, ref response)) {
                if (response.Contains("Reply")) {
                    result = 0;
                } 

                OnPingResultReceived(result);
            }
            
            _busy = false;
        }

        protected virtual void OnPingResultReceived(short result) {
            if (PingResultReceived != null) {
                PingResultReceived(result);
            }
        }
    }
}

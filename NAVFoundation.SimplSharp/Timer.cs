using System;
using Crestron.SimplSharp;

namespace NAVFoundation.SimplSharp
{
    public class Timer
    {
        public delegate void TimerElapsedEventHandler();

        private CTimer _timer;

        public TimerElapsedEventHandler TimerElapsed { get; set; }

        public void Start(int dueTime) {
            try {
                if (_timer != null)
                    return;

                _timer = new CTimer(OnTimerElapsed, dueTime);
            } catch (Exception e) {
                ErrorLog.Error("Error starting timer: {0}", e.Message);
            }
        }

        public void Stop() {
            Kill();
        }

        public void Restart() {
            if (_timer == null || _timer.Disposed)
                return;

            _timer.Reset();
        }

        public void Restart(int newTime) {
            if (_timer == null || _timer.Disposed)
                return;

            _timer.Reset(newTime);
        }

        protected virtual void OnTimerElapsed(object obj) {

            if (TimerElapsed != null) {
                TimerElapsed();
            }

            Kill();
        }

        private void Kill() {
            if (_timer == null || _timer.Disposed)
                return;

            _timer.Stop();
            _timer.Dispose();
            _timer = null;
        }
    }
}
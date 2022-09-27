using System;
using Crestron.SimplSharp;

namespace NAVFoundation.SimplSharp
{
    public class MultipleTimer
    {
        public delegate void TimerElapsedEventHandler(ushort index);

        private CTimer[] _timers;

        public TimerElapsedEventHandler TimerElapsed { get; set; }

        public void Initialize(int capacity)
        {
            if (_timers != null)
                return;
            
            _timers = new CTimer[capacity];
        }

        public void Start(int index, int dueTime)
        {
            try
            {
                if (_timers[index] != null)
                    return;

                _timers[index] = new CTimer(OnTimerElapsed, index, dueTime);
            }
            catch (Exception e)
            {
                ErrorLog.Error("Error starting timer at index {0}: {1}", index, e.Message);
            }
        }

        public void Stop(int index)
        {
            Kill(index);
        }

        public void Restart(int index)
        {
            if (_timers[index] == null || _timers[index].Disposed)
                return;

            _timers[index].Reset();
        }

        public void Restart(int index, int newTime)
        {
            if (_timers[index] == null || _timers[index].Disposed)
                return;

            _timers[index].Reset(newTime);
        }

        protected virtual void OnTimerElapsed(object obj)
        {
            var index = Convert.ToUInt16(obj);

            if (TimerElapsed != null)
            {
                TimerElapsed(index);
            }

            Kill(index);
        }

        private void Kill(int index)
        {
            if (_timers[index] == null || _timers[index].Disposed)
                return;

            _timers[index].Stop();
            _timers[index].Dispose();
            _timers[index] = null;
        }
    }
}
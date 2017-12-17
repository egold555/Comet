using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Controllers.Renard
{
    // Base class for plugins that use the Renard protocol.
    public abstract class RenardBase
    {
        // Override and open the port. Return true if successful.
        protected abstract bool Open();

        // Override to close the port.
        protected abstract void Close();

        // Override to send the bytes. Already encoded according to the Renard protocol.
        protected abstract void SendPacket(List<byte> bytes);

        private byte[] _channelValues;
        private AutoResetEvent _eventTrigger;
        private RunState _state = RunState.Stopped;
        private readonly List<byte> _packet = new List<byte>();

        private const byte PacketIgnoreValue = 0x7d;
        private const byte StreamStartValue = 0x7e;
        private const byte PacketEscapeValue = 0x7f;
        private const byte PacketStartValue = 0x80;
        private const byte PacketEscapeSubtract = 0x4E;

        public void Startup()
        {
            if (!Open())
                return;


            new Thread(EventThread).Start();
            while (State != RunState.Running) {
                Thread.Sleep(1); //todo replace with Task.Delay() when using 4.5
            }
        }

        public void Shutdown()
        {
            if (State != RunState.Running) {
                Close();
                return;
            }

            State = RunState.Stopping;
            _eventTrigger.Set();
            while (State != RunState.Stopped) {
                Thread.Sleep(5);//todo replace with Task.Delay() when using 4.5
            }

            Close();
        }

        public void Event(byte[] channelValues)
        {
            _channelValues = channelValues;
            _eventTrigger.Set();
        }

        private void EventThread()
        {
            State = RunState.Running;
            _eventTrigger = new AutoResetEvent(false);
            try {
                while (State == RunState.Running) {
                    _eventTrigger.WaitOne();
                    try {
                        FireEvent();
                    }
                    catch (TimeoutException) { }
                }
            }
            catch {
                if (State == RunState.Running) {
                    State = RunState.Stopping;
                }
            }
            finally {
                State = RunState.Stopped;
            }
        }


        private void FireEvent()
        {
            if (State != RunState.Running) {
                return;
            }

            DoEvent(_channelValues);
        }


        private void DoEvent(IEnumerable<byte> channelValues)
        {
            _packet.Clear();
            _packet.Add(StreamStartValue);
            _packet.Add(PacketStartValue);
            foreach (var c in channelValues) {
                switch (c) {
                    case PacketEscapeValue:
                    case PacketIgnoreValue:
                    case StreamStartValue:
                        _packet.Add(PacketEscapeValue);
                        _packet.Add((byte)(c - PacketEscapeSubtract));
                        break;

                    default:
                        _packet.Add(c);
                        break;
                }
                if ((_packet.Count % 100) == 0) {
                    _packet.Add(PacketIgnoreValue);
                }
            }

            SendPacket(_packet);
        }

        private RunState State {
            get { return _state; }
            set {
                _state = value;
                if (value != RunState.Stopping) {
                    return;
                }
                _eventTrigger.Set();
            }
        }

        private enum RunState
        {
            Running,
            Stopping,
            Stopped
        }

    }
}

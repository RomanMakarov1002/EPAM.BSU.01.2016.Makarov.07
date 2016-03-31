using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public class ClockImitationEventArgs : EventArgs
    {
        private string _message;

        public ClockImitationEventArgs(string mes)
        {
            _message = mes;
        }

        public string Message { get { return _message; } }
    }


    public class MessagesSender
    {
        public event EventHandler<ClockImitationEventArgs> Clock = delegate { };

        protected virtual void OnClock(ClockImitationEventArgs e)
        {
            Clock(this, e);
        }

        public void SimulateClock(int time,string mes)
        {
            Thread.Sleep(time*1000);
            OnClock(new ClockImitationEventArgs(mes));
        }
    }


    public class ConnectedUser
    {
        public ConnectedUser(MessagesSender ms)
        {
            ms.Clock += Connect;
        }

        public void Connect(object sender, ClockImitationEventArgs e)
        {
            Console.WriteLine("User connected and received message {0}",e.Message);
        }

        public void Disconnect(MessagesSender ms)
        {
            ms.Clock -= Connect;
        }
    }

    public class ConnectedAdmin
    {
        public ConnectedAdmin(MessagesSender ms)
        {
            ms.Clock += Connect;
        }

        public void Connect(object sender, ClockImitationEventArgs e)
        {
            Console.WriteLine("Admin connected and received {0}", e.Message);
        }

        public void Disconnect(MessagesSender ms)
        {
            ms.Clock -= Connect;
        }
    }
}

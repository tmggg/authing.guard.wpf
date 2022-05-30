using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Events.EventAggreator
{
    public class EventManagement
    {
        private static EventManagement _instance;
        public static EventManagement Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EventManagement();
                }
                return _instance;
            }
        }

        private IEventHub _eventHub;

        public EventManagement()
        {
            _eventHub = new EventHub();
        }

        public void AddListener(int eventId, IEventListener eventListener)
        {
            _eventHub.AddListener(eventId, eventListener);
        }

        public void Dispatch(int eventId, IEventArgs args = null)
        {
            _eventHub.Dispatch(eventId, args);
        }

        public void RemoveListener(int eventId, IEventListener eventListener)
        {
            _eventHub.RemoveListener(eventId, eventListener);
        }
    }
}

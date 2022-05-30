using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Events.EventAggreator
{
    public class EventHub : IEventHub
    {
        private Dictionary<int, List<IEventListener>> _eventDic = new Dictionary<int, List<IEventListener>>();

        public void AddListener(int eventId, IEventListener listener)
        {
            if (_eventDic == null)
            {
                return;
            }

            List<IEventListener> list = null;
            _eventDic.TryGetValue(eventId, out list);
            if (list == null)
            {
                list = new List<IEventListener>();
                _eventDic[eventId]=list;
            }

            list.Add(listener);
        }

        public void Dispatch(int eventId, IEventArgs args)
        {
            if (_eventDic == null)
            {
                return;
            }

            List<IEventListener> list = null;
            _eventDic.TryGetValue(eventId, out list);
            if (list ==null || list.Count==0)
            {
                return;
            }

            list.ForEach((item) => 
            {
                IEventListener listener = item;
                listener.HandleEvent(eventId, args);
            });
        }

        public void RemoveListener(int eventId, IEventListener listener)
        {
            if (_eventDic == null)
            {
                return;
            }

            List<IEventListener> list = null;
            _eventDic.TryGetValue(eventId,out list);
            if (list != null && list.Contains(listener))
            {
                list.Remove(listener);
            }
        }
    }
}

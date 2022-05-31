using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Events.EventAggreator
{
    public interface IEventHub
    {
        void AddListener(int eventId, IEventListener listener);

        void RemoveListener(int eventId, IEventListener listener);

        void Dispatch(int eventId, IEventArgs args);
    }
}

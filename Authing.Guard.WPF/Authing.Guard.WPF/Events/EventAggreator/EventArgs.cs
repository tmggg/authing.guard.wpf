using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Events.EventAggreator
{
    public class EventArgs<T> : IEventArgs
    {
        public T arg;

        public static IEventArgs CreateEventArgs(T val)
        {
            return new EventArgs<T>(val);
        }

        private EventArgs(T val)
        {
            this.arg = val;
        }
    }
}

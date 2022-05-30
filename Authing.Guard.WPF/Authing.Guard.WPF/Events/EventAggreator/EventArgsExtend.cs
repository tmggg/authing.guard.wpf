using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Events.EventAggreator
{
   public static class EventArgsExtend
    {
        public static T GetValue<T>(this IEventArgs args)
        {
            T result = default(T);
            if (args is EventArgs<T>)
            {
                result = ((EventArgs<T>)args).arg;
            }

            return result;
        }
    }
}

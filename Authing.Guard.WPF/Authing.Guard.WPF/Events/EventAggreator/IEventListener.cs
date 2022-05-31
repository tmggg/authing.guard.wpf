﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Events.EventAggreator
{
    public interface IEventListener
    {
        void HandleEvent(int eventId, IEventArgs args);
    }
}

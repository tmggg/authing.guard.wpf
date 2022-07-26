using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authing.ApiClient.Domain.Model;
using Authing.Guard.WPF.Events;

namespace Authing.Guard.WPF.Models
{
    public class UserWithEvent
    {
        public User User { get; set; }
        public EventId EventFrom { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authing.Guard.WPF.Enums;

namespace Authing.Guard.WPF.Models
{
    public class InfoReplenish : INotifyCollectionChanged
    {
        public InfoType InfoType { get; set; } = InfoType.Nomal;
        public string Name { get; set; }
        public string TipContent => "请输入" + Name;
        public bool IsNessary { get; set; }
        public bool HaveItem => Items.Any();
        public IEnumerable<string> Items { get; set; } = new List<string>();

        public event NotifyCollectionChangedEventHandler CollectionChanged;
    }
}
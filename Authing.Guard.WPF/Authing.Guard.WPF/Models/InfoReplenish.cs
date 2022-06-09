using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Authing.Guard.WPF.Enums;
using Authing.Guard.WPF.Infrastructures;

namespace Authing.Guard.WPF.Models
{
    public class InfoReplenish : ObservableClass
    {
        public InfoType InfoType { get; set; } = InfoType.Nomal;

        public string Name { get; set; }
        public string TipContent => "请输入" + Name;

        public bool IsNessary { get; set; }

        public bool HaveItem => Items.Any();
        public IEnumerable<string> Items { get; set; } = new List<string>();

        private string _data;

        public string Data
        {
            get => _data;
            set
            {
                if (value != _data)
                {
                    _data = value;
                    OnPropertyChanged(nameof(Data));
                }
            }
        }

        private string _code;

        public string Code
        {
            get => _code;
            set
            {
                if (value != _code)
                {
                    _code = value;
                    OnPropertyChanged(nameof(Code));
                }
            }
        }
    }
}
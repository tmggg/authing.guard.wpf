using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Authing.Guard.WPF.Models;

namespace Authing.Guard.WPF.Infrastructures.DataTemplateSelector
{
    public class UserInfoSelector : System.Windows.Controls.DataTemplateSelector
    {
        public DataTemplate InfoWithTextBox { get; set; }
        public DataTemplate InfoWithComboBox { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item != null)
            {
                var data = (InfoReplenish)item;
                if (data.HaveItem)
                {
                    return InfoWithComboBox;
                }
            }
            return InfoWithTextBox;
        }
    }
}
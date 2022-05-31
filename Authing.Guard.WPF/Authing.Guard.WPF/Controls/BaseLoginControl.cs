using Authing.Guard.WPF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Authing.Guard.WPF.Controls
{
    public class BaseLoginControl:UserControl
    {
        public LoginMethods LoginMethod
        {
            get
            {
                return (LoginMethods)GetValue(LoginMethodProperty);
            }
            set
            {
                SetValue(LoginMethodProperty, value);
            }
        }

        public static DependencyProperty LoginMethodProperty =
            DependencyProperty.Register(nameof(LoginMethod), typeof(LoginMethods), typeof(BaseLoginControl), new PropertyMetadata());
    }
}

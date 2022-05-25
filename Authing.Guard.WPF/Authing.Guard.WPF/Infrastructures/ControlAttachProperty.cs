using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Authing.Guard.WPF.Infrastructures
{
    public class ControlAttachProperty
    {
        public static string GetPlaceHolder(DependencyObject obj)
        {
            return (string)obj.GetValue(PlaceHolderProperty);
        }

        public static void SetPlaceHolder(DependencyObject obj, string value)
        {
            obj.SetValue(PlaceHolderProperty, value);
        }

        
        public static readonly DependencyProperty PlaceHolderProperty =
            DependencyProperty.RegisterAttached("PlaceHolder", typeof(string), typeof(ControlAttachProperty), new PropertyMetadata(string.Empty));
    }
}

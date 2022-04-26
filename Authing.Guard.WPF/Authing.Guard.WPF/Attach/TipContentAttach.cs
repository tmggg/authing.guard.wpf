using System.Windows;

namespace Authing.Guard.WPF.Attach
{
    public class TipContentAttach
    {
        public static readonly DependencyProperty TipContentProperty = DependencyProperty.RegisterAttached(
            "TipContent", typeof(string), typeof(TipContentAttach), new PropertyMetadata(default(string)));

        public static void SetTipContent(DependencyObject element, string value)
        {
            element.SetValue(TipContentProperty, value);
        }

        public static string GetTipContent(DependencyObject element)
        {
            return (string)element.GetValue(TipContentProperty);
        }
    }
}
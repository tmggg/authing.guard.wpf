using System.Windows;
using System.Windows.Controls;

namespace Authing.Guard.WPF.Controls
{
    public class PrimaryButton : Button
    {
        public CornerRadius CornerRadius
        {
            get
            {
                return (CornerRadius)GetValue(CornerRadiusProperty);
            }
            set
            {
                SetValue(CornerRadiusProperty, value);
            }
        }

        public static DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(PrimaryButton), new PropertyMetadata(new CornerRadius()));
    }
}
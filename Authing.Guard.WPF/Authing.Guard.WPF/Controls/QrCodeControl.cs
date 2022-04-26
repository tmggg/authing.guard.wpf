using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Authing.Guard.WPF.Controls
{
    public class QrCodeControl : UserControl
    {
        public static readonly DependencyProperty IsExpiredProperty = DependencyProperty.Register(
            "IsExpired", typeof(bool), typeof(QrCodeControl), new PropertyMetadata(default(bool)));

        public bool IsExpired
        {
            get { return (bool)GetValue(IsExpiredProperty); }
            set { SetValue(IsExpiredProperty, value); }
        }

        public static readonly DependencyProperty QrCodeProperty = DependencyProperty.Register(
            "QrCode", typeof(ImageSource), typeof(QrCodeControl), new PropertyMetadata(default(ImageSource)));

        public ImageSource QrCode
        {
            get { return (ImageSource)GetValue(QrCodeProperty); }
            set { SetValue(QrCodeProperty, value); }
        }
    }
}
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Authing.Guard.WPF.Controls
{
    public class QrCodeControl : UserControl
    {
        #region 定义样式中存在的控件

        private const string ElementRefreshBtn = "PART_RefreshBtn";

        #endregion 定义样式中存在的控件

        public static readonly DependencyProperty IsExpiredProperty = DependencyProperty.Register(
            "IsExpired", typeof(bool), typeof(QrCodeControl), new PropertyMetadata(default(bool)));

        public bool IsExpired
        {
            get { return (bool)GetValue(IsExpiredProperty); }
            set { SetValue(IsExpiredProperty, value); }
        }

        public static readonly DependencyProperty QrCodeProperty = DependencyProperty.Register(
            "QrCode", typeof(ImageSource), typeof(QrCodeControl), new PropertyMetadata(default(ImageSource)));

        private Button _refreshBtn;

        public static readonly DependencyProperty RefreshCommandProperty = DependencyProperty.Register(
            "RefreshCommand", typeof(ICommand), typeof(QrCodeControl), new PropertyMetadata(default(ICommand)));

        public ICommand RefreshCommand
        {
            get { return (ICommand)GetValue(RefreshCommandProperty); }
            set { SetValue(RefreshCommandProperty, value); }
        }

        public ImageSource QrCode
        {
            get { return (ImageSource)GetValue(QrCodeProperty); }
            set { SetValue(QrCodeProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _refreshBtn = GetTemplateChild(ElementRefreshBtn) as Button;
        }
    }
}
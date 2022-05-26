using Authing.Guard.WPF.Commons;
using Authing.Guard.WPF.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Authing.Guard.WPF.Views.LoginView
{
    /// <summary>
    /// ScanCodeLoginView.xaml 的交互逻辑
    /// </summary>
    public partial class ScanCodeLoginView : UserControl
    {
        private ObservableCollection<SocialLogin> DemoData;

        public ScanCodeLoginView()
        {
            InitializeComponent();
            InitDemoData();
            InitBinding();
        }

        private void InitDemoData()
        {
            DemoData = new ObservableCollection<SocialLogin>();
            QrCodeControl.QrCode = new BitmapImage(new Uri("pack://application:,,,/Authing.Guard.WPF;component/Commons/Images/qrcode.png"));
            QrCodeControl.IsExpired = true;
            DemoData.Add(new SocialLogin("https://www.qq.com", new SolidColorBrush(Colors.Red), Application.Current.Resources["QQ"] as Geometry));
            DemoData.Add(new SocialLogin("https://www.google.com", new SolidColorBrush(Colors.Orange), Application.Current.Resources["Google"] as Geometry));
            DemoData.Add(new SocialLogin("https://www.linkedin.cn", new SolidColorBrush(Colors.Yellow), Application.Current.Resources["Linkedin"] as Geometry));
            DemoData.Add(new SocialLogin("https://www.weixin.com", new SolidColorBrush(Colors.Green), Application.Current.Resources["WeChat"] as Geometry));
            DemoData.Add(new SocialLogin("https://www.facebook.com", new SolidColorBrush(Colors.Blue), Application.Current.Resources["FaceBook"] as Geometry));
            DemoData.Add(new SocialLogin("https://www.github.com", new SolidColorBrush(Colors.Purple), Application.Current.Resources["GitHub"] as Geometry));
            SocialloginControl.ItemsSource = DemoData;
            //Messenger.Default.Register();
        }

        private void InitBinding()
        {
            CommandBindings.Add(new CommandBinding(AuthingGuardCommands.RefreshQrCodeCommand, Executed));
        }

        private void Executed(object sender, ExecutedRoutedEventArgs e)
        {
            QrCodeControl.QrCode = QrCodeControl.QrCode.ToString().Contains("2") ? new BitmapImage(new Uri("pack://application:,,,/Authing.Guard.WPF;component/Commons/Images/qrcode.png")) :
                new BitmapImage(new Uri("pack://application:,,,/Authing.Guard.WPF;component/Commons/Images/qrcode2.png"));
            QrCodeControl.IsExpired = false;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                if (((Button)sender).DataContext is SocialLogin)
                {
                    SocialLogin data = ((Button)sender).DataContext as SocialLogin;
                    Process.Start(data.LoginUrl);
                    QrCodeControl.IsExpired = true;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using UITest.Annotations;

namespace UITest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public bool Change { get; set; }

        public ICommand TestCommand { get; }

        public ICommand OpenBrowserCommand { get; set; }
        public ICommand ChangeLanguage { get; set; }

        public ObservableCollection<SocialLogin> DemoData { get; }

        public BitmapImage QRCode { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            TestCommand = new TestCommand(TempFunc, p => true);
            OpenBrowserCommand = new RelayCommand<SocialLogin>(p =>
            {
                Process.Start(p.LoginUrl);
                QRCode = QRCode.ToString().Contains("2") ? new BitmapImage(new Uri("pack://application:,,,/Resources/Images/qrcode.png")) :
                    new BitmapImage(new Uri("pack://application:,,,/Resources/Images/qrcode2.png"));
            });
            ChangeLanguage = new RelayCommand<Label>(ChangeLang);
            DemoData = new ObservableCollection<SocialLogin>();
            MakeDemo();
            QRCode = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/qrcode.png"));
        }

        private void ChangeLang(Label obj)
        {
            if (string.Equals(obj.Content.ToString(),"English", StringComparison.Ordinal))
            {
                var res = Application.Current.Resources.MergedDictionaries;
                var lang = res.First(p => p.Source.AbsoluteUri.Contains("en-US.xaml"));
                Application.Current.Resources.MergedDictionaries.Remove(lang);
                Application.Current.Resources.MergedDictionaries.Add(lang);
            }
            if (string.Equals(obj.Content.ToString(), "中文", StringComparison.Ordinal))
            {
                var res = Application.Current.Resources.MergedDictionaries;
                var lang = res.First(p => p.Source.AbsoluteUri.Contains("zh-CN.xaml"));
                Application.Current.Resources.MergedDictionaries.Remove(lang);
                Application.Current.Resources.MergedDictionaries.Add(lang);
            }
        }

        private void MakeDemo()
        {
            DemoData.Add(new SocialLogin("https://www.qq.com", new SolidColorBrush(Colors.Red), Application.Current.Resources["QQ"] as Geometry));
            DemoData.Add(new SocialLogin("https://www.google.com", new SolidColorBrush(Colors.Orange), Application.Current.Resources["Google"] as Geometry));
            DemoData.Add(new SocialLogin("https://www.linkedin.cn", new SolidColorBrush(Colors.Yellow), Application.Current.Resources["Linkedin"] as Geometry));
            DemoData.Add(new SocialLogin("https://www.weixin.com", new SolidColorBrush(Colors.Green), Application.Current.Resources["WeChat"] as Geometry));
            DemoData.Add(new SocialLogin("https://www.facebook.com", new SolidColorBrush(Colors.Blue), Application.Current.Resources["FaceBook"] as Geometry));
            DemoData.Add(new SocialLogin("https://www.github.com", new SolidColorBrush(Colors.Purple), Application.Current.Resources["GitHub"] as Geometry));
            //Messenger.Default.Register();
        }

        private void TempFunc(object parameter)
        {
            MessageBox.Show("刷新二维码");
            Change = false;
        }

        private async void Testbtn_OnClick(object sender, RoutedEventArgs e)
        {
            Testbtn.IsBusy = Testbtn.IsBusy != true;
            await TaskEx.Delay(2000);
            Testbtn.IsBusy = Testbtn.IsBusy != true;
            Testbtn.StartCountDown = true;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Change = Change == false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class SocialLogin : INotifyPropertyChanged
    {
        public string LoginUrl { get; }
        public SolidColorBrush FColor { get; }
        public Geometry Logo { get; }

        public SocialLogin(string loginUrl, SolidColorBrush fColor, Geometry logo)
        {
            LoginUrl = loginUrl;
            FColor = fColor;
            Logo = logo;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
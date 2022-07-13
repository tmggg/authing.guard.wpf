using Authing.Guard.WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Authing.Guard.WPF.Views.Classic.MainView
{
    /// <summary>
    /// ThirdLoginMainView.xaml 的交互逻辑
    /// </summary>
    public partial class ThirdLoginMainView : UserControl
    {
        private ObservableCollection<SocialLogin> DemoData;
        public ThirdLoginMainView()
        {
            InitializeComponent();

            Loaded += ThirdLoginMainView_Loaded;
        }

        private void ThirdLoginMainView_Loaded(object sender, RoutedEventArgs e)
        {
            SimulationData();
        }

        private void SimulationData()
        {
            DemoData = new ObservableCollection<SocialLogin>();
            DemoData.Add(new SocialLogin("https://www.qq.com", new SolidColorBrush(Colors.Red), Application.Current.Resources["QQ"] as Geometry));
            DemoData.Add(new SocialLogin("https://www.google.com", new SolidColorBrush(Colors.Orange), Application.Current.Resources["Google"] as Geometry));
            DemoData.Add(new SocialLogin("https://www.linkedin.cn", new SolidColorBrush(Colors.Yellow), Application.Current.Resources["Linkedin"] as Geometry));
            DemoData.Add(new SocialLogin("https://www.weixin.com", new SolidColorBrush(Colors.Green), Application.Current.Resources["WeChat"] as Geometry));
            DemoData.Add(new SocialLogin("https://www.facebook.com", new SolidColorBrush(Colors.Blue), Application.Current.Resources["FaceBook"] as Geometry));
            DemoData.Add(new SocialLogin("https://www.github.com", new SolidColorBrush(Colors.Purple), Application.Current.Resources["GitHub"] as Geometry));
            SocialloginControl.ItemsSource = DemoData;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                if (((Button)sender).DataContext is SocialLogin)
                {
                    SocialLogin data = ((Button)sender).DataContext as SocialLogin;
                    Process.Start(data.LoginUrl);
                }
            }
        }
    }
}

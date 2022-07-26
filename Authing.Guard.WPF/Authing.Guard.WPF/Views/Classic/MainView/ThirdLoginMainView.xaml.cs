using Authing.ApiClient.Domain.Model;
using Authing.Guard.WPF.Controls;
using Authing.Guard.WPF.Enums;
using Authing.Guard.WPF.Factories;
using Authing.Guard.WPF.Models;
using Authing.Guard.WPF.Services;
using Authing.Guard.WPF.Utils;
using Authing.Guard.WPF.Utils.Extensions;
using Authing.Guard.WPF.Utils.Impl;
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

        private CollapsableChromiumWebBrowser MyBrowser = null;

        private IJsonService m_JsonService;

        public ThirdLoginMainView()
        {
            InitializeComponent();

            Loaded += ThirdLoginMainView_Loaded;

            m_JsonService = new JsonService();
        }

        private void ThirdLoginMainView_Loaded(object sender, RoutedEventArgs e)
        {
            MyBrowser = new CollapsableChromiumWebBrowser();

            InitData();
        }

        private void InitData()
        {
            DemoData = new ObservableCollection<SocialLogin>();

            foreach (var item in ConfigService.SocialConnections)
            {
                string url = SocialAuthClient.Instance.Authorize(item.Identifier,new Library.Domain.Model.Authentication.SocialAuthorizeOptions { Protocol="oidc"});

                 
                SocialLogin a = new SocialLogin( "https://www.qq.com", url, new SolidColorBrush(Color.FromArgb(255, 174, 185, 212)), item.Provider.GetEnumByEnumMember<IconType>());

                DemoData.Add(a);
            }

            SocialloginControl.ItemsSource = DemoData;

        }

        private void SimulationData()
        {
            DemoData = new ObservableCollection<SocialLogin>();
            //DemoData.Add(new SocialLogin("https://www.qq.com", new SolidColorBrush(Colors.Red), Application.Current.Resources["QQ"] as Geometry));
            //DemoData.Add(new SocialLogin("https://www.google.com", new SolidColorBrush(Colors.Orange), Application.Current.Resources["Google"] as Geometry));
            //DemoData.Add(new SocialLogin("https://www.linkedin.cn", new SolidColorBrush(Colors.Yellow), Application.Current.Resources["Linkedin"] as Geometry));
            //DemoData.Add(new SocialLogin("https://www.weixin.com", new SolidColorBrush(Colors.Green), Application.Current.Resources["WeChat"] as Geometry));
            //DemoData.Add(new SocialLogin("https://www.facebook.com", new SolidColorBrush(Colors.Blue), Application.Current.Resources["FaceBook"] as Geometry));
            //DemoData.Add(new SocialLogin("https://www.github.com", new SolidColorBrush(Colors.Purple), Application.Current.Resources["GitHub"] as Geometry));
            SocialloginControl.ItemsSource = DemoData;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                if (((Button)sender).DataContext is SocialLogin)
                {
                    if (!MyBrowser.IsDisposed)
                    {
                        MyBrowser = new CollapsableChromiumWebBrowser();
                    }

                    webGrid.Children.Clear();
                    webGrid.Children.Add(MyBrowser);

                    SocialLogin data = ((Button)sender).DataContext as SocialLogin;
                    //Process.Start(data.LoginUrl);
                    MyBrowser.LoginSuccessAction += LoginSuccess;
                    MyBrowser.OpenAuthWindow(data.AuthenticationUrl, data.LoginUrl);
                }
            }
        }

        private  void LoginSuccess(string userData)
        {
            try
            {
                SocialLoginResult result = m_JsonService.Deserialize<SocialLoginResult>(userData);

                if (result.LoginEvent.source != "authing" || result.LoginEvent.source != "socialLogin")
                {
                    return;
                }

                if (result.Code == 200)
                {
                    //result.data.
                    //登录成功
                  var ss=  m_JsonService.Deserialize<UpdateUserInput>(m_JsonService.Serialize(result.Data));
                //AuthClient.Instance.RegisterByUsername(ss.Username,ss.Password);
                //AuthClient.Instance.LoginByUsername
                }
                else
                { 
                    //登录失败
                }

                Dispatcher.BeginInvoke(new Action(() =>
                {
                    
                    webGrid.Children.Clear();
                    MyBrowser.Dispose();
                }));

                MyBrowser.LoginSuccessAction -= LoginSuccess;
            }
            catch (Exception exp)
            {
                return;
            }
        }

        //private void 
    }
}

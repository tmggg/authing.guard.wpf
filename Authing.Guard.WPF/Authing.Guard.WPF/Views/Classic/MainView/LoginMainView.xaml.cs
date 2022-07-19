using Authing.Guard.WPF.Controls;
using Authing.Guard.WPF.Enums;
using Authing.Guard.WPF.Events;
using Authing.Guard.WPF.Events.EventAggreator;
using Authing.Guard.WPF.Models;
using Authing.Guard.WPF.Utils;
using Authing.Guard.WPF.Utils.Extensions;
using Authing.Guard.WPF.Utils.Impl;
using Authing.Guard.WPF.Views.LoginView;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// LoginMainView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginMainView : UserControl
    {
        private GuardConfig config;

        private IImageService m_ImageService;

        public LoginMainView(GuardConfig guardConfig)
        {
            InitializeComponent();

            config = guardConfig;
            m_ImageService = new ImageService();
            Loaded += LoginMainView_Loaded;
        }

        private void LoginMainView_Loaded(object sender, RoutedEventArgs e)
        {
            InitLoginMethod();

            if (!string.IsNullOrWhiteSpace(config.Logo))
            {
                byte[] byteArray = m_ImageService.GetImageFromResponse(config.Logo);

                MemoryStream ms = new MemoryStream(byteArray);

                imgLogo.Source = BitmapFrame.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.Default);
            }

            tbTitle.Text = config.Title;
        }

        private void InitLoginMethod()
        {
            foreach (var item in config.LoginMethods)
            {
                if (item == LoginMethods.AD)
                {
                    //添加 AD 登录
                    TabItem tabItem = new TabItem();
                    tabItem.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                    tabItem.SetResourceReference(HeaderedContentControl.HeaderProperty, "LoginByAd");
                    tabItem.Content = new LoginByAD();
                    loginViewTabControl.Items.Add(tabItem);

                    if (config.DefaultLoginMethod == item)
                    {
                        tabItem.IsSelected = true;
                    }
                }
                else if (item == LoginMethods.AppQr)
                {
                    //添加 App 扫码登录界面
                    TabItem tabItem = new TabItem();
                    tabItem.SetResourceReference(HeaderedContentControl.HeaderProperty, "AppScanLogin");
                    tabItem.Content = new ScanCodeLoginView();

                    loginViewTabControl.Items.Add(tabItem);

                    if (config.DefaultLoginMethod == item)
                    {
                        tabItem.IsSelected = true;
                    }
                }
                else if (item == LoginMethods.LDAP)
                {
                    //添加 LDAP 目录身份登录
                }
                else if (item == LoginMethods.Password)
                {
                    //添加账号+密码登录

                    PasswordLoginView passwordLoginView = new PasswordLoginView();

                    TabItem tabItem = new TabItem();
                    tabItem.HorizontalContentAlignment = HorizontalAlignment.Stretch;

                    tabItem.Content = passwordLoginView;
                    tabItem.SetResourceReference(HeaderedContentControl.HeaderProperty, "PasswordLogin");

                    loginViewTabControl.Items.Add(tabItem);

                    if (config.DefaultLoginMethod == item)
                    {
                        tabItem.IsSelected = true;
                    }
                }
                else if (item == LoginMethods.PhoneCode)
                {
                    //添加手机号验证码登录
                    SMSCodeLoginView sMSCodeLoginView = new SMSCodeLoginView();
                    TabItem tabItem = new TabItem();
                    tabItem.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                    tabItem.SetResourceReference(HeaderedContentControl.HeaderProperty, "SendCodeLogin");
                    tabItem.Content = sMSCodeLoginView;
                    loginViewTabControl.Items.Add(tabItem);

                    if (config.DefaultLoginMethod == item)
                    {
                        tabItem.IsSelected = true;
                    }
                }
                else if (item == LoginMethods.WxMinQr)
                {
                    //添加微信小程序扫码登录
                }
            }

            //第三方登录
            
        }

        private void btnSwitchLogin_Click(object sender, RoutedEventArgs e)
        {
            if (btnSwitchLogin.IsChecked == true)
            {
                moreLoginGrid.Visibility = Visibility.Collapsed;
                QRCodeLoginGrid.Visibility = Visibility.Visible;
            }
            else
            {
                moreLoginGrid.Visibility = Visibility.Visible;
                QRCodeLoginGrid.Visibility = Visibility.Collapsed;
            }
        }

        private void btnForgetPassword_Click(object sender, RoutedEventArgs e)
        {
            EventManagement.Instance.Dispatch((int)EventId.ToResetPassword);
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            EventManagement.Instance.Dispatch((int)EventId.ToRegister);
        }

        private void loginViewTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BaseLoginControl loginControl = (e.AddedItems[0] as TabItem).Content as BaseLoginControl;

            if (loginControl == null)
            {
                return;
            }

            if (loginControl.LoginMethod != LoginMethods.AppQr)
            {
                btnForgetPassword.Visibility = Visibility.Visible;
                btnForgetPassword.Visibility = Visibility.Visible;
            }
            else if (loginControl.LoginMethod == LoginMethods.AppQr)
            {
                btnForgetPassword.Visibility = Visibility.Hidden;
                btnRegister.Visibility = Visibility.Hidden;
            }
        }

        private void btnBackFromResetPwd_Click(object sender, RoutedEventArgs e)
        {
            btnSwitchLogin.Visibility = Visibility.Visible;
            LoginContent.Visibility = Visibility.Visible;
        }
    }
}

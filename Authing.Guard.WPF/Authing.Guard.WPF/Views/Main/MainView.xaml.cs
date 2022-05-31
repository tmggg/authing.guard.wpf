using Authing.ApiClient.Domain.Client.Impl.AuthenticationClient;
using Authing.ApiClient.Domain.Model;
using Authing.Guard.WPF.Controls;
using Authing.Guard.WPF.Enums;
using Authing.Guard.WPF.Events;
using Authing.Guard.WPF.Events.EventAggreator;
using Authing.Guard.WPF.Factories;
using Authing.Guard.WPF.Services;
using Authing.Guard.WPF.Utils;
using Authing.Guard.WPF.Utils.Extensions;
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

namespace Authing.Guard.WPF.Views.LoginView
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : BaseGuardControl, IEventListener
    {
        private IImageService m_ImageService;


        private LoginPage m_CurrentLoginPage;//当前的页面

        public MainView()
        {
            InitializeComponent();

            Loaded += MainView_Loaded;
            Unloaded += MainView_Unloaded;

            m_ImageService = new Utils.Impl.ImageService();
        }

        private void MainView_Unloaded(object sender, RoutedEventArgs e)
        {
            RemoveEvent();
        }

        private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            InitConfig();
            AddEvent();

            if (string.IsNullOrWhiteSpace(AppId))
            {
                throw new Exception("请输入 AppId");
            }

            if (!string.IsNullOrWhiteSpace(Config.Logo))
            {
                byte[] byteArray = m_ImageService.GetImageFromResponse(Config.Logo);

                MemoryStream ms = new MemoryStream(byteArray);

                imgLogo.Source = BitmapFrame.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.Default);
            }

            SimulationData();

            InitLoginMethod();

            InitRegisterMethod();



            //根据配置显示界面
        }

        private void AddEvent()
        {
            foreach (EventId item in Enum.GetValues(typeof(EventId)))
            {
                EventManagement.Instance.AddListener((int)item, this);
            }
        }

        private void RemoveEvent()
        {
            foreach (EventId item in Enum.GetValues(typeof(EventId)))
            {
                EventManagement.Instance.RemoveListener((int)item, this);
            }
        }

        private void InitConfig()
        {
            ConfigService.AppId = AppId;
            ConfigService.UserPoolId = UserPoolId;
            ConfigService.SecretId = Secret;

            Config = new Models.GuardConfig();
        }

        private void SimulationData()
        {

            Config.LoginMethods = new List<LoginMethods>();
            Config.RegisterMethods = new List<RegisterMethods>();

            Config.LoginMethods.Add(LoginMethods.Password);
            Config.LoginMethods.Add(LoginMethods.PhoneCode);
            Config.LoginMethods.Add(LoginMethods.AppQr);
        }

        private void InitLoginMethod()
        {

            foreach (var item in Config.LoginMethods)
            {
                if (item == LoginMethods.AD)
                {
                    //添加 AD 登录
                }
                else if (item == LoginMethods.AppQr)
                {
                    //添加 App 扫码登录界面
                    TabItem tabItem = new TabItem();
                    tabItem.Header = Application.Current.Resources["AppScanLogin"] as String;
                    tabItem.Content = new ScanCodeLoginView();

                    loginViewTabControl.Items.Add(tabItem);

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
                    tabItem.Header = Application.Current.Resources["PasswordLogin"] as String;
                    tabItem.Content = new PasswordLoginView();

                    tabItem.Content = passwordLoginView;
                    tabItem.Header = passwordLoginView.LoginMethod.GetDescription();

                    loginViewTabControl.Items.Add(tabItem);
                }
                else if (item == LoginMethods.PhoneCode)
                {
                    //添加手机号验证码登录
                    SMSCodeLoginView sMSCodeLoginView = new SMSCodeLoginView();
                    TabItem tabItem = new TabItem();
                    tabItem.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                    tabItem.Header = Application.Current.Resources["PhoneLogin"] as String;
                    tabItem.Content = new SMSCodeLoginView();
                    loginViewTabControl.Items.Add(tabItem);
                }
                else if (item == LoginMethods.WxMinQr)
                {
                    //添加微信小程序扫码登录
                }
            }
        }

        private void InitRegisterMethod()
        {

            foreach (var item in Config.RegisterMethods)
            {
                if (item == RegisterMethods.Email)
                {
                    //添加邮箱注册
                }
                else if (item == RegisterMethods.Phone)
                {
                    //添加手机注册
                }
            }
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
            btnSwitchLogin.Visibility = Visibility.Hidden;
            LoginContent.Visibility = Visibility.Hidden;
            resetPwdContent.Visibility = Visibility.Visible;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

        }

        private void loginViewTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BaseLoginControl loginControl = (e.AddedItems[0] as TabItem).Content as BaseLoginControl;

            if (loginControl == null)
            {
                return;
            }

            if (loginControl.LoginMethod == LoginMethods.Password)
            {
                btnForgetPassword.Visibility = Visibility.Visible;
                btnForgetPassword.Visibility = Visibility.Visible;
            }
            else if (loginControl.LoginMethod == LoginMethods.PhoneCode)
            {
                btnForgetPassword.Visibility = Visibility.Hidden;
                btnRegister.Visibility = Visibility.Visible;
            }
        }

        public void HandleEvent(int eventId, IEventArgs args)
        {
            switch (eventId)
            {
                case (int)EventId.Load:
                    Config.Load?.Invoke(AuthClient.Instance);
                    break;
                case (int)EventId.LoadError:
                    Config.LoadError?.Invoke(args.GetValue<string>());
                    break;
                case (int)EventId.Login:
                    Config.Login?.Invoke(args.GetValue<User>(), AuthClient.Instance);
                    break;
                case (int)EventId.LoginError:
                    Config.LoginError?.Invoke(args.GetValue<string>());
                    break;
                case (int)EventId.Register:
                    Config.Register?.Invoke(args.GetValue<User>(), AuthClient.Instance);
                    break;
                case (int)EventId.RegisterError:
                    Config.RegisterError?.Invoke(args.GetValue<string>());
                    break;
                case (int)EventId.PwdEmailSend:
                    Config.PwdEmailSend?.Invoke();
                    break;
                case (int)EventId.PwdEmailSendError:
                    Config.PwdEmailSendError?.Invoke(args.GetValue<string>());
                    break;
                case (int)EventId.PwdPhoneSend:
                    Config.PwdPhoneSend?.Invoke();
                    break;
                case (int)EventId.PwdPhoneSendError:
                    Config.PwdPhoneSendError?.Invoke(args.GetValue<string>());
                    break;
                case (int)EventId.PwdReset:
                    Config.PwdReset?.Invoke();
                    break;
                case (int)EventId.PwdResetError:
                    Config.PwdResetError?.Invoke(args.GetValue<string>());
                    break;
                case (int)EventId.LoginTabChange:
                    Config.LoginTabChange?.Invoke(args.GetValue<string>());
                    break;
                case (int)EventId.RegisterTabChange:
                    Config.RegisterTabChange?.Invoke(args.GetValue<string>());
                    break;
                case (int)EventId.RegisterInfoCompleted:
                    Config.RegisterInfoCompleted?.Invoke(args.GetValue<User>(), AuthClient.Instance);
                    break;
                case (int)EventId.RegisterInfoCompletedError:
                    Config.RegisterInfoCompletedError?.Invoke(args.GetValue<User>(), AuthClient.Instance);
                    break;

                default: break;
            }
        }

        private void btnBackFromResetPwd_Click(object sender, RoutedEventArgs e)
        {
            resetPwdContent.Visibility = Visibility.Hidden;
            btnSwitchLogin.Visibility = Visibility.Visible;
            LoginContent.Visibility = Visibility.Visible;
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox)
            {
                if (((ComboBox)sender).SelectedItem is Label)
                {
                    var obj = ((ComboBox)sender).SelectedItem as Label;
                    if (string.Equals(obj.Content.ToString(), "English", StringComparison.Ordinal))
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
            }
        }
    }
}

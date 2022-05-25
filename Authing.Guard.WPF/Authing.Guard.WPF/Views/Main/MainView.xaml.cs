using Authing.Guard.WPF.Controls;
using Authing.Guard.WPF.Enums;
using Authing.Guard.WPF.Factories;
using Authing.Guard.WPF.Utils;
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
    public partial class MainView : BaseGuardControl
    {
        private IImageService m_ImageService;


        private LoginPage m_CurrentLoginPage;//当前的页面

        public MainView()
        {
            InitializeComponent();

            Loaded += MainView_Loaded;

            m_ImageService = new Utils.Impl.ImageService();
        }


        private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
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

        private void SimulationData()
        {

            Config.LoginMethods = new List<LoginMethods>();
            Config.RegisterMethods = new List<RegisterMethods>();

            Config.LoginMethods.Add(LoginMethods.Password);
            Config.LoginMethods.Add(LoginMethods.PhoneCode);
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
                }
                else if (item == LoginMethods.LDAP)
                {
                    //添加 LDAP 目录身份登录
                }
                else if (item == LoginMethods.Password)
                {
                    //添加账号+密码登录
                    TabItem tabItem = new TabItem();
                    tabItem.Header = "11231";
                    tabItem.Content = new PasswordLoginView();

                    loginViewTabControl.Items.Add(tabItem);
                }
                else if (item == LoginMethods.PhoneCode)
                {
                    //添加手机号验证码登录
                    TabItem tabItem = new TabItem();
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

            }
        }


    }
}

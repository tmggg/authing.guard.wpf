using Authing.ApiClient.Domain.Client.Impl.AuthenticationClient;
using Authing.ApiClient.Domain.Model;
using System.Windows;

namespace Authing.Guard.WPF.Test
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        protected static string UserPoolId { get; set; } = "613189b2eed393affbbf396e";
        protected static string UserPoolSecret { get; set; } = "ccf4951a33e5d54d64e145782a65f0a7";
        protected static string AppSecret { get; set; } = "d453ef11f873527eb4a8a084f4b5e059";
        protected static string AppId { get; set; } = "62a9902a80f55c22346eb296";

        protected static string TestUserId = "61a82941979c96c04ed9e920";


        static AuthenticationClient authenticationClient;

        public MainWindow()
        {
            InitializeComponent();

         //   authenticationClient = new AuthenticationClient(
         //    opt =>
         //    {
         //        opt.AppId = AppId;
         //        opt.Secret = AppSecret;
         //        opt.UserPoolId = UserPoolId;
         //    }
         //);

         //   var result = authenticationClient.LoginByUsername("qidong9999", "3866364", null).Result;

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            guardView.Config.Login += Login;
            guardView.Config.LoginError += LoginError;
        }

        private void Login(User user, AuthenticationClient authenticationClient)
        {
            MessageBox.Show("登录成功");
        }

        private void LoginError(string error)
        {
            MessageBox.Show("登录失败：" + error);
        }
    }
}
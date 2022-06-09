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
        public MainWindow()
        {
            InitializeComponent();

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
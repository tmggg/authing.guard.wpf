using Authing.ApiClient.Types;
using Authing.Guard.WPF.Factories;
using System;
using System.Collections.Generic;
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
    /// PasswordLoginView.xaml 的交互逻辑
    /// </summary>
    public partial class PasswordLoginView : UserControl
    {
        public PasswordLoginView()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //
           await AuthClient.Instance.LoginByUsername(tbAccount.Text, tbPassword.Text ,new  RegisterAndLoginOptions() );
        }
    }
}

using Authing.ApiClient.Domain.Model;
using Authing.ApiClient.Types;
using Authing.Guard.WPF.Factories;
using Authing.Guard.WPF.Services;
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
    /// SMSCodeLoginView.xaml 的交互逻辑
    /// </summary>
    public partial class SMSCodeLoginView : UserControl
    {
        public SMSCodeLoginView()
        {
            InitializeComponent();

            Loaded += SMSCodeLoginView_Loaded;
        }

        private void SMSCodeLoginView_Loaded(object sender, RoutedEventArgs e)
        {
            tbPhone.Warn = false;
            tbSMSCode.Warn = false;
            tbPhoneInfo.Visibility = Visibility.Collapsed;
            tbSMSCodeInfo.Visibility = Visibility.Collapsed;
        }

        private async void btnSendSMS_Click(object sender, RoutedEventArgs e)
        {
            if (!RegexService.IsMobile(tbPhone.Text))
            {
                tbPhoneInfo.Visibility = Visibility.Visible;
                tbPhone.Warn = true;
                return;
            }

            CommonMessage commonMessage = await AuthClient.Instance.SendSmsCode(tbPhone.Text);

            if (commonMessage.Code.Value != 200)
            {
                throw new Exception(commonMessage.Message);
            }
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSMSCode.Text))
            {
                tbSMSCodeInfo.Visibility = Visibility.Visible;
                tbSMSCode.Warn = true;
                return;
            }

            User user = await AuthClient.Instance.LoginByPhoneCode(tbPhone.Text.Trim(), tbSMSCode.Text.Trim(), new RegisterAndLoginOptions());
            if (user != null)
            {

            }
        }
    }
}

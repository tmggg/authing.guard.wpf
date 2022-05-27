using Authing.ApiClient.Domain.Model;
using Authing.ApiClient.Types;
using Authing.Guard.WPF.Controls;
using Authing.Guard.WPF.Factories;
using Authing.Guard.WPF.Infrastructures;
using Authing.Guard.WPF.Utils;
using Authing.Guard.WPF.Utils.Impl;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Authing.Guard.WPF.Views.LoginView
{
    /// <summary>
    /// SMSCodeLoginView.xaml 的交互逻辑
    /// </summary>
    public partial class SMSCodeLoginView : BaseLoginControl
    {
        private IWindowsAPI m_WindowsAPI;
        private IRegexService m_RegexService;

        public SMSCodeLoginView()
        {
            InitializeComponent();

            Loaded += SMSCodeLoginView_Loaded;

            m_WindowsAPI = new WindowsAPI();
            m_RegexService = new RegexService();

            LoginMethod = Enums.LoginMethods.PhoneCode;
        }

        private void SMSCodeLoginView_Loaded(object sender, RoutedEventArgs e)
        {
            tbPhone.Warn = false;
            tbSMSCode.Warn = false;
            tbPhoneRemind.Visibility = Visibility.Collapsed;
            tbSMSCodeRemind.Visibility = Visibility.Collapsed;
        }

        private async void btnSendSMS_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                tbPhone.Warn = true;
                tbPhoneRemind.Text = "手机号未填写";
                tbPhoneRemind.Visibility = Visibility.Visible;
                return;
            }

            if (!m_RegexService.IsPhone(tbPhone.Text))
            {
                tbPhone.Warn = true;
                tbPhoneRemind.Text = "输入有效的手机号";
                tbPhoneRemind.Visibility = Visibility.Visible;
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
            if (!JudgeInput())
            {
                return;
            }
            User user = null;

            user = await AuthClient.Instance.LoginByPhoneCode(tbPhone.Text, tbSMSCode.Text, new RegisterAndLoginOptions { AutoRegister = false });

            if (user != null)
            {
                //用户登录成功
            }
        }

        private bool JudgeInput()
        {
            bool flag = true;

            if (string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                tbPhone.Warn = true;
                tbPhoneRemind.Visibility = Visibility.Visible;
                BeginStoryboard(tbPhone);

                flag = false;
            }
            if (string.IsNullOrWhiteSpace(tbSMSCode.Text))
            {
                tbSMSCode.Warn = true;
                tbSMSCodeRemind.Visibility = Visibility.Visible;
                BeginStoryboard(tbSMSCode);

                flag = false;
            }
            if (cbAgree.IsChecked == null || cbAgree.IsChecked == false)
            {
                cbAgree.Foreground = new SolidColorBrush(Colors.Red);
                BeginStoryboard(cbAgree);

                flag = false;
            }

            return flag;
        }

        private void BeginStoryboard<T>(T control) where T : Control
        {
            Storyboard storyboard = (Storyboard)control.Resources["ShakeStoryboard"];
            Storyboard.SetTarget(storyboard.Children.ElementAt(0) as DoubleAnimationUsingKeyFrames, control);
            storyboard.Begin();
        }

        private void cbAgree_Checked(object sender, RoutedEventArgs e)
        {
            cbAgree.Foreground = new SolidColorBrush(Colors.Black);
            linkService.Foreground = new SolidColorBrush(Colors.MediumBlue);
            linkPrivacy.Foreground = new SolidColorBrush(Colors.MediumBlue);
        }

        private void cbAgree_Unchecked(object sender, RoutedEventArgs e)
        {
            cbAgree.Foreground = new SolidColorBrush(Colors.Red);
            linkService.Foreground = new SolidColorBrush(Colors.Red);
            linkPrivacy.Foreground = new SolidColorBrush(Colors.Red);
        }

        private void linkService_Click(object sender, RoutedEventArgs e)
        {
            m_WindowsAPI.ShellExecute("open", linkService.NavigateUri.AbsoluteUri);
        }

        private void linkPrivacy_Click(object sender, RoutedEventArgs e)
        {
            m_WindowsAPI.ShellExecute("open", linkPrivacy.NavigateUri.AbsoluteUri);
        }

        private void tbSMSCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbSMSCode.Warn = false;
            tbSMSCodeRemind.Visibility = Visibility.Collapsed;
        }

        private void tbPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbPhone.Warn = false;
            tbPhoneRemind.Visibility = Visibility.Collapsed;
        }

        private async void Testbtn_OnClick(object sender, RoutedEventArgs e)
        {
            Testbtn.IsBusy = Testbtn.IsBusy != true;
            await TaskExHelper.Delay(2000);
            Testbtn.IsBusy = Testbtn.IsBusy != true;
            Testbtn.StartCountDown = true;
        }
    }
}
using Authing.ApiClient.Domain.Model;
using Authing.ApiClient.Types;
using Authing.Guard.WPF.Controls;
using Authing.Guard.WPF.Enums;
using Authing.Guard.WPF.Factories;
using Authing.Guard.WPF.Infrastructures;
using Authing.Guard.WPF.Utils;
using Authing.Guard.WPF.Utils.Impl;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Authing.Guard.WPF.Views.LoginView
{
    /// <summary>
    /// PasswordLoginView.xaml 的交互逻辑
    /// </summary>
    public partial class PasswordLoginView : BaseLoginControl
    {
        private IWindowsAPI m_WindowsAPI;
        private IRegexService m_RegexService;



        public PasswordLoginView()
        {
            InitializeComponent();

            m_WindowsAPI = new WindowsAPI();
            m_RegexService = new RegexService();

            LoginMethod = LoginMethods.Password;
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!JudgeInput())
            {
                return;
            }

            User user = null;
            //判断输入的账号类型
            if (m_RegexService.IsMail(tbAccount.Text.Trim()))
            {
                //邮箱登录
                user = await AuthClient.Instance.LoginByEmail(tbAccount.Text.Trim(), tbPassword.Password, new RegisterAndLoginOptions { AutoRegister = false });
            }
            else if (m_RegexService.IsPhone(tbAccount.Text.Trim()))
            {
                //手机登录
                user = await AuthClient.Instance.LoginByPhonePassword(tbAccount.Text.Trim(), tbPassword.Password, new RegisterAndLoginOptions { AutoRegister = false });
            }
            else
            {
                //用户名登录
                user = await AuthClient.Instance.LoginByUsername(tbAccount.Text.Trim(), tbPassword.Password, new RegisterAndLoginOptions { AutoRegister = false });
            }

            if (user != null)
            {
                //登录成功
            }
        }

        private bool JudgeInput()
        {
            bool flag = true;

            if (string.IsNullOrWhiteSpace(tbAccount.Text))
            {
                tbAccount.Warn = true;
                tbAccountRemind.Visibility = Visibility.Visible;
                BeginStoryboard(tbAccount);
                flag = false;
            }
            if (string.IsNullOrWhiteSpace(tbPassword.Password))
            {
                PasswordBoxHelper.SetWarn(tbPassword, true);
                tbPasswordRemind.Visibility = Visibility.Visible;
                BeginStoryboard(tbPassword);
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

        private void tbAccount_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbAccount.Warn = false;
            tbAccountRemind.Visibility = Visibility.Collapsed;
        }
        private void tbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBoxHelper.SetWarn(tbPassword, false);
            tbPasswordRemind.Visibility = Visibility.Collapsed;
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
    }
}

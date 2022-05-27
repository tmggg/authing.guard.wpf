using Authing.ApiClient.Domain.Model;
using Authing.Guard.WPF.Factories;
using Authing.Guard.WPF.Infrastructures;
using Authing.Guard.WPF.Utils;
using Authing.Guard.WPF.Utils.Impl;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Authing.Guard.WPF.Views.LoginView
{
    /// <summary>
    /// ResetPasswordView.xaml 的交互逻辑
    /// </summary>
    public partial class ResetPasswordView : UserControl
    {
        private IRegexService m_RegexService;

        public ResetPasswordView()
        {
            InitializeComponent();
            m_RegexService = new RegexService();
        }

        private async void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            JudgeInput();

            CommonMessage commonMessage = null;

            if (m_RegexService.IsMail(tbAccount.Text))
            {
                commonMessage = await AuthClient.Instance.ResetPasswordByEmailCode(tbAccount.Text, tbCode.Text, tbPassword.Password);
            }
            else if (m_RegexService.IsPhone(tbAccount.Text))
            {
                commonMessage = await AuthClient.Instance.ResetPasswordByPhoneCode(tbAccount.Text, tbCode.Text, tbPassword.Password);
            }

            if (commonMessage != null)
            {
                if (commonMessage.Code.Value == 200)
                {
                }
                else
                {
                }
            }
        }

        private async void btnSendCode_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbAccount.Text))
            {
                tbAccount.Warn = true;
                tbAccountRemind.Text = "手机号 / 邮箱未填写";
                tbAccountRemind.Visibility = Visibility.Visible;
                return;
            }

            if (!m_RegexService.IsPhone(tbAccount.Text) || !m_RegexService.IsMail(tbAccount.Text))
            {
                tbAccount.Warn = true;
                tbAccountRemind.Text = "请输入正确的手机号或邮箱";
                tbAccountRemind.Visibility = Visibility.Visible;
                return;
            }

            CommonMessage commonMessage = null;

            if (m_RegexService.IsPhone(tbAccount.Text))
            {
                commonMessage = await AuthClient.Instance.SendSmsCode(tbAccount.Text);
            }
            else if (m_RegexService.IsMail(tbAccount.Text))
            {
                commonMessage = await AuthClient.Instance.SendSmsCode(tbAccount.Text);
            }

            if (commonMessage.Code.Value != 200)
            {
                throw new Exception(commonMessage.Message);
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
            if (string.IsNullOrWhiteSpace(tbCode.Text))
            {
                tbCode.Warn = true;
                tbCodeRemind.Visibility = Visibility.Visible;
                BeginStoryboard(tbPassword);
                flag = false;
            }
            if (string.IsNullOrWhiteSpace(tbPassword.Password))
            {
                PasswordBoxHelper.SetWarn(tbPassword, true);
                tbPasswordRemind.Visibility = Visibility.Visible;
                BeginStoryboard(tbPassword);
                flag = false;
            }
            else
            {
                //判断密码有效性
                if (!m_RegexService.PasswordMatch(tbPassword.Password))
                {
                    PasswordBoxHelper.SetWarn(tbPassword, true);
                    tbPasswordRemind.Text = "密码长度至少为 6 位，且要包含英文、数字与符号中的两种";
                    tbPasswordRemind.Visibility = Visibility.Visible;
                    BeginStoryboard(tbPassword);
                    flag = false;
                }
            }

            return flag;
        }

        private void BeginStoryboard<T>(T control) where T : Control
        {
            Storyboard storyboard = (Storyboard)control.Resources["ShakeStoryboard"];
            Storyboard.SetTarget(storyboard.Children.ElementAt(0) as DoubleAnimationUsingKeyFrames, control);
            storyboard.Begin();
        }

        private void tbCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbCode.Warn = false;
            tbCodeRemind.Visibility = Visibility.Collapsed;
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
    }
}
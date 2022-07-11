using Authing.Guard.WPF.Events;
using Authing.Guard.WPF.Events.EventAggreator;
using Authing.Guard.WPF.Infrastructures;
using Authing.Guard.WPF.Utils;
using Authing.Guard.WPF.Utils.Impl;
using Authing.Library.Domain.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// ResetPasswordV1View.xaml 的交互逻辑
    /// </summary>
    public partial class ResetPasswordV1View : UserControl
    {
        private string account;//当前输入的账号

        private string emailAccount;
        private string phoneAccount;

        private AccountType accountType;

        private IRegexService regexService;

        public ResetPasswordV1View()
        {
            InitializeComponent();

            regexService = new RegexService();
        }

        private void btnResetPwd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbAccount.Text))
            {
                tbAccount.Warn = true;
                tbRemind.Visibility = Visibility.Visible;
                tbRemind.Text = ResourceHelper.GetResource<string>("Cannotbeempty");

                return;
            }

            account = tbAccount.Text;

            if (regexService.IsMail(account))
            {
                accountType = AccountType.Email;
                emailAccount = tbAccount.Text;

                //发送邮箱验证码，并且跳转界面
                gridEmail.Visibility = Visibility.Visible;
                tbEmail.Text = account;
                tbEmail.Text = $"重置密码邮件已发送至邮箱 {emailAccount} ，有效期为 5 分钟";

                btnResendEmailCode_Click(null, null);
            }
            else
            {
                accountType = AccountType.Phone;
                phoneAccount = tbAccount.Text;

                //跳转界面
                gridPhone.Visibility = Visibility.Visible;
                tbPhone.Text = phoneAccount;
                tbPhonePwd.Clear();
                tbPhonePwdAgain.Clear();
            }
        }

        private async void btnResetEmailPwd_Click(object sender, RoutedEventArgs e)
        {
            bool canReset = true;

            if (string.IsNullOrWhiteSpace(tbVerifyCode.Text))
            {
                canReset = false;
                tbVerifyCode.Warn = true;
                tbVerifyCodeRemind.Visibility = Visibility.Visible;
                tbVerifyCodeRemind.Text = ResourceHelper.GetResource<string>("Cannotbeempty");
            }
            if (string.IsNullOrWhiteSpace(tbPwd.Password))
            {
                canReset = false;
                PasswordBoxHelper.SetWarn(tbPwd, true);
                tbPwdRemind.Visibility = Visibility.Visible;
                tbPwdRemind.Text = ResourceHelper.GetResource<string>("PwdCannotbeempty");
            }
            if (string.IsNullOrWhiteSpace(tbPwdAgain.Password))
            {
                canReset = false;
                PasswordBoxHelper.SetWarn(tbPwdAgain, true);
                tbPwdAgainRemind.Visibility = Visibility.Visible;
                tbPwdAgainRemind.Text = ResourceHelper.GetResource<string>("Cannotbeempty");
                tbPwdAgainSameRemind.Visibility = Visibility.Visible;
                tbPwdAgainSameRemind.Text = ResourceHelper.GetResource<string>("Pwdneedsame");
            }
            else if (tbPwdAgain.Password != tbPwd.Password)
            {
                canReset = false;
                PasswordBoxHelper.SetWarn(tbPwdAgain, true);
                tbPwdAgainSameRemind.Visibility = Visibility.Visible;
                tbPwdAgainSameRemind.Text = ResourceHelper.GetResource<string>("Pwdneedsame");
            }

            if (canReset)
            {
                AuthingErrorBox authingErrorBox = new AuthingErrorBox();

                var commonMessage = await Factories.AuthClient.Instance.ResetPasswordByEmailCode(emailAccount, tbVerifyCode.Text, tbPwd.Password, authingErrorBox);
                if (commonMessage != null)
                {
                    if (commonMessage.Code == 200)
                    {
                        LoginSuccessed();
                    }
                    else
                    {
                        EventManagement.Instance.Dispatch((int)EventId.PwdResetError, EventArgs<string>.CreateEventArgs(authingErrorBox.Value.First().Message.Message));
                    }
                }
            }
        }

        private async void btnResendEmailCode_Click(object sender, RoutedEventArgs e)
        {
            AuthingErrorBox authingErrorBox = new AuthingErrorBox();

            var commonMessage = await Factories.AuthClient.Instance.SendEmail(emailAccount, ApiClient.Types.EmailScene.RESET_PASSWORD, authingErrorBox);
            if (commonMessage != null)
            {
                if (commonMessage.Code == 200)
                {
                    EventManagement.Instance.Dispatch((int)EventId.PwdEmailSend);
                }
                else
                {
                    EventManagement.Instance.Dispatch((int)EventId.PwdEmailSendError, EventArgs<string>.CreateEventArgs(authingErrorBox.Value.First().Message.Message));
                }
            }
            else
            {
                if (authingErrorBox.Value != null && authingErrorBox.Value.Count() > 0)
                {
                    EventManagement.Instance.Dispatch((int)EventId.PwdEmailSendError, EventArgs<string>.CreateEventArgs(authingErrorBox.Value.First().Message.Message));
                }
                else
                {
                    EventManagement.Instance.Dispatch((int)EventId.PwdEmailSendError, EventArgs<string>.CreateEventArgs("未知原因，请联系 Authing 管理员"));
                }
            }
        }

        private async void btnResetPhonePwd_Click(object sender, RoutedEventArgs e)
        {
            bool canReset = true;

            if (string.IsNullOrWhiteSpace(tbPhoneVerifyCode.Text))
            {
                canReset = false;
                tbVerifyCode.Warn = false;
                tbVerifyCodeRemind.Visibility = Visibility.Visible;
                tbVerifyCodeRemind.Text = ResourceHelper.GetResource<string>("Cannotbeempty");
            }
            if (string.IsNullOrWhiteSpace(tbPhonePwd.Password))
            {
                canReset = false;
                PasswordBoxHelper.SetWarn(tbPhonePwd, true);
                tbPhonePwdRemind.Visibility = Visibility.Visible;
                tbPhonePwdRemind.Text = ResourceHelper.GetResource<string>("Cannotbeempty");
            }
            if (string.IsNullOrWhiteSpace(tbPhonePwdAgain.Password))
            {
                canReset = false;
                PasswordBoxHelper.SetWarn(tbPhonePwdAgain, true);
                tbPhonePwdAgainRemind.Visibility = Visibility.Visible;
                tbPhonePwdAgainRemind.Text = ResourceHelper.GetResource<string>("Cannotbeempty");
                tbPhonePwdAgainSameRemind.Visibility = Visibility.Visible;
                tbPhonePwdAgainSameRemind.Text = ResourceHelper.GetResource<string>("Pwdneedsame");
            }


            if (canReset)
            {
                AuthingErrorBox authingErrorBox = new AuthingErrorBox();
                var commonMessage = await Factories.AuthClient.Instance.ResetPasswordByPhoneCode(phoneAccount, tbPhoneVerifyCode.Text, tbPhonePwd.Password, authingErrorBox);

                if (commonMessage != null)
                {
                    if (commonMessage.Code == 200)
                    {
                        LoginSuccessed();
                    }
                    else
                    {
                        EventManagement.Instance.Dispatch((int)EventId.PwdResetError, EventArgs<string>.CreateEventArgs(authingErrorBox.Value.First().Message.Message));
                    }
                }
                else
                {
                    if (authingErrorBox.Value != null && authingErrorBox.Value.Count() > 0)
                    {
                        EventManagement.Instance.Dispatch((int)EventId.PwdResetError, EventArgs<string>.CreateEventArgs(authingErrorBox.Value.First().Message.Message));
                    }
                    else
                    {
                        EventManagement.Instance.Dispatch((int)EventId.PwdResetError, EventArgs<string>.CreateEventArgs("未知原因，请联系 Authing 管理员"));
                    }
                }
            }
        }

        private async void btnSendSMS_OnClick(object sender, RoutedEventArgs e)
        {
            AuthingErrorBox authingErrorBox = new AuthingErrorBox();

            var commonMessage = await Factories.AuthClient.Instance.SendSmsCode(tbPhone.Text, authingErrorBox);
            if (commonMessage != null)
            {
                if (commonMessage.Code == 200)
                {
                    EventManagement.Instance.Dispatch((int)EventId.PwdPhoneSend);
                }
                else
                {
                    EventManagement.Instance.Dispatch((int)EventId.PwdPhoneSendError, EventArgs<string>.CreateEventArgs(authingErrorBox.Value.First().Message.Message));
                }
            }
            else
            {
                if (authingErrorBox.Value != null && authingErrorBox.Value.Count() > 0)
                {
                    EventManagement.Instance.Dispatch((int)EventId.PwdPhoneSendError, EventArgs<string>.CreateEventArgs(authingErrorBox.Value.First().Message.Message));
                }
                else
                {
                    EventManagement.Instance.Dispatch((int)EventId.PwdPhoneSendError, EventArgs<string>.CreateEventArgs("未知原因，请联系 Authing 管理员"));
                }
            }
        }

        private void tbPwd_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void tbPwdAgain_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void LoginSuccessed()
        {
            gridSuccess.Visibility = Visibility.Visible;

            Task.Factory.StartNew(() => 
            {
                for (int i = 3; i > 0; i--)
                {
                    Thread.Sleep(1000);

                    Dispatcher.BeginInvoke(new Action(() => 
                    {
                        tbSuccess.Text = $"{i}s 后自动跳转登录";   
                    }));
                }

                EventManagement.Instance.Dispatch((int)EventId.PwdReset);

                Dispatcher.BeginInvoke(new Action(() => 
                {
                    gridSuccess.Visibility = Visibility.Collapsed;
                    gridEmail.Visibility = Visibility.Collapsed;
                    gridPhone.Visibility = Visibility.Collapsed;
                }));
            });
        }
    }

    /// <summary>
    /// 重置密码的账号类型
    /// </summary>
    public enum AccountType
    {
        Email,
        Phone
    }
}

using Authing.ApiClient.Domain.Model;
using Authing.ApiClient.Types;
using Authing.Guard.WPF.Controls;
using Authing.Guard.WPF.Enums;
using Authing.Guard.WPF.Events;
using Authing.Guard.WPF.Events.EventAggreator;
using Authing.Guard.WPF.Factories;
using Authing.Guard.WPF.Infrastructures;
using Authing.Guard.WPF.Services;
using Authing.Guard.WPF.Utils;
using Authing.Guard.WPF.Utils.Impl;
using Authing.Library.Domain.Model.Exceptions;
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
    public partial class SMSCodeLoginView : BaseLoginControl, IEventListener
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

            EventManagement.Instance.AddListener((int)EventId.SMSCodeLoginLoginLoginAgreementCheckFinish, this);
        }

        private void SMSCodeLoginView_Loaded(object sender, RoutedEventArgs e)
        {
            tbPhone.Warn = false;
            tbSMSCode.Warn = false;
            tbPhoneRemind.Visibility = Visibility.Collapsed;
        }

        private async void btnSendSMS_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                tbPhoneRemind.Text = Application.Current.Resources["PhoneCodeAccountError"] as string;
                tbPhone.Warn = true;
                tbPhoneRemind.Visibility = Visibility.Visible;

                return;
            }

            if (!m_RegexService.IsPhone(tbPhone.Text))
            {
                tbPhoneRemind.Text = Application.Current.Resources["PhoneCodeAccountValid"] as string;
                tbPhone.Warn = true;
                tbPhoneRemind.Visibility = Visibility.Visible;

                return;
            }

            btnSendSMS.IsBusy = btnSendSMS.IsBusy != true;
            await TaskExHelper.Delay(btnSendSMS.Count);
            btnSendSMS.IsBusy = btnSendSMS.IsBusy != true;
            btnSendSMS.StartCountDown = true;

            CommonMessage commonMessage = await AuthClient.Instance.SendSmsCode(tbPhone.Text);

            if (commonMessage.Code.Value != 200)
            {
                throw new Exception(commonMessage.Message);
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!JudgeInput())
            {
                return;
            }

            EventManagement.Instance.Dispatch((int)EventId.SMSCodeLoginLoginAgreementCheck);
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

            return flag;
        }

        private void BeginStoryboard<T>(T control) where T : Control
        {
            Storyboard storyboard = (Storyboard)control.Resources["ShakeStoryboard"];
            Storyboard.SetTarget(storyboard.Children.ElementAt(0) as DoubleAnimationUsingKeyFrames, control);
            storyboard.Begin();
        }


        private void tbSMSCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbSMSCode.Warn = false;
            tbPhoneRemind.Visibility = Visibility.Collapsed;
        }

        private void tbPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbPhone.Warn = false;
            tbPhoneRemind.Visibility = Visibility.Collapsed;
        }

        public void HandleEvent(int eventId, IEventArgs args)
        {
            switch (eventId)
            {
                case (int)EventId.LanguageChanged: break;
                case (int)EventId.SMSCodeLoginLoginLoginAgreementCheckFinish: Login(args.GetValue<bool>()); break;
                default: break;
            }
        }

        private async void Login(bool allChecked)
        {
            if (!allChecked)
            {
                return;
            }

            User user = null;
            AuthingErrorBox authingErrorBox = new AuthingErrorBox();
            try
            {
                user = await AuthClient.Instance.LoginByPhoneCode(tbPhone.Text, tbSMSCode.Text, new RegisterAndLoginOptions { AutoRegister = false, ForceLogin = true },authingErrorBox);

                if (user != null)
                {
                    PrimaryMessageBoxService.Show(ResourceHelper.GetResource<string>("loginSuccessWelcome") + user.Username, IconType.Success);

                    EventManagement.Instance.Dispatch((int)EventId.Login, EventArgs<User>.CreateEventArgs(user));
                }
                else
                {
                    PrimaryMessageBoxService.Show(authingErrorBox.Value.First().Message.Message, IconType.Error);
                }
            }
            catch (Exception exp)
            {
                PrimaryMessageBoxService.Show(exp.Message, IconType.Error);

                EventManagement.Instance.Dispatch((int)EventId.LoginError, EventArgs<string>.CreateEventArgs(exp.Message));
            }
        }
    }
}
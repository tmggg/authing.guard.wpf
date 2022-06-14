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
using Authing.ApiClient.Domain.Model;
using Authing.ApiClient.Domain.Model.Authentication;
using Authing.ApiClient.Extensions;
using Authing.Guard.WPF.Enums;
using Authing.Guard.WPF.Events;
using Authing.Guard.WPF.Events.EventAggreator;
using Authing.Guard.WPF.Factories;
using Authing.Guard.WPF.Infrastructures;
using Authing.Guard.WPF.Utils;
using Authing.Guard.WPF.Utils.Extensions;
using Authing.Guard.WPF.Utils.Impl;

namespace Authing.Guard.WPF.Views.RegisterView
{
    /// <summary>
    /// PhoneReg.xaml 的交互逻辑
    /// </summary>
    public partial class PhoneReg : UserControl
    {
        private IWindowsAPI m_WindowsAPI;

        public PhoneReg()
        {
            InitializeComponent();
            m_WindowsAPI = new WindowsAPI();
        }

        private void PhoneNumber_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            PhoneNumber.Warn = false;
            PhoneNumberRemind.Visibility = Visibility.Collapsed;
        }

        private async void SendCodeBtn_OnClick(object sender, RoutedEventArgs e)
        {
            SendCodeBtn.IsBusy = SendCodeBtn.IsBusy != true;
            try
            {
                await AuthClient.Instance.SendSmsCode(PhoneNumber.Text);
            }
            catch (Exception exception)
            {
                EventManagement.Instance.Dispatch((int)EventId.RegisterError,
                    EventArgs<string>.CreateEventArgs(exception.Message));
            }
            finally
            {
                await TaskExHelper.Delay(SendCodeBtn.Count);
            }
            SendCodeBtn.IsBusy = SendCodeBtn.IsBusy != true;
            SendCodeBtn.StartCountDown = true;
        }

        private void ChallengeCode_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ChallengeCode.Warn = false;
            ChallengeCodeRemind.Visibility = Visibility.Collapsed;
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
            m_WindowsAPI.ShellExecute("open", @"https://www.authing.cn/service-agreement.html");
        }

        private void linkPrivacy_Click(object sender, RoutedEventArgs e)
        {
            m_WindowsAPI.ShellExecute("open", @"https://www.authing.cn/privacy-policy.html");
        }

        private async void BtnRegister_OnClick(object sender, RoutedEventArgs e)
        {
            if (!JudgeInput()) return;
            User user = null;
            try
            {
                //user = await AuthClient.Instance.RegisterByPhoneCode(PhoneNumber.Text, ChallengeCode.Text, "", null, true);
                user = await AuthClient.Instance.RegisterByPhoneCode(PhoneNumber.Text, ChallengeCode.Text, null, null, true);
            }
            catch (Exception exception)
            {
                EventManagement.Instance.Dispatch((int)EventId.RegisterError,
                    EventArgs<string>.CreateEventArgs(exception.Message));
            }
            if (user != null)
            {
                EventManagement.Instance.Dispatch((int)EventId.Register,
                    EventArgs<User>.CreateEventArgs(user));
            }
        }

        private bool JudgeInput()
        {
            ValidationResult res = null;
            bool flag = true;

            res = PhoneNumber.Text.ValidationData(ValidationType.Phone);
            if (!res.IsValid)
            {
                PhoneNumberRemind.Text = res.ErrorContent.ToString();
                PhoneNumber.Warn = true;
                PhoneNumberRemind.Visibility = Visibility.Visible;
                BeginStoryboard(PhoneNumber);
                flag = false;
            }

            res = ChallengeCode.Text.ValidationData();
            if (!res.IsValid)
            {
                ChallengeCodeRemind.Text = res.ErrorContent.ToString();
                ChallengeCode.Warn = true;
                ChallengeCodeRemind.Visibility = Visibility.Visible;
                BeginStoryboard(ChallengeCode);
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
            Storyboard.SetTarget(storyboard.Children.ElementAt(0) as DoubleAnimationUsingKeyFrames ?? throw new InvalidOperationException(), control);
            storyboard.Begin();
        }
    }
}
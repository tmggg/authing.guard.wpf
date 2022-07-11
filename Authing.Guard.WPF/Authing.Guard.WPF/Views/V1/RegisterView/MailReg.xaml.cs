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
    /// MailReg.xaml 的交互逻辑
    /// </summary>
    public partial class MailReg : UserControl
    {
        private IWindowsAPI m_WindowsAPI;

        public MailReg()
        {
            InitializeComponent();
            m_WindowsAPI = new WindowsAPI();
        }

        private void MailBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            MailBox.Warn = false;
            MailBoxRemind.Visibility = Visibility.Collapsed;
        }

        private void FPasswod_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBoxHelper.SetWarn(FPasswod, false);
            FPasswodRemind.Visibility = Visibility.Collapsed;
        }

        private void SPasswod_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBoxHelper.SetWarn(SPasswod, false);
            SPasswodRemind.Visibility = Visibility.Collapsed;
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
            User user = null;
            if (!JudgeInput()) return;
            try
            {
                user = await AuthClient.Instance.RegisterByEmail(MailBox.Text, FPasswod.Password, null, null);
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

            res = MailBox.Text.ValidationData(ValidationType.Email);
            if (!res.IsValid)
            {
                MailBoxRemind.Text = res.ErrorContent.ToString();
                MailBox.Warn = true;
                MailBoxRemind.Visibility = Visibility.Visible;
                BeginStoryboard(MailBox);
                flag = false;
            }
            res = FPasswod.Password.ValidationData();
            if (!res.IsValid)
            {
                FPasswodRemind.Text = res.ErrorContent.ToString();
                PasswordBoxHelper.SetWarn(FPasswod, true);
                FPasswodRemind.Visibility = Visibility.Visible;
                BeginStoryboard(FPasswod);
                flag = false;
            }
            res = SPasswod.Password.ValidationData();
            if (!res.IsValid)
            {
                SPasswodRemind.Text = res.ErrorContent.ToString();
                PasswordBoxHelper.SetWarn(SPasswod, true);
                SPasswodRemind.Visibility = Visibility.Visible;
                BeginStoryboard(SPasswod);
                flag = false;
            }

            if (!FPasswod.Password.CompareWith(SPasswod.Password))
            {
                PasswordBoxHelper.SetWarn(SPasswod, true);
                SPasswodRemind.Visibility = Visibility.Visible;
                SPasswodRemind.Text = ResourceHelper.GetResource<string>("PassWordNotSame");
                BeginStoryboard(SPasswod);
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
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
using Authing.ApiClient.Types;
using Authing.Guard.WPF.Controls;
using Authing.Guard.WPF.Enums;
using Authing.Guard.WPF.Events;
using Authing.Guard.WPF.Events.EventAggreator;
using Authing.Guard.WPF.Factories;
using Authing.Guard.WPF.Infrastructures;
using Authing.Guard.WPF.Models;
using Authing.Guard.WPF.Services;
using Authing.Guard.WPF.Utils;
using Authing.Guard.WPF.Utils.Extensions;
using Authing.Guard.WPF.Utils.Impl;

namespace Authing.Guard.WPF.Views.LoginView
{
    /// <summary>
    /// LoginByAD.xaml 的交互逻辑
    /// </summary>
    public partial class LoginByAD : BaseLoginControl
    {
        private IWindowsAPI m_WindowsAPI;
        private IRegexService m_RegexService;

        public LoginByAD()
        {
            InitializeComponent();
            m_WindowsAPI = new WindowsAPI();
            m_RegexService = new RegexService();
            LoginMethod = LoginMethods.AD;
        }

        private async void ADLoginButton_Click(object sender, RoutedEventArgs e)
        {
            User user = null;
            if (!JudgeInput()) return;
            try
            {
                user = await AuthClient.Instance.LoginByAd(AdName.Text, AdPassword.Password);
            }
            catch (Exception ex)
            {
                EventManagement.Instance.Dispatch((int)EventId.LoginError,
                    EventArgs<string>.CreateEventArgs(ex.Message));
            }
            if (user != null)
            {
                if (ConfigService.ExtendConfig.ComplatePlaces.Any(l => l == ComplatePlace.login))
                {
                    UserWithEvent param = new UserWithEvent();
                    param.User = user;
                    param.EventFrom = EventId.Login;
                    EventManagement.Instance.Dispatch((int)EventId.ToUserInfoReplenish,
                        EventArgs<UserWithEvent>.CreateEventArgs(param));
                    return;
                }
                EventManagement.Instance.Dispatch((int)EventId.Login,
                    EventArgs<User>.CreateEventArgs(user));
            }
        }

        private bool JudgeInput()
        {
            ValidationResult res = null;
            bool flag = true;

            res = AdName.Text.ValidationData();
            if (!res.IsValid)
            {
                AdName.Warn = true;
                AdNameRemind.Visibility = Visibility.Visible;
                BeginStoryboard(AdName);
                flag = false;
            }

            res = AdPassword.Password.ValidationData();
            if (!res.IsValid)
            {
                PasswordBoxHelper.SetWarn(AdPassword, true);
                AdPasswordRemind.Visibility = Visibility.Visible;
                BeginStoryboard(AdPassword);
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

        private void AdName_TextChanged(object sender, TextChangedEventArgs e)
        {
            AdName.Warn = false;
            AdNameRemind.Visibility = Visibility.Collapsed;
        }

        private void AdPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBoxHelper.SetWarn(AdPassword, false);
            AdPasswordRemind.Visibility = Visibility.Collapsed;
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
    }
}

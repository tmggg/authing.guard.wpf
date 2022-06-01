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
using Authing.Guard.WPF.Infrastructures;
using Authing.Guard.WPF.Utils;
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
            await TaskExHelper.Delay(2000);
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

        private void BtnRegister_OnClick(object sender, RoutedEventArgs e)
        {
            JudgeInput();
        }

        private bool JudgeInput()
        {
            bool flag = true;

            if (string.IsNullOrWhiteSpace(PhoneNumber.Text))
            {
                PhoneNumber.Warn = true;
                PhoneNumberRemind.Visibility = Visibility.Visible;
                BeginStoryboard(PhoneNumber);
                flag = false;
            }
            if (string.IsNullOrWhiteSpace(ChallengeCode.Text))
            {
                //PasswordBoxHelper.SetWarn(ChallengeCode, true);
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

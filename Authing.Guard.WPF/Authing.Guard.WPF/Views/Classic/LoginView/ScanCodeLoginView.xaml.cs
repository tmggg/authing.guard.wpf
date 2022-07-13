using Authing.Guard.WPF.Commons;
using Authing.Guard.WPF.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Authing.Guard.WPF.Views.LoginView
{
    /// <summary>
    /// ScanCodeLoginView.xaml 的交互逻辑
    /// </summary>
    public partial class ScanCodeLoginView : UserControl
    {

        public ScanCodeLoginView()
        {
            InitializeComponent();
            InitDemoData();
            InitBinding();
        }

        private void InitDemoData()
        {
            QrCodeControl.QrCode = new BitmapImage(new Uri("pack://application:,,,/Authing.Guard.WPF;component/Commons/Images/qrcode.png"));
            QrCodeControl.IsExpired = true;
            //Messenger.Default.Register();
        }

        private void InitBinding()
        {
            CommandBindings.Add(new CommandBinding(AuthingGuardCommands.RefreshQrCodeCommand, Executed));
        }

        private void Executed(object sender, ExecutedRoutedEventArgs e)
        {
            QrCodeControl.QrCode = QrCodeControl.QrCode.ToString().Contains("2") ? new BitmapImage(new Uri("pack://application:,,,/Authing.Guard.WPF;component/Commons/Images/qrcode.png")) :
                new BitmapImage(new Uri("pack://application:,,,/Authing.Guard.WPF;component/Commons/Images/qrcode2.png"));
            QrCodeControl.IsExpired = false;
        }
    }
}
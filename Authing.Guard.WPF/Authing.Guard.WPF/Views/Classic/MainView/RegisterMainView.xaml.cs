using Authing.Guard.WPF.Events;
using Authing.Guard.WPF.Events.EventAggreator;
using Authing.Guard.WPF.Models;
using Authing.Guard.WPF.Utils;
using Authing.Guard.WPF.Utils.Impl;
using Authing.Guard.WPF.Views.LoginView;
using Authing.Guard.WPF.Views.RegisterView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

namespace Authing.Guard.WPF.Views.Classic.MainView
{
    /// <summary>
    /// RegisterMainView.xaml 的交互逻辑
    /// </summary>
    public partial class RegisterMainView : UserControl
    {
        private readonly GuardConfig config;

        private IImageService m_ImageService;

        public RegisterMainView(GuardConfig guardConfig)
        {
            InitializeComponent();

            config = guardConfig;
            m_ImageService = new ImageService();
            Loaded += RegisterMainView_Loaded;
        }


        private void RegisterMainView_Loaded(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(config.Logo))
            {
                byte[] byteArray = m_ImageService.GetImageFromResponse(config.Logo);

                MemoryStream ms = new MemoryStream(byteArray);

                imgLogo.Source = BitmapFrame.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.Default);
            }

            tbTitle.Text = config.Title;

            TabItem tabItem;
            foreach (var item in config.RegisterMethods)
            {
                if (item == Enums.RegisterMethods.Email)
                {
                    tabItem = new TabItem();
                    tabItem.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                    tabItem.SetResourceReference(HeaderedContentControl.HeaderProperty, "RegByPhone");
                    tabItem.Content = new PhoneReg();
                    RegMainTabControl.Items.Add(tabItem);
                }
                else if (item == Enums.RegisterMethods.Phone)
                {
                    tabItem = new TabItem();
                    tabItem.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                    tabItem.SetResourceReference(HeaderedContentControl.HeaderProperty, "RegByMail");
                    tabItem.Content = new MailReg();
                    RegMainTabControl.Items.Add(tabItem);
                }
                else if (item == Enums.RegisterMethods.EmailCode)
                {
                    tabItem = new TabItem();
                    tabItem.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                    tabItem.SetResourceReference(HeaderedContentControl.HeaderProperty, "RegByMail");
                    tabItem.Content = new UserInfoReplenishView();
                    RegMainTabControl.Items.Add(tabItem);
                }

            }
        }

        private void RegReturn2Login_OnClick(object sender, RoutedEventArgs e)
        {
            EventManagement.Instance.Dispatch((int)EventId.ToLogin);
        }
    }
}

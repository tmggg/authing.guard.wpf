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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Authing.Guard.WPF.Views.LoginView;

namespace Authing.Guard.WPF.Views.RegisterView
{
    /// <summary>
    /// RegMain.xaml 的交互逻辑
    /// </summary>
    public partial class RegMain : UserControl
    {
        public RegMain()
        {
            InitializeComponent();
            TabItem tabItem = new TabItem();
            tabItem.HorizontalContentAlignment = HorizontalAlignment.Stretch;
            tabItem.SetResourceReference(HeaderedContentControl.HeaderProperty, "RegByPhone");
            tabItem.Content = new PhoneReg();
            RegMainTabControl.Items.Add(tabItem);
            tabItem = new TabItem();
            tabItem.HorizontalContentAlignment = HorizontalAlignment.Stretch;
            tabItem.SetResourceReference(HeaderedContentControl.HeaderProperty, "RegByMail");
            tabItem.Content = new MailReg();
            RegMainTabControl.Items.Add(tabItem);
            tabItem = new TabItem();
            tabItem.HorizontalContentAlignment = HorizontalAlignment.Stretch;
            tabItem.VerticalContentAlignment = VerticalAlignment.Stretch;
            tabItem.SetResourceReference(HeaderedContentControl.HeaderProperty, "RegByMail");
            tabItem.Content = new UserInfoReplenishView();
            RegMainTabControl.Items.Add(tabItem);
        }
    }
}
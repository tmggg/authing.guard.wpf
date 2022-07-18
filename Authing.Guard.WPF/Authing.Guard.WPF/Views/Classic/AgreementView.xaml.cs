using Authing.Guard.WPF.Enums;
using Authing.Guard.WPF.Events;
using Authing.Guard.WPF.Events.EventAggreator;
using Authing.Guard.WPF.Models;
using Authing.Guard.WPF.Services;
using Authing.Guard.WPF.Utils;
using Authing.Guard.WPF.Utils.Impl;
using Authing.Guard.WPF.Views.Classic.MainView;
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

namespace Authing.Guard.WPF.Views.Classic
{
    /// <summary>
    /// AgreementView.xaml 的交互逻辑
    /// </summary>
    public partial class AgreementView : UserControl, IEventListener
    {
        public GuardScenes GuardScene
        {
            get
            {
                return (GuardScenes)GetValue(GuardSceneProperty);
            }
            set
            {
                SetValue(GuardSceneProperty, value);
            }
        }

        public static DependencyProperty GuardSceneProperty =
            DependencyProperty.Register(nameof(GuardScene), typeof(GuardScenes), typeof(AgreementView), new PropertyMetadata());

        private List<Agreement> agreements;

        private List<Agreement> allAgreements;

        private IJsonService m_JsonService;

        public AgreementView()
        {
            m_JsonService = new JsonService();

            InitializeComponent();

            Loaded += AgreementView_Loaded;
        }

        public void HandleEvent(int eventId, IEventArgs args)
        {
            switch (eventId)
            {
                case (int)EventId.LoginAgreementCheck: AgreementCheck(); break;

                case (int)EventId.RegisterAgreementCheck: AgreementCheck(); break;
            }
        }

        private void AgreementView_Loaded(object sender, RoutedEventArgs e)
        {
            allAgreements = m_JsonService.Deserialize<List<Agreement>>(m_JsonService.Serialize(GuardMainView.Agreements));

            agreements = new List<Agreement>();

            if (GuardMainView.Agreements == null || GuardMainView.Agreements.Count == 0)
            {
                this.Visibility = Visibility.Collapsed;
                return;
            }

            if (GuardScene == GuardScenes.Login)
            {
                EventManagement.Instance.AddListener((int)EventId.LoginAgreementCheck, this);

                agreements = allAgreements.Where(p => p.AvailableAt == AvailableAt.Login || p.AvailableAt == AvailableAt.RegisterAndLogin).ToList();
            }
            else if (GuardScene == GuardScenes.Register)
            {
                EventManagement.Instance.AddListener((int)EventId.RegisterAgreementCheck, this);

                agreements = allAgreements.Where(p => p.AvailableAt == AvailableAt.Register || p.AvailableAt == AvailableAt.RegisterAndLogin).ToList();
            }

            if (agreements.Count > 0)
            {
                listBox.ItemsSource = agreements;
                Visibility = Visibility.Visible;
            }
            else
            {
                Visibility = Visibility.Collapsed;
            }
        }

        private void AgreementCheck()
        {
            int needCheck = agreements.Count(p=>p.Required);

            foreach (var item in agreements)
            {
                if (item.Required && item.IsChecked)
                {
                    needCheck--;
                }
                else if (item.Required && !item.IsChecked)
                {
                    item.Warn = true;
                }
            }


            if (GuardScene == GuardScenes.Login)
            {
                if (needCheck != 0)
                {
                    PrimaryMessageBoxService.Show("请勾选登录协议", IconType.Error);
                }

                EventManagement.Instance.Dispatch((int)EventId.LoginAgreementCheckFinish, EventArgs<bool>.CreateEventArgs(needCheck == 0));
            }
            else if (GuardScene == GuardScenes.Register)
            {
                if (needCheck != 0)
                {
                    PrimaryMessageBoxService.Show("请勾选注册协议", IconType.Error);
                }

                EventManagement.Instance.Dispatch((int)EventId.LoginAgreementCheckFinish, EventArgs<bool>.CreateEventArgs(needCheck == 0));
            }
        }

    }
}

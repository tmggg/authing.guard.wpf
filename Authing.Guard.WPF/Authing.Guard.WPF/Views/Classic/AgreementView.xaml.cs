using Authing.Guard.WPF.Enums;
using Authing.Guard.WPF.Events;
using Authing.Guard.WPF.Events.EventAggreator;
using Authing.Guard.WPF.Models;
using Authing.Guard.WPF.Services;
using Authing.Guard.WPF.Utils;
using Authing.Guard.WPF.Utils.Extensions;
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
        public GuardDetailScene GuardDetailScene
        {
            get
            {
                return (GuardDetailScene)GetValue(GuardDetailSceneProperty);
            }
            set
            {
                SetValue(GuardDetailSceneProperty, value);
            }
        }

        public static DependencyProperty GuardDetailSceneProperty =
            DependencyProperty.Register(nameof(GuardDetailScene), typeof(GuardDetailScene), typeof(AgreementView), new PropertyMetadata());

        private List<Agreement> agreements;

        private List<Agreement> allAgreements;

        private IJsonService m_JsonService;

        private Lang currentLang;

        public AgreementView()
        {
            m_JsonService = new JsonService();

            InitializeComponent();

            Loaded += AgreementView_Loaded;
            Unloaded += AgreementView_Unloaded;
        }

        private void AgreementView_Unloaded(object sender, RoutedEventArgs e)
        {
            if (GuardDetailScene == GuardDetailScene.PasswordLogin)
            {
                EventManagement.Instance.RemoveListener((int)EventId.PasswordLoginAgreementCheck, this);
            }
            else if (GuardDetailScene == GuardDetailScene.SMSCodeLogin)
            {
                EventManagement.Instance.RemoveListener((int)EventId.SMSCodeLoginLoginAgreementCheck, this);
            }
            else if (GuardDetailScene == GuardDetailScene.ScanCodeLogin)
            {
                EventManagement.Instance.AddListener((int)EventId.ScanCodeLoginLoginAgreementCheck, this);

            }
            else if (GuardDetailScene == GuardDetailScene.ADLogin)
            {
                EventManagement.Instance.RemoveListener((int)EventId.ADLoginLoginAgreementCheck, this);

            }
            else if (GuardDetailScene == GuardDetailScene.WeChatLogin)
            {
                EventManagement.Instance.RemoveListener((int)EventId.WeChatLoginLoginAgreementCheck, this);

            }
            else if (GuardDetailScene == GuardDetailScene.WeChatOfficalLogin)
            {
                EventManagement.Instance.RemoveListener((int)EventId.WeChatOfficalLoginLoginAgreementCheck, this);

            }
            else if (GuardDetailScene == GuardDetailScene.MailRegister)
            {
                EventManagement.Instance.RemoveListener((int)EventId.MailRegisterAgreementCheck, this);

            }
            else if (GuardDetailScene == GuardDetailScene.PhoneRegister)
            {
                EventManagement.Instance.RemoveListener((int)EventId.PhoneRegisterAgreementCheck, this);
            }
        }

        public void HandleEvent(int eventId, IEventArgs args)
        {
            switch (eventId)
            {
                case (int)EventId.PasswordLoginAgreementCheck: AgreementCheck(); break;
                case (int)EventId.SMSCodeLoginLoginAgreementCheck: AgreementCheck(); break;
                case (int)EventId.ScanCodeLoginLoginAgreementCheck: AgreementCheck(); break;
                case (int)EventId.ADLoginLoginAgreementCheck: AgreementCheck(); break;
                case (int)EventId.WeChatLoginLoginAgreementCheck: AgreementCheck(); break;
                case (int)EventId.WeChatOfficalLoginLoginAgreementCheck: AgreementCheck(); break;
                case (int)EventId.MailRegisterAgreementCheck: AgreementCheck(); break;
                case (int)EventId.PhoneRegisterAgreementCheck: AgreementCheck(); break;

                case (int)EventId.LanguageChanged: LanguageChanged((Lang)args.GetValue<int>()); break;
            }
        }

        private void LanguageChanged(Lang lang)
        {
            currentLang = lang;

            Init();
        }

        private void Init()
        {
            agreements = new List<Agreement>();

            if (ConfigService.Agreements == null || ConfigService.Agreements.Count == 0)
            {
                this.Visibility = Visibility.Collapsed;
                return;
            }

            AddEvent();

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

        private void AgreementView_Loaded(object sender, RoutedEventArgs e)
        {
            allAgreements = m_JsonService.Deserialize<List<Agreement>>(m_JsonService.Serialize(ConfigService.Agreements));

            currentLang = Lang.zhCn;

            EventManagement.Instance.AddListener((int)EventId.LanguageChanged, this);

            Init();
        }

        private void AddEvent()
        {
            if (GuardDetailScene == GuardDetailScene.PasswordLogin)
            {
                EventManagement.Instance.RemoveListener((int)EventId.PasswordLoginAgreementCheck, this);
                EventManagement.Instance.AddListener((int)EventId.PasswordLoginAgreementCheck, this);

                agreements = allAgreements.Where(p => p.AvailableAt == AvailableAt.Login || p.AvailableAt == AvailableAt.RegisterAndLogin).Where(p => p.Lang == currentLang.GetDescription()).ToList();
            }
            else if (GuardDetailScene == GuardDetailScene.SMSCodeLogin)
            {
                EventManagement.Instance.RemoveListener((int)EventId.SMSCodeLoginLoginAgreementCheck, this);
                EventManagement.Instance.AddListener((int)EventId.SMSCodeLoginLoginAgreementCheck, this);

                agreements = allAgreements.Where(p => p.AvailableAt == AvailableAt.Login || p.AvailableAt == AvailableAt.RegisterAndLogin).Where(p => p.Lang == currentLang.GetDescription()).ToList();
            }
            else if (GuardDetailScene == GuardDetailScene.ScanCodeLogin)
            {
                EventManagement.Instance.RemoveListener((int)EventId.ScanCodeLoginLoginAgreementCheck, this);
                EventManagement.Instance.AddListener((int)EventId.ScanCodeLoginLoginAgreementCheck, this);

                agreements = allAgreements.Where(p => p.AvailableAt == AvailableAt.Login || p.AvailableAt == AvailableAt.RegisterAndLogin).Where(p => p.Lang == currentLang.GetDescription()).ToList();
            }
            else if (GuardDetailScene == GuardDetailScene.ADLogin)
            {
                EventManagement.Instance.RemoveListener((int)EventId.ADLoginLoginAgreementCheck, this);
                EventManagement.Instance.AddListener((int)EventId.ADLoginLoginAgreementCheck, this);

                agreements = allAgreements.Where(p => p.AvailableAt == AvailableAt.Login || p.AvailableAt == AvailableAt.RegisterAndLogin).Where(p => p.Lang == currentLang.GetDescription()).ToList();
            }
            else if (GuardDetailScene == GuardDetailScene.WeChatLogin)
            {
                EventManagement.Instance.RemoveListener((int)EventId.WeChatLoginLoginAgreementCheck, this);
                EventManagement.Instance.AddListener((int)EventId.WeChatLoginLoginAgreementCheck, this);

                agreements = allAgreements.Where(p => p.AvailableAt == AvailableAt.Login || p.AvailableAt == AvailableAt.RegisterAndLogin).Where(p => p.Lang == currentLang.GetDescription()).ToList();
            }
            else if (GuardDetailScene == GuardDetailScene.WeChatOfficalLogin)
            {
                EventManagement.Instance.RemoveListener((int)EventId.WeChatOfficalLoginLoginAgreementCheck, this);
                EventManagement.Instance.AddListener((int)EventId.WeChatOfficalLoginLoginAgreementCheck, this);

                agreements = allAgreements.Where(p => p.AvailableAt == AvailableAt.Login || p.AvailableAt == AvailableAt.RegisterAndLogin).Where(p => p.Lang == currentLang.GetDescription()).ToList();
            }
            else if (GuardDetailScene == GuardDetailScene.MailRegister)
            {
                EventManagement.Instance.RemoveListener((int)EventId.MailRegisterAgreementCheck, this);
                EventManagement.Instance.AddListener((int)EventId.MailRegisterAgreementCheck, this);

                agreements = allAgreements.Where(p => p.AvailableAt == AvailableAt.Register || p.AvailableAt == AvailableAt.RegisterAndLogin).Where(p => p.Lang == currentLang.GetDescription()).ToList();
            }
            else if (GuardDetailScene == GuardDetailScene.PhoneRegister)
            {
                EventManagement.Instance.RemoveListener((int)EventId.PhoneRegisterAgreementCheck, this);
                EventManagement.Instance.AddListener((int)EventId.PhoneRegisterAgreementCheck, this);

                agreements = allAgreements.Where(p => p.AvailableAt == AvailableAt.Register || p.AvailableAt == AvailableAt.RegisterAndLogin).Where(p => p.Lang == currentLang.GetDescription()).ToList();
            }
        }

        private void AgreementCheck()
        {
            int needCheck = agreements.Count(p => p.Required);

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

            DispatchEvent(needCheck != 0);
        }

        private void DispatchEvent(bool needCheck)
        {
            if (GuardDetailScene == GuardDetailScene.PasswordLogin)
            {
                if (needCheck)
                {
                    PrimaryMessageBoxService.Show(ResourceHelper.GetResource<string>("Pleasechecktheloginprotocol"), IconType.Error);
                }

                EventManagement.Instance.Dispatch((int)EventId.PasswordLoginLoginAgreementCheckFinish, EventArgs<bool>.CreateEventArgs(!needCheck));
            }
            else if (GuardDetailScene == GuardDetailScene.SMSCodeLogin)
            {
                if (needCheck)
                {
                    PrimaryMessageBoxService.Show("请勾选登录协议", IconType.Error);
                }

                EventManagement.Instance.Dispatch((int)EventId.SMSCodeLoginLoginLoginAgreementCheckFinish, EventArgs<bool>.CreateEventArgs(!needCheck));
            }
            else if (GuardDetailScene == GuardDetailScene.ScanCodeLogin)
            {
                if (needCheck)
                {
                    PrimaryMessageBoxService.Show("请勾选登录协议", IconType.Error);
                }

                EventManagement.Instance.Dispatch((int)EventId.ScanCodeLoginLoginLoginAgreementCheckFinish, EventArgs<bool>.CreateEventArgs(!needCheck));
            }
            else if (GuardDetailScene == GuardDetailScene.ADLogin)
            {
                if (needCheck)
                {
                    PrimaryMessageBoxService.Show("请勾选登录协议", IconType.Error);
                }

                EventManagement.Instance.Dispatch((int)EventId.ADLoginLoginLoginAgreementCheckFinish, EventArgs<bool>.CreateEventArgs(!needCheck));
            }
            else if (GuardDetailScene == GuardDetailScene.WeChatLogin)
            {
                if (needCheck)
                {
                    PrimaryMessageBoxService.Show("请勾选登录协议", IconType.Error);
                }

                EventManagement.Instance.Dispatch((int)EventId.WeChatLoginLoginAgreementCheck, EventArgs<bool>.CreateEventArgs(!needCheck));
            }
            else if (GuardDetailScene == GuardDetailScene.WeChatOfficalLogin)
            {
                if (needCheck)
                {
                    PrimaryMessageBoxService.Show("请勾选登录协议", IconType.Error);
                }

                EventManagement.Instance.Dispatch((int)EventId.WeChatOfficalLoginLoginAgreementCheck, EventArgs<bool>.CreateEventArgs(!needCheck));
            }
            else if (GuardDetailScene == GuardDetailScene.MailRegister)
            {
                if (needCheck)
                {
                    PrimaryMessageBoxService.Show(ResourceHelper.GetResource<string>("Pleasechecktheregistrationagreement"), IconType.Error);
                }

                EventManagement.Instance.Dispatch((int)EventId.MailRegisterAgreementCheckFinish, EventArgs<bool>.CreateEventArgs(!needCheck));
            }
            else if (GuardDetailScene == GuardDetailScene.PhoneRegister)
            {
                if (needCheck)
                {
                    PrimaryMessageBoxService.Show("请勾选注册协议", IconType.Error);
                }

                EventManagement.Instance.Dispatch((int)EventId.PhoneRegisterAgreementCheckFinish, EventArgs<bool>.CreateEventArgs(!needCheck));
            }
        }
    }
}
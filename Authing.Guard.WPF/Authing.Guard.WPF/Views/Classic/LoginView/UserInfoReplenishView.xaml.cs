using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Authing.ApiClient.Domain.Model;
using Authing.Guard.WPF.Controls;
using Authing.Guard.WPF.Enums;
using Authing.Guard.WPF.Events;
using Authing.Guard.WPF.Events.EventAggreator;
using Authing.Guard.WPF.Infrastructures;
using Authing.Guard.WPF.Models;
using Authing.Guard.WPF.Services;
using Authing.Guard.WPF.Utils;
using Authing.Guard.WPF.Utils.Extensions;
using Authing.Guard.WPF.Views.Classic.MainView;

namespace Authing.Guard.WPF.Views.Classic.LoginView
{
    /// <summary>
    /// UserInfoReplenishView.xaml 的交互逻辑
    /// </summary>
    public partial class UserInfoReplenishView : IEventListener
    {
        private readonly UserWithEvent _userWithEvent;
        public ObservableCollection<InfoReplenish> DataItems { get; set; }

        public UserInfoReplenishView(UserWithEvent param)
        {
            _userWithEvent = param;
            InitializeComponent();
            //InitDemoData();
            MakeData();
            DataContext = this;
            this.Unloaded += (sender, args) =>
            {
                EventManagement.Instance.RemoveListener((int)EventId.LanguageChanged, this);
            };
            this.Loaded += (sender, args) =>
            {
                EventManagement.Instance.AddListener((int)EventId.LanguageChanged, this);
            };
            if (ConfigService.ExtendConfig.CanIgnore)
                IgnoreBtn.Visibility = Visibility.Visible;
            else
                IgnoreBtn.Visibility = Visibility.Collapsed;
        }

        private void MakeData()
        {
            DataItems = new ObservableCollection<InfoReplenish>();
            if (ConfigService.ExtendConfig.ExtendFields is null) return;
            foreach (var control in ConfigService.ExtendConfig.ExtendFields)
            {
                if (control.Control == ControlName.UserInfoPhone || control.Control == ControlName.UserInfoMail)
                {
                    if (control.Control == ControlName.UserInfoPhone)
                        DataItems.Add(new InfoReplenish() { Name = ResourceHelper.GetResource<string>(control.Control.ToString()), InfoType = InfoType.Phone, IsNessary = control.Required });
                    else
                        DataItems.Add(new InfoReplenish() { Name = ResourceHelper.GetResource<string>(control.Control.ToString()), InfoType = InfoType.Mail, IsNessary = control.Required });
                    continue;
                }
                if (control.Control == ControlName.UserInfoGender)
                {
                    DataItems.Add(new InfoReplenish()
                    {
                        Name = ResourceHelper.GetResource<string>(control.Control.ToString()),
                        Items = new List<string>()
                        {
                            ResourceHelper.GetResource<string>("Undefined"),
                            ResourceHelper.GetResource<string>("Male"),
                            ResourceHelper.GetResource<string>("FaMale")
                        },
                        IsNessary = true
                    });
                    continue;
                }

                DataItems.Add(new InfoReplenish() { Name = ResourceHelper.GetResource<string>(control.Control.ToString()), IsNessary = control.Required });
            }
        }

        private void InitDemoData()
        {
            DataItems = new ObservableCollection<InfoReplenish>();
            FillData();
        }

        private void FillData()
        {
            DataItems.Add(new InfoReplenish() { Name = ResourceHelper.GetResource<string>("UserInfoName"), IsNessary = true });
            DataItems.Add(new InfoReplenish()
            { Name = ResourceHelper.GetResource<string>("UserInfoUserName"), IsNessary = true });
            DataItems.Add(new InfoReplenish()
            { Name = ResourceHelper.GetResource<string>("UserInfoNickName"), IsNessary = true });
            DataItems.Add(new InfoReplenish()
            {
                Name = ResourceHelper.GetResource<string>("UserInfoGender"),
                Items = new List<string>()
                {
                    ResourceHelper.GetResource<string>("Undefined"),
                    ResourceHelper.GetResource<string>("Male"),
                    ResourceHelper.GetResource<string>("FaMale")
                },
                IsNessary = true
            });
            DataItems.Add(
                new InfoReplenish() { Name = ResourceHelper.GetResource<string>("UserInfoBirthdate"), IsNessary = true });
            DataItems.Add(new InfoReplenish()
            { Name = ResourceHelper.GetResource<string>("UserInfoPhone"), IsNessary = true, InfoType = InfoType.Phone });
            DataItems.Add(new InfoReplenish() { Name = ResourceHelper.GetResource<string>("UserInfoCountry"), IsNessary = true });
            DataItems.Add(new InfoReplenish() { Name = ResourceHelper.GetResource<string>("UserInfoCompany"), IsNessary = true });
            DataItems.Add(new InfoReplenish() { Name = ResourceHelper.GetResource<string>("UserInfoCity"), IsNessary = true });
            DataItems.Add(
                new InfoReplenish() { Name = ResourceHelper.GetResource<string>("UserInfoCProvince"), IsNessary = true });
            DataItems.Add(new InfoReplenish()
            { Name = ResourceHelper.GetResource<string>("UserInfoStreetAddress"), IsNessary = true });
            DataItems.Add(new InfoReplenish()
            { Name = ResourceHelper.GetResource<string>("UserInfoStreetPostalCode"), IsNessary = true });
            DataItems.Add(new InfoReplenish()
            { Name = ResourceHelper.GetResource<string>("UserInfoStreetformatted"), IsNessary = true });
            DataItems.Add(new InfoReplenish()
            { Name = ResourceHelper.GetResource<string>("UserInfoMail"), InfoType = InfoType.Mail, IsNessary = true, });
        }

        public void HandleEvent(int eventId, IEventArgs args)
        {
            switch (eventId)
            {
                case (int)EventId.LanguageChanged:
                    DataItems.Clear();
                    MakeData();
                    //FillData();
                    break;
            }
        }

        private async void MailSendCodeBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is CoutDownButton)
            {
                CoutDownButton btn = sender as CoutDownButton;
                btn.IsBusy = true;
                await TaskExHelper.Delay(1000);
                btn.IsBusy = false;
                btn.StartCountDown = true;
                //btn.Content = "已验证";
            }
        }

        private async void PhoneSendCodeBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is CoutDownButton)
            {
                CoutDownButton btn = sender as CoutDownButton;
                btn.IsBusy = true;
                await TaskExHelper.Delay(1000);
                btn.IsBusy = false;
                btn.StartCountDown = true;
                //btn.Content = "已验证";
            }
        }

        private void BtnCommit_OnClick(object sender, RoutedEventArgs e)
        {
            if(_userWithEvent.EventFrom == EventId.Login)
                EventManagement.Instance.Dispatch((int)EventId.Login,
                    EventArgs<User>.CreateEventArgs(_userWithEvent.User));
            else
                EventManagement.Instance.Dispatch((int)EventId.Register,
                    EventArgs<User>.CreateEventArgs(_userWithEvent.User));
        }

        private void IgnoreBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (_userWithEvent.EventFrom == EventId.Login)
            {
                PrimaryMessageBoxService.Show(ResourceHelper.GetResource<string>("loginSuccessWelcome") + _userWithEvent.User.Username, IconType.Success);
                EventManagement.Instance.Dispatch((int)EventId.Login,
                    EventArgs<User>.CreateEventArgs(_userWithEvent.User));
            }
            else
                EventManagement.Instance.Dispatch((int)EventId.Register,
                    EventArgs<User>.CreateEventArgs(_userWithEvent.User));
        }
    }
}
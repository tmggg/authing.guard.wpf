using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Authing.Guard.WPF.Enums;
using Authing.Guard.WPF.Events;
using Authing.Guard.WPF.Events.EventAggreator;
using Authing.Guard.WPF.Models;
using Authing.Guard.WPF.Utils;

namespace Authing.Guard.WPF.Views.LoginView
{
    /// <summary>
    /// UserInfoReplenishView.xaml 的交互逻辑
    /// </summary>
    public partial class UserInfoReplenishView : UserControl, IEventListener
    {
        public ObservableCollection<InfoReplenish> DataItems { get; set; }

        public UserInfoReplenishView()
        {
            InitializeComponent();
            initDemoData();
            DataContext = this;
            this.Unloaded += (sender, args) =>
            {
                EventManagement.Instance.RemoveListener((int)EventId.LanguageChanged, this);
            };
            this.Loaded += (sender, args) =>
            {
                EventManagement.Instance.AddListener((int)EventId.LanguageChanged, this);
            };
        }

        private void initDemoData()
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
                Items = new List<string>() { "未知", "男", "女" },
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
                    FillData();
                    break;

                default:
                    break;
            }
        }
    }
}
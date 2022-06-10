﻿using System;
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
using Authing.Guard.WPF.Models;

namespace Authing.Guard.WPF.Views.LoginView
{
    /// <summary>
    /// UserInfoReplenishView.xaml 的交互逻辑
    /// </summary>
    public partial class UserInfoReplenishView : UserControl
    {
        public ObservableCollection<InfoReplenish> DataItems { get; set; }

        public UserInfoReplenishView()
        {
            InitializeComponent();
            initDemoData();
            DataContext = this;
        }

        private void initDemoData()
        {
            DataItems = new ObservableCollection<InfoReplenish>();
            DataItems.Add(new InfoReplenish() { Name = "姓名", IsNessary = false });
            DataItems.Add(new InfoReplenish() { Name = "性别", Items = new List<string>() { "未知", "男", "女" }, IsNessary = true });
            DataItems.Add(new InfoReplenish() { Name = "手机号", InfoType = InfoType.Phone, IsNessary = true, });
            DataItems.Add(new InfoReplenish() { Name = "邮箱", InfoType = InfoType.Mail, IsNessary = true, });
            DataItems.Add(new InfoReplenish() { Name = "地址", IsNessary = true });
            DataItems.Add(new InfoReplenish() { Name = "座机", IsNessary = true });
            DataItems.Add(new InfoReplenish() { Name = "公司名", IsNessary = false });
            DataItems.Add(new InfoReplenish() { Name = "工号", IsNessary = true });
            DataItems.Add(new InfoReplenish() { Name = "年龄", IsNessary = true });
        }
    }
}
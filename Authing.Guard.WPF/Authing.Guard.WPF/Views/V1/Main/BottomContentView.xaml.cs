using Authing.Guard.WPF.Enums;
using Authing.Guard.WPF.Events;
using Authing.Guard.WPF.Events.EventAggreator;
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

namespace Authing.Guard.WPF.Views.V1.Main
{
    /// <summary>
    /// BottomContentView.xaml 的交互逻辑
    /// </summary>
    public partial class BottomContentView : UserControl
    {
        public BottomContentView()
        {
            InitializeComponent();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox)
            {
                if (((ComboBox)sender).SelectedItem is Label)
                {
                    var obj = ((ComboBox)sender).SelectedItem as Label;
                    if (string.Equals(obj.Content.ToString(), "English", StringComparison.Ordinal))
                    {
                        var res = Application.Current.Resources.MergedDictionaries;
                        var lang = res.First(p => p.Source.AbsoluteUri.Contains("en-US.xaml"));
                        Application.Current.Resources.MergedDictionaries.Remove(lang);
                        Application.Current.Resources.MergedDictionaries.Add(lang);

                        EventManagement.Instance.Dispatch((int)EventId.LanguageChanged, EventArgs<int>.CreateEventArgs((int)Lang.enUs));

                    }
                    if (string.Equals(obj.Content.ToString(), "中文", StringComparison.Ordinal))
                    {
                        var res = Application.Current.Resources.MergedDictionaries;
                        var lang = res.First(p => p.Source.AbsoluteUri.Contains("zh-CN.xaml"));
                        Application.Current.Resources.MergedDictionaries.Remove(lang);
                        Application.Current.Resources.MergedDictionaries.Add(lang);

                        EventManagement.Instance.Dispatch((int)EventId.LanguageChanged, EventArgs<int>.CreateEventArgs((int)Lang.zhCn));

                    }
                }
            }
        }

        private void btnFeedback_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

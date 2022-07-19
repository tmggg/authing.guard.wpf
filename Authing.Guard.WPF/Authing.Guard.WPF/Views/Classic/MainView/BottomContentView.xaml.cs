using Authing.Guard.WPF.Events;
using Authing.Guard.WPF.Events.EventAggreator;
using Authing.Guard.WPF.Utils;
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

namespace Authing.Guard.WPF.Views.Classic.MainView
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
                        var dic =ResourceHelper.GetLanguageDictionary(Enums.Lang.enUs);

                        Application.Current.Resources.MergedDictionaries.Clear();
                        Application.Current.Resources.MergedDictionaries.Add(dic);

                        EventManagement.Instance.Dispatch((int)EventId.LanguageChanged, EventArgs<int>.CreateEventArgs((int)Enums.Lang.enUs));
                    }
                    if (string.Equals(obj.Content.ToString(), "中文", StringComparison.Ordinal))
                    {
                        var dic = ResourceHelper.GetLanguageDictionary(Enums.Lang.zhCn);

                        Application.Current.Resources.Clear();
                        Application.Current.Resources.MergedDictionaries.Add(dic);

                        EventManagement.Instance.Dispatch((int)EventId.LanguageChanged, EventArgs<int>.CreateEventArgs((int)Enums.Lang.zhCn));
                    }
                }
            }
        }

        private void btnFeedback_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

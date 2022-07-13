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
    public partial class AgreementView : UserControl
    {
        public AgreementView()
        {
            InitializeComponent();

            Loaded += AgreementView_Loaded;
        }

        private void AgreementView_Loaded(object sender, RoutedEventArgs e)
        {
            if (GuardMainView.Agreements == null || GuardMainView.Agreements.Count == 0)
            {
                this.Visibility = Visibility.Collapsed;
                return;
            }

            //HtmlDocument a = new HtmlDocument();
        }
    }
}

using Authing.Guard.WPF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Authing.Guard.WPF.Controls
{
    /// <summary>
    /// PrimaryMessageBox.xaml 的交互逻辑
    /// </summary>
    public partial class PrimaryMessageBox : Window
    {
        public Action<int> OnClose { get; set; }

        public PrimaryMessageBox()
        {
            InitializeComponent();

            Task.Factory.StartNew(() => 
            {
                Thread.Sleep(3 * 1000);

                Dispatcher.BeginInvoke(new Action(() =>
                {
                    OnClose?.Invoke(GetHashCode());
                    Close();
                }));
            });
        }

        /// <summary>
        /// 语言
        /// </summary>
        public Lang Lang
        {
            get { return (Lang)GetValue(LangProperty); }
            set { SetValue(LangProperty, value); }
        }

        public static DependencyProperty LangProperty = DependencyProperty.Register(nameof(Lang), typeof(Lang), typeof(PrimaryMessageBox), new PropertyMetadata());

        /// <summary>
        /// 图标类型
        /// </summary>
        public IconType IconType
        {
            get { return (IconType)GetValue(IconTypeProperty); }
            set { SetValue(IconTypeProperty, value); }
        }

        public static DependencyProperty IconTypeProperty = DependencyProperty.Register(nameof(IconType), typeof(IconType), typeof(PrimaryMessageBox), new PropertyMetadata(IconType.Blank));

        /// <summary>
        /// 提示的消息
        /// </summary>
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static DependencyProperty MessageProperty = DependencyProperty.Register(nameof(MessageProperty), typeof(string), typeof(PrimaryMessageBox), new PropertyMetadata(string.Empty,MessagePropertyChangedCallback));

        private static void MessagePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as PrimaryMessageBox).tbInfo.Text = (string)e.NewValue;
        }


        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}

using Authing.Guard.WPF.Enums;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Authing.Guard.WPF.Controls
{
    /// <summary>
    /// Icon.xaml 的交互逻辑
    /// </summary>
    public partial class Icon : UserControl
    {
        private static readonly Dictionary<string, Style> m_KeyMapStyle;

        static Icon()
        {
            m_KeyMapStyle = new Dictionary<string, Style>();
        }

        public Icon()
        {
            InitializeComponent();

            if (m_KeyMapStyle.Count == 0)
            {
                foreach (var key in Resources.Keys)
                {
                    string s = key.ToString();
                    object value = Resources[s];
                    if (value is Style style)
                    {
                        m_KeyMapStyle.Add(s.ToLowerInvariant(), style);
                    }
                }
            }
        }

        public IconType Type
        {
            get
            {
                return (IconType)GetValue(TypeProperty);
            }
            set
            {
                SetValue(TypeProperty, value);
            }
        }

        public static readonly DependencyProperty TypeProperty = DependencyProperty.Register(nameof(Type), typeof(IconType), typeof(Icon), new PropertyMetadata(IconType.Blank, TypeChanged));

        public double ImageWidth
        {
            get
            {
                return (double)GetValue(ImageWidthProperty);
            }
            set
            {
                SetValue(ImageWidthProperty, value);
            }
        }

        public static readonly DependencyProperty ImageWidthProperty = DependencyProperty.Register(nameof(ImageWidth), typeof(double), typeof(Icon), new PropertyMetadata(40.0));

        public double ImageHeight
        {
            get
            {
                return (double)GetValue(ImageHeightProperty);
            }
            set
            {
                SetValue(ImageHeightProperty, value);
            }
        }

        public static readonly DependencyProperty ImageHeightProperty = DependencyProperty.Register(nameof(ImageHeight), typeof(double), typeof(Icon), new PropertyMetadata(40.0));

        public Brush Fill;
        public static readonly DependencyProperty FillProperty = DependencyProperty.Register(nameof(Fill), typeof(Brush), typeof(Icon), new PropertyMetadata(null, FillChanged));

        private static void TypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Icon icon && e.NewValue is IconType type)
            {
                string s = $"{type}".ToLowerInvariant();
                if (!m_KeyMapStyle.ContainsKey(s))
                {
                    return;
                }
                icon.btn.Style = m_KeyMapStyle[s];
                if (!(icon.Fill is null))
                {
                    icon.btn.Foreground = icon.Fill;
                }
            }
        }

        private static void FillChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Icon icon && e.NewValue is Brush brush)
            {
                icon.btn.Foreground = brush;
            }
        }
    }
}
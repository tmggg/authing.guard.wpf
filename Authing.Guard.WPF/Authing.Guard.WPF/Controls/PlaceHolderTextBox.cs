using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Authing.Guard.WPF.Controls
{
    public class PlaceHolderTextBox : TextBox
    {
        public string PlaceHolder
        {
            get
            {
                return (string)GetValue(PlaceHolderProperty);
            }
            set
            {
                SetValue(PlaceHolderProperty, value);
            }
        }

        public static DependencyProperty PlaceHolderProperty = DependencyProperty.Register(nameof(PlaceHolder), typeof(string), typeof(PlaceHolderTextBox), new PropertyMetadata(string.Empty));

        public double PlaceHolderFontSize
        {
            get
            {
                return (double)GetValue(PlaceHolderFontSizeProperty);
            }
            set
            {
                SetValue(PlaceHolderFontSizeProperty, value);
            }
        }
        public static DependencyProperty PlaceHolderFontSizeProperty = DependencyProperty.Register(nameof(PlaceHolderFontSize), typeof(double), typeof(PlaceHolderTextBox), new PropertyMetadata(12.0));

        public Brush PlaceHolderForeground
        {
            get
            {
                return (Brush)GetValue(PlaceHolderForegroundProperty);
            }
            set
            {
                SetValue(PlaceHolderForegroundProperty, value);
            }
        }
        public static DependencyProperty PlaceHolderForegroundProperty = DependencyProperty.Register(nameof(PlaceHolderForeground), typeof(Brush), typeof(PlaceHolderTextBox), new PropertyMetadata(null));

        public VerticalAlignment PlaceHolderVerticalAlignment
        {
            get
            {
                return (VerticalAlignment)GetValue(PlaceHolderVerticalAlignmentProperty);
            }
            set
            {
                SetValue(PlaceHolderVerticalAlignmentProperty, value);
            }
        }
        public static DependencyProperty PlaceHolderVerticalAlignmentProperty = DependencyProperty.Register(nameof(PlaceHolderVerticalAlignment), typeof(VerticalAlignment), typeof(PlaceHolderTextBox), new PropertyMetadata(VerticalAlignment.Center));

        public HorizontalAlignment PlacelHolderHorizontalAlignment
        {
            get
            {
                return (HorizontalAlignment)GetValue(PlacelHolderHorizontalAlignmentProperty);
            }
            set
            {
                SetValue(PlacelHolderHorizontalAlignmentProperty, value);
            }
        }
        public static DependencyProperty PlacelHolderHorizontalAlignmentProperty = DependencyProperty.Register(nameof(PlacelHolderHorizontalAlignment), typeof(HorizontalAlignment), typeof(PlaceHolderTextBox), new PropertyMetadata(HorizontalAlignment.Center));

        public CornerRadius CornerRadius
        {
            get
            {
                return (CornerRadius)GetValue(CornerRadiusProperty);
            }
            set
            {
                SetValue(CornerRadiusProperty, value);  
            }
        }
        public static DependencyProperty CornerRadiusProperty = DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(PlaceHolderTextBox), new PropertyMetadata(new CornerRadius()));
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Authing.Guard.WPF.Converters
{
    public class AuthingPlaceHolderTextBox : TextBox
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

        public static DependencyProperty PlaceHolderProperty = DependencyProperty.Register(nameof(PlaceHolder), typeof(string), typeof(AuthingPlaceHolderTextBox), new PropertyMetadata(string.Empty));

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
        public static DependencyProperty PlaceHolderFontSizeProperty = DependencyProperty.Register(nameof(PlaceHolderFontSize), typeof(double), typeof(AuthingPlaceHolderTextBox), new PropertyMetadata(12.0));

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
        public static DependencyProperty PlaceHolderForegroundProperty = DependencyProperty.Register(nameof(PlaceHolderForeground), typeof(Brush), typeof(AuthingPlaceHolderTextBox), new PropertyMetadata(null));

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
        public static DependencyProperty PlaceHolderVerticalAlignmentProperty = DependencyProperty.Register(nameof(PlaceHolderVerticalAlignment), typeof(VerticalAlignment), typeof(AuthingPlaceHolderTextBox), new PropertyMetadata(VerticalAlignment.Center));
          
    }
}

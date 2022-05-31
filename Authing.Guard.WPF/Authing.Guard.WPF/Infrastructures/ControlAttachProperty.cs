using System.Windows;
using System.Windows.Media;

namespace Authing.Guard.WPF.Infrastructures
{
    public class ControlAttachProperty
    {
        public static string GetPlaceHolder(DependencyObject obj)
        {
            return (string)obj.GetValue(PlaceHolderProperty);
        }

        public static void SetPlaceHolder(DependencyObject obj, string value)
        {
            obj.SetValue(PlaceHolderProperty, value);
        }

        public static readonly DependencyProperty PlaceHolderProperty =
            DependencyProperty.RegisterAttached("PlaceHolder", typeof(string), typeof(ControlAttachProperty), new PropertyMetadata(string.Empty));

        public static double GetPlaceHolderFontSize(DependencyObject obj)
        {
            return (double)obj.GetValue(PlaceHolderFontSizeProperty);
        }

        public static void SetPlaceHolderFontSize(DependencyObject obj, double value)
        {
            obj.SetValue(PlaceHolderFontSizeProperty, value);
        }

        public static DependencyProperty PlaceHolderFontSizeProperty =
            DependencyProperty.RegisterAttached("PlaceHolderFontSize", typeof(double), typeof(ControlAttachProperty), new PropertyMetadata(12.0));

        public static Brush GetPlaceHolderForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(PlaceHolderForegroundProperty);
        }
        public static void SetPlaceHolderForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(PlaceHolderForegroundProperty, value);
        }

        public static DependencyProperty PlaceHolderForegroundProperty =
            DependencyProperty.RegisterAttached("PlaceHolderForeground", typeof(Brush), typeof(ControlAttachProperty), new PropertyMetadata(null));

        public static VerticalAlignment GetPlaceHolderVerticalAlignment(DependencyObject obj)
        {
            return (VerticalAlignment)obj.GetValue(PlaceHolderVerticalAlignmentProperty);
        }

        public static void SetPlaceHolderVerticalAlignment(DependencyObject obj, VerticalAlignment value)
        {
            obj.SetValue(PlaceHolderVerticalAlignmentProperty, value);
        }

        public static DependencyProperty PlaceHolderVerticalAlignmentProperty =
            DependencyProperty.RegisterAttached("PlaceHolderVerticalAlignment", typeof(VerticalAlignment), typeof(ControlAttachProperty), new PropertyMetadata(VerticalAlignment.Center));

        public static HorizontalAlignment GetPlacelHolderHorizontalAlignment(DependencyObject obj)
        {
            return (HorizontalAlignment)obj.GetValue(PlacelHolderHorizontalAlignmentProperty);
        }

        public static void SetPlacelHolderHorizontalAlignment(DependencyObject obj, HorizontalAlignment value)
        {
            obj.SetValue(PlacelHolderHorizontalAlignmentProperty, value);
        }

        public static DependencyProperty PlacelHolderHorizontalAlignmentProperty =
            DependencyProperty.RegisterAttached("PlacelHolderHorizontalAlignment", typeof(HorizontalAlignment), typeof(ControlAttachProperty), new PropertyMetadata(HorizontalAlignment.Center));
    }
}
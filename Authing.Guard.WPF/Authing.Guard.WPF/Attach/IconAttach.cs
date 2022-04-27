using System.Windows;
using System.Windows.Media;

namespace Authing.Guard.WPF.Attach
{
    public class IconAttach
    {
        public static readonly DependencyProperty GeometryProperty = DependencyProperty.RegisterAttached(
            "Geometry", typeof(Geometry), typeof(IconAttach), new PropertyMetadata(default(Geometry)));

        public static void SetGeometry(DependencyObject element, Geometry value)
            => element.SetValue(GeometryProperty, value);

        public static Geometry GetGeometry(DependencyObject element)
            => (Geometry)element.GetValue(GeometryProperty);

        public static readonly DependencyProperty WidthProperty = DependencyProperty.RegisterAttached(
            "Width", typeof(double), typeof(IconAttach), new PropertyMetadata(double.NaN));

        public static void SetWidth(DependencyObject element, double value)
            => element.SetValue(WidthProperty, value);

        public static double GetWidth(DependencyObject element)
            => (double)element.GetValue(WidthProperty);

        public static readonly DependencyProperty HeightProperty = DependencyProperty.RegisterAttached(
            "Height", typeof(double), typeof(IconAttach), new PropertyMetadata(double.NaN));

        public static void SetHeight(DependencyObject element, double value)
            => element.SetValue(HeightProperty, value);

        public static double GetHeight(DependencyObject element)
            => (double)element.GetValue(HeightProperty);

        public static readonly DependencyProperty ForegroundColorLightProperty = DependencyProperty.RegisterAttached(
            "ForegroundColorLight", typeof(SolidColorBrush), typeof(IconAttach), new PropertyMetadata(default(SolidColorBrush)));

        public static void SetForegroundColorLight(DependencyObject element, SolidColorBrush value)
        {
            element.SetValue(ForegroundColorLightProperty, value);
        }

        public static SolidColorBrush GetForegroundColorLight(DependencyObject element)
        {
            return (SolidColorBrush)element.GetValue(ForegroundColorLightProperty);
        }
    }
}
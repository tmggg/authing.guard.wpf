using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Authing.Guard.WPF.Converters
{
    public class Null2StringConverter : IValueConverter
    {
        public static Null2StringConverter Null2String = new Null2StringConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value ?? "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

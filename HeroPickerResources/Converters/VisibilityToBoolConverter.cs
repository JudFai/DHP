using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace HeroPickerResources.Converters
{
    public class VisibilityToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var inverse = false;
            if (parameter != null)
                inverse = System.Convert.ToBoolean(parameter.ToString().ToLower());

            if (!(value is bool))
            {
                if (!inverse)
                    return Visibility.Collapsed;

                return Visibility.Visible;
            }

            var flag = (bool)value;
            Visibility result;
            if (flag)
                result = !inverse ? Visibility.Visible : Visibility.Collapsed;
            else
                result = !inverse ? Visibility.Collapsed : Visibility.Visible;

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Visibility.Collapsed;
        }
    }
}

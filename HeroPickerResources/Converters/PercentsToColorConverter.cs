using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace HeroPickerResources.Converters
{
    public class PercentsToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var val = (double)value / 100d;
            var red = System.Convert.ToByte(Math.Round(255 * (1 - val)));
            var green = System.Convert.ToByte(Math.Round(255 * val));
            //var blue = System.Convert.ToByte(Math.Round(255 * Math.Abs(0.5 - val)));
            return Color.FromRgb(red, green, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}

using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfOrganizer.Converters
{
    class ColorToBrush : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color color = (Color)value;
            //System.Diagnostics.Trace.WriteLine("Got color: " + color.ToString());
            var t = new SolidColorBrush(color);
            return t;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}

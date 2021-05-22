using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfOrganizer.Converters
{
    class TagNameTrimmer : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string name = (string)value;
            if (name == null) return value;

            return name[0].ToString().ToUpper();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}

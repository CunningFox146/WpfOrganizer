using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using WpfOrganizer.Models;

namespace WpfOrganizer.Converters
{
    class DateToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "";

            var dateTime = (DateTime)value;

            //if (dateTime == null) return "";

            return dateTime.ToLongTimeString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}

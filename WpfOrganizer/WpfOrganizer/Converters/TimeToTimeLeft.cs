using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using WpfOrganizer.Models;

namespace WpfOrganizer.Converters
{
    class TimeToTimeLeft : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "Просрочено";
            var timeSpan = (TimeSpan)value;
            if (timeSpan == null || timeSpan.TotalSeconds < 0) return "Просрочено";

            return timeSpan.ToString(@"hh\:mm\:ss");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}

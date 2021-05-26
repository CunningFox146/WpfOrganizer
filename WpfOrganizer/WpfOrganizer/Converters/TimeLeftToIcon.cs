using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using WpfOrganizer.Models;
using MaterialDesignThemes.Wpf;

namespace WpfOrganizer.Converters
{
    class TimeLeftToIcon : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return PackIconKind.ClockTimeFourOutline;
            var hoursLeft = ((TimeSpan)value).TotalHours;
            
            return hoursLeft <= 1 ? PackIconKind.ClockAlertOutline : PackIconKind.ClockTimeFourOutline;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}

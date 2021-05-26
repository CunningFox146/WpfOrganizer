using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using WpfOrganizer.Models;
using MaterialDesignThemes.Wpf;

namespace WpfOrganizer.Converters
{
    class TimeLeftToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color green = Color.FromRgb(128, 255, 0);
            Color orange = Color.FromRgb(255, 165, 0);
            Color red = Color.FromRgb(255, 99, 71);
            
            if (value == null) return new SolidColorBrush(green);
            var minutesLeft = ((TimeSpan)value).TotalMinutes;

            return new SolidColorBrush(minutesLeft <= 30 ? red : minutesLeft <= 60 ? orange : green);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}

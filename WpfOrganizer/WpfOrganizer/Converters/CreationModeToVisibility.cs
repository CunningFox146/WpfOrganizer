using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using WpfOrganizer.ViewModels;

namespace WpfOrganizer.Converters
{
    class CreationModeToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (value == null) ? Visibility.Visible : Visibility.Hidden;
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}

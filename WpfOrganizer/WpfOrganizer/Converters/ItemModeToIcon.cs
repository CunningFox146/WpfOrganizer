using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace WpfOrganizer.Converters
{
    class ItemModeToIcon : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new MaterialDesignThemes.Wpf.PackIcon { Kind = value == null ? MaterialDesignThemes.Wpf.PackIconKind.AlertCircle : MaterialDesignThemes.Wpf.PackIconKind.AddBold};
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new object();
        }
    }
}

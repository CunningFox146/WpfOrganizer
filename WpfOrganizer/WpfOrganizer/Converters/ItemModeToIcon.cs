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
            bool mode = (bool)value;
            return new MaterialDesignThemes.Wpf.PackIcon { Kind = mode ? MaterialDesignThemes.Wpf.PackIconKind.AddBold : MaterialDesignThemes.Wpf.PackIconKind.AlertCircle };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new object();
        }
    }
}

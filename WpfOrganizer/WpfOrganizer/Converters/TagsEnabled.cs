using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using WpfOrganizer.Models;
using WpfOrganizer.ViewModels;

namespace WpfOrganizer.Converters
{
    class TagsEnabled : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var Tags = value as ObservableCollection<Tag>;
            return (Tags != null && Tags.Count > 0) ? true : false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}

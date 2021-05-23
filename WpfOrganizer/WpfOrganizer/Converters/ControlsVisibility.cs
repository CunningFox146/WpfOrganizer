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
    abstract class ControlVisibility : IValueConverter
    {
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }

    class TagsHintVisibility : ControlVisibility
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tags = value as ObservableCollection<Tag>;
            return (tags != null && tags.Count > 0) ? Visibility.Collapsed : Visibility.Visible;
        }
    }

    class CheckListsVisibility : ControlVisibility
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var checkList = value as ObservableCollection<CheckList>;
            return (checkList != null && checkList.Count > 0) ? Visibility.Visible : Visibility.Collapsed;
        }
    }

    class ImagesVisibility : ControlVisibility
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var images = value as ObservableCollection<TaskImage>;
            return (images != null && images.Count > 0) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}

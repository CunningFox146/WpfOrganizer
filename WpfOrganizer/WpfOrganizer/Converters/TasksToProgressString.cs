using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using WpfOrganizer.Models;

namespace WpfOrganizer.Converters
{
    class TasksToProgressString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tasks = value as ObservableCollection<Task>;
            if (tasks == null || tasks.Count == 0) return "0/0";

            int completed = 0;

            foreach (Task task in tasks)
            {
                if (task.Checked) ++completed;
            }
            return $"{completed}/{tasks.Count}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}

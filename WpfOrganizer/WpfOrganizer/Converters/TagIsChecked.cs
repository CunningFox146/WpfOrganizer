using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using WpfOrganizer.Models;
using WpfOrganizer.ViewModels;

namespace WpfOrganizer.Converters
{
    class TagIsChecked : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var viewModel = value as MainViewModel;
            if (viewModel == null) return false;
            System.Diagnostics.Trace.WriteLine(parameter.ToString());
            return viewModel.SelectedTask.HasTag((Tag)parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isChecked = (bool)value;
            if (isChecked)
                MainViewModel.inst.SelectedTask.Tags.Add((Tag)parameter);
            else
                MainViewModel.inst.SelectedTask.Tags.Remove((Tag)parameter);

            return MainViewModel.inst;
        }
    }
}

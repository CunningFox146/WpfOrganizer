using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using WpfOrganizer.Models;

namespace WpfOrganizer.Converters
{
    class ListToPercent : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var list = (ObservableCollection<CheckListItem>)value;
            if (list == null) return 0;

            int checkedCount = 0;
            foreach (CheckListItem item in list)
            {
                if (item.Checked)
                    checkedCount++;
            }

            NumberFormatInfo setPrecision = new NumberFormatInfo() { NumberDecimalDigits = 1 };
            return (checkedCount / list.Count).ToString("N", setPrecision);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}

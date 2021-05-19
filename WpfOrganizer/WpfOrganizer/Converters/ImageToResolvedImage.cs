using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfOrganizer.Converters
{
    class ImageToResolvedImage : IValueConverter
    {
        const string errorImagePath = @"/WpfOrganizer;component/Resources/Images/image_load_failed.png";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string path = (string)value;

            BitmapImage img = new BitmapImage();

            if (path is null || !File.Exists(path))
            {
                img.BeginInit();
                img.UriSource = new Uri(errorImagePath, UriKind.Relative);
                img.EndInit();
                return img;
            }

            img.BeginInit();
            img.UriSource = new Uri(path, UriKind.Absolute);
            img.EndInit();
            return img;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

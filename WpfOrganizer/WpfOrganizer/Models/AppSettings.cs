using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfOrganizer.Models
{
    static class AppSettings
    {
        static public bool NotifyOn60 { get; set; } = true;
        static public bool NotifyOn15 { get; set; } = true;
        static public bool NotifyOn5 { get; set; } = true;
        static public bool NotifyOn1 { get; set; } = true;
        static public bool NotifyOnExpired { get; set; } = true;

        static private readonly PaletteHelper paletteHelper = new PaletteHelper();

        static public void ChangeTheme(Color color)
        {
            ITheme theme = paletteHelper.GetTheme();
            IBaseTheme baseTheme = (IBaseTheme)new MaterialDesignLightTheme();

            theme.SetBaseTheme(baseTheme);
            theme.SetPrimaryColor(color);

            paletteHelper.SetTheme(theme);
        }
    }
}

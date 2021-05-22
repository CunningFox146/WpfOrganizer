using WpfOrganizer.Util;
using System.Windows.Media;

namespace WpfOrganizer.Models
{
    class Tag : Notifyer
    {
        private string name;
        public string Name { get => name; set => Set(ref name, value); }

        private Color color;
        public Color Color { get => color; set { Set(ref color, value); System.Diagnostics.Trace.WriteLine("Color was set to" + Color.ToString()); } }

        private bool isChecked;
        public bool IsChecked { get => isChecked; set => Set(ref isChecked, value); }

        public Tag()
        {
            Color = Color.FromRgb(255, 0, 0);
        }
    }
}

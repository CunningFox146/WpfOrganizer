using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfOrganizer.Models;
using System.Windows.Media;

namespace WpfOrganizer.DataBase
{
    class DataBaseTag
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte? R { get; set; }
        public byte? G { get; set; }
        public byte? B { get; set; }

        static public Tag ToTag(DataBaseTag tag)
        {
            Color newColor;
            if (tag.R != null)
                newColor = Color.FromRgb((byte)tag.R, (byte)tag.G, (byte)tag.B);

            return new Tag()
            {
                Name = tag.Name,
                Color = newColor
            };
        }

        static public DataBaseTag ToDb(Tag tag)
        {
            if (tag == null) return null;
            return new DataBaseTag()
            {
                Name = tag.Name,
                R = tag != null ? tag.Color.R : null,
                G = tag != null ? tag.Color.G : null,
                B = tag != null ? tag.Color.B : null,
            };
        }
    }
}

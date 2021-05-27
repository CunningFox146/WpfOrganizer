using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfOrganizer.Models;

namespace WpfOrganizer.DataBase
{
    class DataBaseTag
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        static public Tag ToTag(DataBaseTag tag)
        {
            return new Tag()
            {
                Name = tag.Name,
                Color = System.Windows.Media.Color.FromRgb(tag.R, tag.G, tag.B)
            };
        }

        static public DataBaseTag ToDb(Tag tag)
        {
            return new DataBaseTag()
            {
                Name = tag.Name,
                R = tag.Color.R,
                G = tag.Color.G,
                B = tag.Color.B,
            };
        }
    }
}

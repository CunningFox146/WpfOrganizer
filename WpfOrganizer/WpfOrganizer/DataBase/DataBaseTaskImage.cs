using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfOrganizer.Models;

namespace WpfOrganizer.DataBase
{
    class DataBaseTaskImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }

        static public TaskImage ToTaskImage(DataBaseTaskImage image) => new TaskImage(image.ImageUrl);

        static public DataBaseTaskImage ToDb(TaskImage image)
        {
            return new DataBaseTaskImage()
            {
                ImageUrl = image.ImageUrl
            };
        }
    }
}

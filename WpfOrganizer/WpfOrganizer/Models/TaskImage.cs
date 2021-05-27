using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace WpfOrganizer.Models
{
    class TaskImage
    {
        public string ImageUrl { get; set; }

        public TaskImage(string path)
        {
            ImageUrl = path;
        }
    }
}


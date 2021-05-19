using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace WpfOrganizer.Models
{
    class TaskImage
    {
        public string ImageUrl { get; set; }
        public BitmapImage BitmapImage { get; set; } //Эээ... ваще не помню зачем оно тут но ладно!!!!!!! 3 часа заставлял работать так что ничего не меняеммм

        public TaskImage(string path)
        {
            ImageUrl = path;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfOrganizer.Util;

namespace WpfOrganizer.Models
{
    class User : Notifyer
    {
        private string name;
        public string Name { get => name; set => Set(ref name, value); }

        private string password;
        public string Password { get => password; set => Set(ref password, value); }

        private string imageUrl;
        public string ImageUrl { get => imageUrl; set => Set(ref imageUrl, value); }

        private TaskPicker taskPicker;
        public TaskPicker TaskPicker { get => taskPicker; set => Set(ref taskPicker, value); }

        public User()
        {
            TaskPicker = new TaskPicker();
            ImageUrl = @"/WpfOrganizer;component/Resources/Images/default_profile.png";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfOrganizer.Models;

namespace WpfOrganizer.DataBase
{
    class DataBaseUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DataBaseTaskPicker TaskPicker { get; set; }

        static public User ToUser(DataBaseUser user)
        {
            return new User()
            {
                Name = user.Name,
                Password = user.Password,
                TaskPicker = DataBaseTaskPicker.ToTaskPicker(user.TaskPicker)
            };
        }

        static public DataBaseUser ToDb(User user)
        {
            return new DataBaseUser()
            {
                Name = user.Name,
                Password = user.Password,
                TaskPicker = DataBaseTaskPicker.ToDb(user.TaskPicker)
            };
        }
    }
}

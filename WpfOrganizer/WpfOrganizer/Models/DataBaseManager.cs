using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WpfOrganizer.DataBase;

namespace WpfOrganizer.Models
{
    static class DataBasеManager
    {
        public static List<User> GetUsers()
        {
            var users = new List<User>();
            using (ApplicationContext db = new ApplicationContext())
            {
                var dbUsers = db.Users.Include(u=>u.TaskPicker);
                //var dbTaslPicker = 
                
                foreach (DataBaseUser dbUser in dbUsers)
                {
                    users.Add(DataBaseUser.ToUser(dbUser));
                }
            }

            return users;
        }
        
        // Невероятная архитектура говна: Загружаемся только при открытии, сохраняемся только при закрытии
        public static void Save()
        {
            var usersToSave = Users.Inst.RegisteredUsers;
            using (ApplicationContext db = new ApplicationContext())
            {
                var dbUsers = db.Users.ToList();
                foreach (var user in dbUsers)
                {
                    db.Users.Remove(user);
                }

                foreach (var user in usersToSave)
                {
                    db.Users.Add(DataBaseUser.ToDb(user));
                }

                db.SaveChanges();
            }
        }
    }
}

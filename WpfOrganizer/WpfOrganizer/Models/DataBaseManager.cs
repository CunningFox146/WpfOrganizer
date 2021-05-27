using System.Collections.Generic;
using System.Linq;
using WpfOrganizer.DataBase;

namespace WpfOrganizer.Models
{
    static class DataBaseManager
    {
        public static List<User> GetUsers()
        {
            var users = new List<User>();
            using (ApplicationContext db = new ApplicationContext())
            {
                var dbUsers = db.Users.ToList();
                
                foreach (DataBaseUser dbUser in dbUsers)
                {
                    users.Add(new User()
                    {
                        
                    });
                }
            }

            return users;
        }
    }
}

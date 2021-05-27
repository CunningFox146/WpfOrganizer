using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfOrganizer.Util;

namespace WpfOrganizer.Models
{
    class Users
    {
        private User currentUser;
        public User CurrentUser 
        { 
            get => currentUser; 
            set 
            {
                currentUser = value;
                OnUserChanged?.Invoke(currentUser);
            }
        }

        public delegate void UserChanged(User user);
        public event UserChanged OnUserChanged;

        private static Users instance;
        public static Users Inst
        {
            get => instance ?? (instance = new Users());
            set { }
        }

        public List<User> RegisteredUsers = new List<User>();

        public User CreateUser(string name, string password)
        {
            if (GetUserByName(name) != null)
                return null;

            var newUser = new User() { Name = name, Password = password };
            RegisteredUsers.Add(newUser);

            return newUser;
        }

        public User GetUserByName(string name)
        {
            foreach (var user in RegisteredUsers)
            {
                if (user.Name == name)
                    return user;
            }
            return null;
        }

        public User TryLogin(string name, string password)
        {
            var user = GetUserByName(name);
            return user != null && user.Password == password ? user : null;
        }

        public bool TryChangeNameForCurrentUser(string name)
        {
            if (GetUserByName(name) != null)
                return false;

            CurrentUser.Name = name;
            OnUserChanged?.Invoke(CurrentUser);
            return true;
        }

        public bool TryChangePasswordForCurrentUser(string password)
        {
            if (String.IsNullOrEmpty(password))
                return false;
            CurrentUser.Password = password;
            return true;
        }

        public void ChangeAvatarForCurrentUser(string url)
        {
            CurrentUser.ImageUrl = url;
            OnUserChanged?.Invoke(CurrentUser);
        }
    }
}

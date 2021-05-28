using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using WpfOrganizer.Models;

namespace WpfOrganizer.DataBase
{
    static class DataBaseManager
    {
        public static string Path = @"C:\Users\makar\Desktop\test.json";

        static public void Save()
        {
            var users = Users.Inst.RegisteredUsers;

            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            using (StreamWriter file = File.CreateText(Path))
            {
                file.Write(json);
            }
        }

        static public List<User> GetUsers()
        {
            try
            {
                using (StreamReader file = File.OpenText(Path))
                {
                    string json = file.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<User>>(json);
                }
            }
            catch { }
            return null;
        }
    }
}

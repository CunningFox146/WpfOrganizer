using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfOrganizer.DataBase
{
    class ApplicationContext : DbContext
    {
        public DbSet<DataBaseUser> Users { get; set; }
        public DbSet<DataBaseTaskPicker> TaskPickers { get; set; }
        public DbSet<DataBaseTaskData> TasksData { get; set; }
        public DbSet<DataBaseTask> Tasks { get; set; }
        public DbSet<DataBaseTaskImage> TaskImages { get; set; }
        public DbSet<DataBaseCheckList> CheckLists { get; set; }
        public DbSet<DataBaseCheckListItem> CheckListItems { get; set; }
        public DbSet<DataBaseTag> Tags { get; set; }

        //static private ApplicationContext instance;
        //static public ApplicationContext Inst
        //{
        //    get => instance ?? (instance = new ApplicationContext());
        //    set { }
        //}

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WpfOrganizer;Trusted_Connection=True;");
        }
    }
}

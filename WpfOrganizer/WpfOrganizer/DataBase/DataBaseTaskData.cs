using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WpfOrganizer.Models;

namespace WpfOrganizer.DataBase
{
    class DataBaseTaskData
    {
        public int Id { get; set; }
        public List<DataBaseTask> Tasks;
        public List<DataBaseTag> Tags;
        public DateTime Date;

        public static TaskData ToTaskData(DataBaseTaskData taskData)
        {
            var data = new TaskData()
            {
                Date = taskData.Date,
            };

            var tasks = new ObservableCollection<Task>();
            var tags = new ObservableCollection<Tag>();

            foreach(var item in taskData.Tasks)
            {
                tasks.Add(DataBaseTask.ToTask(item));
            }

            foreach(var item in taskData.Tags)
            {
                tags.Add(DataBaseTag.ToTag(item));
            }

            data.Tasks = tasks;
            data.Tags = tags;

            return data;
        }
        
        public static DataBaseTaskData ToDb(TaskData taskData)
        {
            var data = new DataBaseTaskData()
            {
                Date = taskData.Date,
            };

            var tasks = new List<DataBaseTask>();
            var tags = new List<DataBaseTag>();

            foreach(var item in taskData.Tasks)
            {
                tasks.Add(DataBaseTask.ToDb(item));
            }

            foreach(var item in taskData.Tags)
            {
                tags.Add(DataBaseTag.ToDb(item));
            }

            data.Tasks = tasks;
            data.Tags = tags;

            return data;
        }
    }
}

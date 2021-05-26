using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WpfOrganizer.Util;

namespace WpfOrganizer.Models
{
    class TaskData : Notifyer
    {
        private DateTime date;
        public DateTime Date { get => date; set => Set(ref date, value); }

        private ObservableCollection<Task> tasks;
        public ObservableCollection<Task> Tasks { get => tasks; set => Set(ref tasks, value); }

        private ObservableCollection<Tag> tags;
        public ObservableCollection<Tag> Tags { get => tags; set => Set(ref tags, value); }

        public TaskData()
        {
            Tasks = new ObservableCollection<Task>();
            Tags = new ObservableCollection<Tag>();
        }
    }

    class TaskPicker : Notifyer
    {
        private static TaskPicker instance;
        public static TaskPicker Inst
        {
            set { }
            get => instance ?? (instance = new TaskPicker());
        }

        private ObservableCollection<TaskData> tasks;
        public ObservableCollection<TaskData> Tasks { get => tasks; set => Set(ref tasks, value); }

        public TaskData GetTaskData(DateTime date)
        {
            foreach(TaskData task in Tasks)
            {
                if (task.Date == date)
                    return task;
            }

            var data = new TaskData();
            data.Date = date;
            Tasks.Add(data);

            return data;
        }

        private TaskPicker()
        {
            Tasks = new ObservableCollection<TaskData>();
        }
    }
}

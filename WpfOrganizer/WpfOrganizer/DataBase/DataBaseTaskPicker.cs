using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WpfOrganizer.Models;

namespace WpfOrganizer.DataBase
{
    class DataBaseTaskPicker
    {
        public int Id { get; set; }
        public List<DataBaseTaskData> Tasks;

        public static TaskPicker ToTaskPicker(DataBaseTaskPicker data)
        {
            if (data == null) return null;
            var newData = new TaskPicker();

            var list = new List<TaskData>();

            foreach (var item in data.Tasks)
            {
                list.Add(DataBaseTaskData.ToTaskData(item));
            }

            newData.Tasks = new ObservableCollection<TaskData>(list);

            return newData;
        }

        public static DataBaseTaskPicker ToDb(TaskPicker data)
        {
            if (data == null) return null;
            var newData = new DataBaseTaskPicker();

            var list = new List<DataBaseTaskData>();

            foreach (var item in data.Tasks)
            {
                list.Add(DataBaseTaskData.ToDb(item));
            }

            newData.Tasks = list;

            return newData;
        }
    }
}

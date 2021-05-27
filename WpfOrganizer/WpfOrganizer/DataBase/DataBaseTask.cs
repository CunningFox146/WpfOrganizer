using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfOrganizer.Models;

namespace WpfOrganizer.DataBase
{
    class DataBaseTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DataBaseTag Tag { get; set; }
        public bool Checked { get; set; }

        public bool DeadlineEnabled { get; set; }
        public DateTime? DeadlineTime { get; set; } = null;

        public List<DataBaseCheckList> CheckLists { get; set; }
        public List<DataBaseTaskImage> Images { get; set; }

        static public Task ToTask(DataBaseTask task)
        {
            var newTask = new Task()
            {
                Name = task.Name,
                Description = task.Description,
                Tag = DataBaseTag.ToTag(task.Tag),
                Checked = task.Checked,
                DeadlineEnabled = task.DeadlineEnabled,
                DeadlineTime = task.DeadlineTime,
            };

            var lists = new List<CheckList>();
            var images = new List<TaskImage>();

            foreach(var list in task.CheckLists)
            {
                lists.Add(DataBaseCheckList.ToCheckList(list));
            }

            foreach(var image in task.Images)
            {
                images.Add(DataBaseTaskImage.ToTaskImage(image));
            }

            newTask.SetCheckLists(lists);
            newTask.SetImages(images);

            return newTask;
        }

        static public DataBaseTask ToDb(Task task)
        {
            var newTask = new DataBaseTask()
            {
                Name = task.Name,
                Description = task.Description,
                Tag = DataBaseTag.ToDb(task.Tag),
                Checked = task.Checked,
                DeadlineEnabled = task.DeadlineEnabled,
                DeadlineTime = task.DeadlineTime,
            };

            var lists = new List<DataBaseCheckList>();
            var images = new List<DataBaseTaskImage>();

            foreach(var list in task.CheckLists)
            {
                lists.Add(DataBaseCheckList.ToDb(list));
            }

            foreach(var image in task.Images)
            {
                images.Add(DataBaseTaskImage.ToDb(image));
            }

            newTask.CheckLists = lists;
            newTask.Images = images;

            return newTask;
        }
    }
}

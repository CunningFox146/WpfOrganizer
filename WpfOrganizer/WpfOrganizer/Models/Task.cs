using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfOrganizer.Models
{
    class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Tag Tag { get; set; }
        public bool Checked { get; set; } = false;

        public ObservableCollection<CheckList> CheckLists { get; set; }
        public ObservableCollection<TaskImage> Images { get; set; }

        public Task()
        {
            CheckLists = new ObservableCollection<CheckList>();
            Images = new ObservableCollection<TaskImage>();
        }
    }
}

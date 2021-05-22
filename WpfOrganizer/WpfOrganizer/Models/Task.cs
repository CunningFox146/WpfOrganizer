using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfOrganizer.Util;

namespace WpfOrganizer.Models
{
    class Task : Notifyer
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ObservableCollection<Tag> tags;
        public ObservableCollection<Tag> Tags { get => tags; set => Set(ref tags, value); }

        public bool Checked { get; set; } = false;

        public ObservableCollection<CheckList> CheckLists { get; set; }
        public ObservableCollection<TaskImage> Images { get; set; }

        public Task()
        {
            CheckLists = new ObservableCollection<CheckList>();
            Images = new ObservableCollection<TaskImage>();
            Tags = new ObservableCollection<Tag>();
        }

        public bool HasTag(Tag tag) => Tags.Contains(tag);
    }
}

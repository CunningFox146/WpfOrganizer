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

        private Tag tag;
        public Tag Tag { get => tag; set => Set(ref tag, value); }

        public bool Checked { get; set; } = false;

        public ObservableCollection<CheckList> CheckLists { get; set; }
        public ObservableCollection<TaskImage> Images { get; set; }

        public Task()
        {
            CheckLists = new ObservableCollection<CheckList>();
            CheckLists.CollectionChanged += CheckLists_CollectionChanged;
            Images = new ObservableCollection<TaskImage>();
            Images.CollectionChanged += Images_CollectionChanged;
        }

        private void CheckLists_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("CheckLists");
        }

        private void Images_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("Images");
        }
    }
}

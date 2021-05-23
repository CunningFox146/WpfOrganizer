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

        private string name;
        public string Name { get => name; set => Set(ref name, value); }

        private string description;
        public string Description { get => description; set => Set(ref description, value); }

        private Tag tag;
        public Tag Tag { get => tag; set => Set(ref tag, value); }

        private bool isChecked = false;
        public bool Checked { get => isChecked; set => Set(ref isChecked, value); }

        public ObservableCollection<CheckList> CheckLists { get; set; }
        public ObservableCollection<TaskImage> Images { get; set; }

        private bool forCreation = false;
        public bool ForCreation { get => forCreation; set => Set(ref forCreation, value); }

        public Task()
        {
            CheckLists = new ObservableCollection<CheckList>();
            CheckLists.CollectionChanged += CheckLists_CollectionChanged;
            Images = new ObservableCollection<TaskImage>();
            Images.CollectionChanged += Images_CollectionChanged;
        }

        public bool IsValid() => !String.IsNullOrEmpty(Name);

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

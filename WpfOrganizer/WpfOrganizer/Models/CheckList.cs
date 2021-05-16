using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WpfOrganizer.Models
{
    class CheckListItem : INotifyPropertyChanged
    {
        private string name;
        public string Name { get=>name; set { name = value; OnPropertyChanged("Name"); } }

        private bool isChecked;
        public bool Checked { get=> isChecked; set { isChecked = value; OnPropertyChanged("Checked"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }

    class CheckList : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;
        public string Name { get => name; set { name = value; OnPropertyChanged("Name"); } }

        private List<CheckListItem> items;
        public List<CheckListItem> Items { get => items; set { items = value; OnPropertyChanged("Items"); } }

        public CheckList()
        {
            Items = new List<CheckListItem>();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}

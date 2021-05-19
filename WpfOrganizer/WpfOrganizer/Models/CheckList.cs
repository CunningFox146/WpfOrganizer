using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfOrganizer.Util;

namespace WpfOrganizer.Models
{
    class CheckListItem : Notifyer
    {
        private string name;
        public string Name { get => name; set => Set(ref name, value); }

        private bool isChecked;
        public bool Checked { get => isChecked; set => Set(ref isChecked, value); }
    }

    class CheckList : Notifyer
    {
        private string name;
        public string Name { get => name; set => Set(ref name, value); }

        private ObservableCollection<CheckListItem> items;
        public ObservableCollection<CheckListItem> Items { get => items; set => Set(ref items, value); }

        public CheckList()
        {
            Items = new ObservableCollection<CheckListItem>();
        }
    }
}

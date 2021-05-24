using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using WpfOrganizer.Util;

namespace WpfOrganizer.Models
{
    class CheckListItem : Notifyer
    {
        private string name;
        public string Name { get => name; set => Set(ref name, value); }

        private bool isChecked;
        public bool Checked { get => isChecked; set
            {
                Set(ref isChecked, value);
                OnItemChecked?.Invoke(value);
            }
        }

        // Для обновления % выполнения
        public delegate void ItemChecked(bool Checked);
        public event ItemChecked OnItemChecked;

        public CheckListItem(CheckList checkList)
        {
            OnItemChecked += checkList.OnItemChecked;
        }
    }

    class CheckList : Notifyer
    {
        private string name;
        public string Name { get => name; set => Set(ref name, value); }

        private ObservableCollection<CheckListItem> items;
        public ObservableCollection<CheckListItem> Items { get => items; set => Set(ref items, value); }

        private int percent;
        public int Percent { get => percent; set => Set(ref percent, value); }

        public CheckList()
        {
            Items = new ObservableCollection<CheckListItem>();
            Items.CollectionChanged += Items_CollectionChanged;

            OnItemChecked(false);
        }

        public void OnItemChecked(bool Checked)
        {
            int checkedCount = 0;
            foreach (CheckListItem item in Items)
            {
                if (item.Checked)
                    checkedCount++;
            }

            Percent = (int)(Items.Count != 0 ? ((double)checkedCount / (double)Items.Count * 100) : 0);
            try
            {
                System.Diagnostics.Trace.WriteLine($"{Percent}, {(checkedCount / Items.Count)}");
            }
            catch { }
            
        }

        private void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnItemChecked(false);
            OnPropertyChanged("Items");
        }
    }
}

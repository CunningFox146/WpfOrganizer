using System;
using System.Collections.Generic;
using System.Text;

namespace WpfOrganizer.Models
{
    class CheckListItem
    {
        public string Name { get; set; }
        public bool Checked { get; set; }
    }

    class CheckList
    {
        public string Name { get; set; }
        public List<CheckListItem> Items { get; set; }

        public CheckList()
        {
            Items = new List<CheckListItem>();
        }
    }
}

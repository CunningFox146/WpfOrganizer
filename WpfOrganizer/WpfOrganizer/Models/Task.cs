using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace WpfOrganizer.Models
{
    class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Checked { get; set; } = false;

        public List<CheckList> CheckLists { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Image> Images { get; set; }

        public Task()
        {
            CheckLists = new List<CheckList>();
            Tags = new List<Tag>();
            Images = new List<Image>();
        }
    }
}

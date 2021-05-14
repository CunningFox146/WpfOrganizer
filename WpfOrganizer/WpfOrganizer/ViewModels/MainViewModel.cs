using System;
using System.Collections.Generic;
using System.Text;

namespace WpfOrganizer.ViewModels
{
    class Item
    {
        public string Name { get; set; }
        public bool Finished { get; set; }
        //public bool Tag { get; set; }
    }
    class MainViewModel : ViewModel
    {
        public List<Item> ItemList { get; set; }

        public MainViewModel()
        {
            ItemList = new List<Item>();
            for(int i = 0; i < 20; i++)
            {
                ItemList.Add(new Item()
                {
                    Name = $"Item {i}",
                    Finished = i % 2 == 0
                });
            }
        }
    }
}

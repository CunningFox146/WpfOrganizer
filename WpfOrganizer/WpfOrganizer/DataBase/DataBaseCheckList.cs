using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfOrganizer.Models;

namespace WpfOrganizer.DataBase
{
    class DataBaseCheckList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DataBaseCheckListItem> Items { get; set; }

        static public CheckList ToCheckList(DataBaseCheckList list)
        {
            var checkList = new CheckList()
            {
                Name = list.Name,
            };

            var newItems = new List<CheckListItem>();
            foreach(var item in list.Items)
            {
                newItems.Add(DataBaseCheckListItem.ToCheckListItem(item, checkList));
            }

            checkList.SetItems(newItems);
            return checkList;
        }

        static public DataBaseCheckList ToDb(CheckList checkList)
        {
            var dbCheckList = new DataBaseCheckList()
            {
                Name = checkList.Name
            };

            var newItems = new List<DataBaseCheckListItem>();
            foreach (var item in checkList.Items)
            {
                newItems.Add(DataBaseCheckListItem.ToDb(item));
            }

            dbCheckList.Items = newItems;

            return dbCheckList;
        }
    }
}

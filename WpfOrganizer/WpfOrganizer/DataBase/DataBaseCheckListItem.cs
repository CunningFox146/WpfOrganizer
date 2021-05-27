using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfOrganizer.Models;

namespace WpfOrganizer.DataBase
{
    class DataBaseCheckListItem
    {
        public int Id { get; set; }
        public bool Checked { get; set; }
        public string Name { get; set; }

        public static CheckListItem ToCheckListItem(DataBaseCheckListItem item, CheckList checkList)
        {
            return new CheckListItem(checkList)
            {
                Checked = item.Checked,
                Name = item.Name,
            };
        }

        static public DataBaseCheckListItem ToDb(CheckListItem item)
        {
            return new DataBaseCheckListItem()
            {
                Checked = item.Checked,
                Name = item.Name,
            };
        }
    }
}

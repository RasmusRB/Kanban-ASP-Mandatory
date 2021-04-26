using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban.Models;

namespace Kanban.VMs
{
    public class BoardVm
    {
        public Board Board { get; set; }
        public List<Column> Columns { get; set; }
        public List<Item> ToDoItem { get; set; }
        public List<Item> DoingItem { get; set; }
        public List<Item> DoneItem { get; set; }
        public string BoardName { get; set; }
    }
}

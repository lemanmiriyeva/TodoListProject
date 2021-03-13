using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListProject.Data;

namespace TodoListProject.Models
{
    public class ListViewModel
    {
        public List<ToDoList> Lists { get; set; }
        public string key { get; set; }
        public ToDoList ToDoList { get; set; }

    }
}

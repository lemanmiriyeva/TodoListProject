using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListProject.Data;

namespace TodoListProject.Helpers
{
    public interface IToDoSessionHelper
    {
        List<ToDoList> Get(string key);
        void Set(string key, List<ToDoList> toDoList);
        void Clear();
    }
}

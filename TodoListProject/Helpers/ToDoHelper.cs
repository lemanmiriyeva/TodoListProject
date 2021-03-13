using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TodoListProject.Data;
using TodoListProject.Extensions;

namespace TodoListProject.Helpers
{
    public class ToDoHelper:IToDoSessionHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ToDoHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<ToDoList> Get(string key)
        {
            var cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<List<ToDoList>>(key);
            if (cartToCheck == null)
            {
                Set(key, new List<ToDoList>());
                cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<List<ToDoList>>(key);
            }

            return cartToCheck;
        }


        public void Set(string key, List<ToDoList>toDoLists)
        {
            _httpContextAccessor.HttpContext.Session.SetObject(key,toDoLists);
        }


        public void Clear()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }
    
}
}

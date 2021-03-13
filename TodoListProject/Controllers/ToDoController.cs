using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoListProject.Data;
using TodoListProject.Helpers;
using TodoListProject.Models;

namespace TodoListProject.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoSessionHelper _toDoSessionHelper;

        public ToDoController(IToDoSessionHelper toDoSessionHelper)
        {
            _toDoSessionHelper = toDoSessionHelper;
        }

        public IActionResult List(string key)
        {
            if (key==null)
            {
                key = "";
            }
            var todolist = _toDoSessionHelper.Get("ToDoList").Where(n=>n.ActionName.Contains(key));
            

            
            var model = new ListViewModel()
            {
                Lists = todolist.ToList()
            };
            return View(model);


        }
        [HttpPost]
        public IActionResult Add(ToDoList toDoList)
        {
            var todolist = _toDoSessionHelper.Get("ToDoList");
            toDoList.Id = todolist.Count + 1;
            if (toDoList.ActionName == null)
            {
                TempData.Add("message", "Lütfen,Todo ekleyin!");
                TempData.Add("className","danger");
            }
            else if (todolist.Any(n => n.ActionName == toDoList.ActionName))
            {
                TempData.Add("message", "Lütfen,başka bir Todo ekleyin!");
                TempData.Add("className", "danger");
            }
            else
            {
                todolist.Add(toDoList);
                _toDoSessionHelper.Set("ToDoList", todolist);
                TempData.Add("message", $"{toDoList.ActionName} eklendi!");
                TempData.Add("className", "success");

            }

            return RedirectToAction("List","ToDo");
        }
        
        public IActionResult Delete(int id,ToDoList toDoList)
        {
            var todolist = _toDoSessionHelper.Get("ToDoList");
            
            var element = todolist.FirstOrDefault(n => n.Id == id);
            todolist.Remove(element);
            _toDoSessionHelper.Set("ToDoList", todolist);
            TempData.Add("message",$"{element.ActionName} silindi!");
            TempData.Add("className", "success");
            return RedirectToAction("List", "ToDo");
        }

        public IActionResult Clear()
        {
            _toDoSessionHelper.Clear();
            return RedirectToAction("List", "ToDo");
        }
    }
}


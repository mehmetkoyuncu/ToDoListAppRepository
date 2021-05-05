using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApp.Service.WebAPI.Core.Abstract;
using ToDoListApp.Service.WebAPI.Entities;

namespace ToDoListApp.Service.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TaskController : Controller
    {
        ITaskService _service;
        public TaskController(ITaskService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult AddTask(MyTask task)
        {
            return Ok(_service.Add(task));
        }
        [HttpDelete]
        public IActionResult RemoveTask(MyTask task)
        {
            return Ok(_service.Remove(task.Id));
        }
        [HttpGet]
        public IActionResult GetAllTask()
        {
            return Ok(_service.GetList());
        }
        [HttpPost]
        public IActionResult GetTask(MyTask task)
        {
            return Ok(_service.GetSingle(task.Id));
        }
        [HttpPost]
        public IActionResult UpdateTask(MyTask task)
        {
            return Ok(_service.Update(task));
        }
        [HttpPost]
        public IActionResult CompleteTask(MyTask task)
        {
            return Ok(_service.CompleteTask(task.Id));
        }
        
   

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApp.Service.WebAPI.Entities;

namespace ToDoListApp.Service.WebAPI.Core.Abstract
{
    public interface ITaskService
    {
        bool Add(MyTask entity);
        bool Remove(int id);
        bool Update(MyTask entity);
        List<MyTask> GetList();
        MyTask GetSingle(int id);
        bool CompleteTask(int id);
    }
}

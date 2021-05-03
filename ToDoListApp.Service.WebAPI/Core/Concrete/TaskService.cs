using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApp.Service.WebAPI.Core.Abstract;
using ToDoListApp.Service.WebAPI.Data.Context.EfCore;
using ToDoListApp.Service.WebAPI.Data.Repository.Abstract;
using ToDoListApp.Service.WebAPI.Data.Repository.Concrete;
using ToDoListApp.Service.WebAPI.Entities;

namespace ToDoListApp.Service.WebAPI.Core.Concrete
{
    public class TaskService : ITaskService
    {
        IRepository<MyTask,ToDoListContext> _repo=new Repository<MyTask,ToDoListContext>(new ToDoListContext());
        public bool Add(MyTask entity)
        {
            if (string.IsNullOrEmpty(entity.TaskDateString))
            {
                entity.TaskDate = DateTime.Now;
            }
            else
            {
                entity.TaskDate = Convert.ToDateTime(entity.TaskDateString);
            }
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
           return _repo.Add(entity);
        }
        public List<MyTask> GetList()
        {
            List<MyTask> taskList = _repo.GetList(x => x.IsDelete == false).ToList();
            foreach (var item in taskList)
            {
                item.CreatedString = item.CreatedAt.ToString();
                item.UpdateString = item.UpdatedAt.ToString();
                item.TaskDateString = item.TaskDate.ToString();
            }
            
            return taskList;
        }
        public MyTask GetSingle(int id)
        {
            MyTask task = _repo.GetSingle(x => x.Id == id);
            task.TaskDateString = task.TaskDate.ToString();
            return task;
        }
        public bool Remove(int id)
        {
            MyTask task= _repo.GetSingle(x => x.Id == id);
            task.IsDelete = true;
            task.UpdatedAt = DateTime.Now;
            return _repo.Remove(task);

        }
        public bool Update(MyTask entity)
        {
            int id = entity.Id;
            MyTask task = _repo.GetSingle(x => x.Id == id);
            task.TaskTitle = entity.TaskTitle;
            task.TaskContent = entity.TaskContent;
            if (string.IsNullOrEmpty(entity.TaskDateString))
            {
                task.TaskDate = DateTime.Now;
            }
            else
            {
                task.TaskDate = Convert.ToDateTime(entity.TaskDateString);
            }
            task.UpdatedAt = DateTime.Now;
            return _repo.Update(task);
        }
        public bool CompleteTask(int id)
        {
            MyTask task = _repo.GetSingle(x => x.Id == id);
            task.IsDone = true;
            task.UpdatedAt = DateTime.Now;
            return _repo.Update(task);
        }
        public bool RemindTask(int id)
        {
            MyTask task = _repo.GetSingle(x => x.Id == id);
            task.IsRemind = true;
            task.UpdatedAt = DateTime.Now;
            return _repo.Update(task);
        }
    }
}

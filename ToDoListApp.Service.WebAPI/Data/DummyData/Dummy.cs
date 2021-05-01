using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApp.Service.WebAPI.Entities;

namespace ToDoListApp.Service.WebAPI.Data.DummyData
{
    public class Dummy
    {
        public List<MyTask> Tasks { get; set; }
        public Dummy()
        {
            Tasks = new List<MyTask>() {
            new MyTask
            {
                Id = 1,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsDelete = false,
                TaskContent = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
                "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer" +
                " took a galley of type and scrambled it to make a type specimen book.",
                TaskTitle = "Lorem Ipsum",
                IsDone = true,
                TaskDate = DateTime.Now
            },
            new MyTask
            {
                Id = 2,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsDelete = false,
                TaskContent = "Contrary to popular belief, Lorem Ipsum is not simply random text." +
                " It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.",
                TaskTitle = "Contrary to popular",
                IsDone = false,
                TaskDate = DateTime.Now
            },
            new MyTask
            {
                Id = 3,
                CreatedAt = new DateTime(2020,05,06),
                UpdatedAt = new DateTime(2020,12,20),
                IsDelete = false,
                TaskContent = "Contrary to popular belief, Lorem Ipsum is not simply random text." +
                " It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.",
                TaskTitle = "Contrary to popula",
                IsDone = true,
                TaskDate = new DateTime(2021,01,01)
            },
             new MyTask
            {
                Id = 4,
                CreatedAt = DateTime.Now.AddYears(-1),
                UpdatedAt = DateTime.Now.AddYears(-1).AddMonths(1),
                IsDelete = true,
                TaskContent = "There are many variations of passages of Lorem Ipsum available," +
                " but the majority have suffered alteration in some form, by injected humour, or randomised " +
                "words which don't look even slightly believable. If you are going to use a passage of Lorem " +
                "Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text.",
                TaskTitle = "There are many variations",
                IsDone = true,
                TaskDate = DateTime.Now
            },
              new MyTask
            {
                Id = 5,
                CreatedAt = DateTime.Now.AddYears(-3),
                UpdatedAt = DateTime.Now.AddYears(-2).AddMonths(2).AddDays(15),
                IsDelete = false,
                TaskContent = "There are many variations of passages of Lorem Ipsum available," +
                " but the majority have suffered alteration in some form, by injected humour, or randomised " +
                "words which don't look even slightly believable. If you are going to use a passage of Lorem " +
                "Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text.",
                TaskTitle = "There are many variations",
                IsDone = false,
                TaskDate = DateTime.Now
            },
            };
        }
    }
}

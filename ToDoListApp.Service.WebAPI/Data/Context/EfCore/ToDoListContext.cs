using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApp.Service.WebAPI.Data.DummyData;
using ToDoListApp.Service.WebAPI.Entities;

namespace ToDoListApp.Service.WebAPI.Data.Context.EfCore
{
    public class ToDoListContext:DbContext
    {
        public DbSet<MyTask> MyTasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ToDoListAppDB;Integrated Security=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Dummy data = new Dummy();
            modelBuilder.Entity<MyTask>().HasData(data.Tasks);
        }
    }
}


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
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=ToDoListDB;Integrated Security=true; User Id=postgres;Password=7973153.mK;");
        }
        Dummy datas = new Dummy();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyTask>().ToTable("Tasks", "public");
            modelBuilder.Entity<MyTask>().HasData(datas.Tasks);
           
        }
    }
}

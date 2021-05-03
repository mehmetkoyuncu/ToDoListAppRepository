using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApp.Service.WebAPI.Entities.Abstract;

namespace ToDoListApp.Service.WebAPI.Entities
{
    public class MyTask:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string TaskTitle { get; set; }
        public string TaskContent { get; set; }
        public bool IsDone { get; set; }
        public bool IsDelete { get; set; }
        public bool IsRemind { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime TaskDate { get; set; }
        [NotMapped]
        public string UpdateString { get; set; }
        [NotMapped]
        public string CreatedString { get; set; }
        [NotMapped]
        public string TaskDateString { get; set; }
    }
}

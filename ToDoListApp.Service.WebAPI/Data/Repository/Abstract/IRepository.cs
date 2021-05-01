using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDoListApp.Service.WebAPI.Entities;
using ToDoListApp.Service.WebAPI.Entities.Abstract;

namespace ToDoListApp.Service.WebAPI.Data.Repository.Abstract
{
    public interface IRepository<TEntity,TContext> 
        where TEntity:class,IEntity,new()
        where TContext:DbContext
    {
        bool Add(TEntity entity);
        bool Remove(TEntity entity);
        bool Update(TEntity entity);
        IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> filter);
        TEntity GetSingle(Func<TEntity, bool> filter);
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDoListApp.Service.WebAPI.Data.Repository.Abstract;
using ToDoListApp.Service.WebAPI.Entities;
using ToDoListApp.Service.WebAPI.Entities.Abstract;

namespace ToDoListApp.Service.WebAPI.Data.Repository.Concrete
{
    public class Repository<TEntity, TContext> : IRepository<TEntity, TContext>
        where TEntity : class, IEntity, new()
        where TContext : DbContext
    {
        DbSet<TEntity> _dbSet;
        TContext _context;
        public Repository(TContext context)
        {
            _dbSet = context.Set<TEntity>();
            _context = context;
        }
        public bool Add(TEntity entity)
        {
            bool condition = false;
            _dbSet.Add(entity);
            int result= _context.SaveChanges();
            if (result > 0)
            {
                condition = true;
            }
            return condition;
        }

        public IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Where(filter);
        }

        public TEntity GetSingle(Func<TEntity, bool> filter)
        {
            return _dbSet.FirstOrDefault(filter);
        }

        public bool Remove(TEntity entity)
        {
            bool condition = false;
            _dbSet.Update(entity);
            int result = _context.SaveChanges();
            if (result > 0)
            {
                condition = true;
            }
            return condition;
        }

        public bool Update(TEntity entity)
        {
            bool condition = false;
            _dbSet.Update(entity);
            int result = _context.SaveChanges();
            if (result > 0)
            {
                condition = true;
            }
            return condition;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using DAL.Interfaces;


namespace DAL.Repositories
{
    public abstract class MyProjectRepository<T> : IRepository<T> where T : class
    {
        private readonly IDbContext context;
        private readonly IDbSet<T> dbSet;

        protected MyProjectRepository(IDbContext ctx, Func<IDbContext, IDbSet<T>> dbSetSelector)
        {
            context = ctx;
            dbSet = dbSetSelector(context);
        }

        public void Insert(T entity)
        {
            if (entity != null)
            {
                dbSet.Add(entity);
            }
            else
            {
                throw new Exception();
            }
        }

        public void Delete(int id)
        {
            var entity = dbSet.Find(id);
            if (entity != null)
            {
                dbSet.Attach(entity);
                dbSet.Remove(entity);
            }
            else
            {
                throw new Exception();
            }
        }

        public void Update(T entity)
        {
            if (entity != null)
            {
                dbSet.Attach(entity);
                context.Flag(entity);
            }
        }

        public T Get(int id)
        {
            var entity = dbSet.Find(id);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                throw new Exception();
            }
        }

        public IEnumerable<T> GetAll()
        {
            var entities = dbSet;
            if (entities != null)
            {
                return entities;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
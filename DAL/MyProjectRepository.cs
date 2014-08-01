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
        internal IDbContext Context;
        internal IDbSet<T> DbSet;

        protected MyProjectRepository(IDbContext context, Func<IDbContext, IDbSet<T>> dbSetSelector)
        {
            Context = context;
            DbSet = dbSetSelector(context);
        }

        public void Insert(T entity)
        {
            if (entity != null)
            {
                DbSet.Add(entity);
            }
            else
            {
                throw new Exception();
            }
        }

        public void Delete(int id)
        {
            var entity = DbSet.Find(id);
            if (entity != null)
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
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
                DbSet.Attach(entity);
                Context.Flag(entity);
            }
        }

        public T Get(int id)
        {
            var entity = DbSet.Find(id);
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
            var entities = DbSet;
            if (entities != null)
            {
                return entities;
            }
            else
            {
                throw new Exception();
            }
        }

        public void Save()
        {
            Context.SaveAll();
        }
    }
}
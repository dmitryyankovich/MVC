using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using DAL.Interfaces;


namespace DAL.Repositories
{
    public class MyProjectRepository<T> : IRepository<T> where T : class
    {
        private IDbSet<T> DbSet;

        public MyProjectRepository(IDbSet<T> dbSet)
        {
            DbSet = dbSet;
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
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
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
            DbSet.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = DbSet.Find(id);
            DbSet.Attach(entity);
            DbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            DbSet.Attach(entity);
            Context.Flag(entity);
        }

        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet;
        }

        public void Save()
        {
            Context.SaveAll();
        }
    }
}
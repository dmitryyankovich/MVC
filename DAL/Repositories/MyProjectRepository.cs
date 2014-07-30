using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myProject.Models;

namespace myProject.DAL
{
    public class MyProjectRepository<T> : IRepository<T> where T:class
    {
        internal ApplicationDbContext context;
        internal DbSet<T> dbSet;

        public MyProjectRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = dbSet.Find(id);
            dbSet.Attach(entity);
            dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

       public void Save()
       {
           context.SaveChanges();
       }
    }
}
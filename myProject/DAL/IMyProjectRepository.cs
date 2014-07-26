﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myProject.DAL
{
    public interface IMyProjectRepository<T> where T:class
    {
        void Insert(T entity);
        void Delete(int id);
        void Update(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Save(); //???
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Insert(T entity);
        void Delete(int id);
        void Update(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
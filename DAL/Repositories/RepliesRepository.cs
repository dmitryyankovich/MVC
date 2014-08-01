﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    public class RepliesRepository : MyProjectRepository<Replies>
    {
        public RepliesRepository(IDbContext context)
            : base(context, m => m.Replies)
        {
        }
    }
}

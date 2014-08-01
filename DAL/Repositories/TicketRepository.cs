﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    public class TicketRepository : MyProjectRepository<Ticket>
    {
        public TicketRepository(IDbContext context)
            : base(context, m => m.Tickets)
        {
        }
    }
}

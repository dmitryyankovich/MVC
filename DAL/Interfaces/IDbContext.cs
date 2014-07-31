using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IDbContext
    {
        IDbSet<User> Users { get; set; }
        IDbSet<Ticket> Tickets { get; set; }
        IDbSet<Languages> Languages { get; set; }
        IDbSet<Replies> Replies { get; set; }

        void SaveAll();
        void Flag(object entity);
    }
}

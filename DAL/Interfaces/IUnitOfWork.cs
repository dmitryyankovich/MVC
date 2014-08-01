using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<User> UserRepository { get; }
        IRepository<Ticket> TicketRepository { get; }
        IRepository<Languages> LanguagesRepository { get; }
        IRepository<Replies> RepliesRepository { get; }
        IDbContext Context { get; }
        void Commit();
    }
}

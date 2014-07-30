using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myProject.Models;

namespace myProject.DAL
{
    interface IUnitOfWork : IDisposable
    {
        IRepository<User> UserRepository { get; }
        IRepository<Ticket> TicketRepository { get; }
        IRepository<Languages> LanguagesRepository { get; }
        IRepository<Replies> RepliesRepository { get; }
        void Commit();
    }
}

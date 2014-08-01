using System.Data.Entity;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IDbContext
    {
        IDbSet<User> Users { get; set; }
        IDbSet<Ticket> Tickets { get; set; }
        IDbSet<Languages> Languages { get; set; }
        IDbSet<Replies> Replies { get; set; }

        void Flag(object entity);
        void SaveAll();
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO.Interfaces;
using BO.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BO.Models
{
    public class DbContext : IdentityDbContext<User, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim> , IDbContext
    {
        public DbContext()
            : base("DefaultConnection")
        {
        }
        public IDbSet<Ticket> Tickets { get; set; }
        public IDbSet<Languages> Languages { get; set; }
        public IDbSet<Replies> Replies { get; set; }

        public void Flag(object entity)
        {
            Entry(entity).State = EntityState.Modified;;
        }

        public void SaveAll()
        {
            base.SaveChanges();
        }
    }
}

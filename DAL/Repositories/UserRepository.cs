using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO.Interfaces;
using BO.Models;
using BO.Repositories;

namespace DAL.Repositories
{
    public class UserRepository : MyProjectRepository<User>
    {
        public UserRepository(IDbContext context) : base(context, m => m.Users)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myProject.DAL
{
    interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}

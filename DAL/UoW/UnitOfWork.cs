using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myProject.Models;

namespace myProject.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private bool isDisposed;
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Ticket> ticketRepository;
        private readonly IRepository<Languages> languagesRepository;
        private readonly IRepository<Replies> repliesRepository;

        public UnitOfWork() { }

        public UnitOfWork(IRepository<User> userRepInstance, IRepository<Ticket> ticketRepInstance,
            IRepository<Languages> languageRepInstance, IRepository<Replies> repliesRepInstance)
        {
            userRepository = userRepInstance;
            ticketRepository = ticketRepInstance;
            languagesRepository = languageRepInstance;
            repliesRepository = repliesRepInstance; 
        }

        public IRepository<User> UserRepository
        {
            get { return userRepository; }
        }

        public IRepository<Ticket> TicketRepository
        {
            get { return ticketRepository; }
        }

        public IRepository<Languages> LanguagesRepository
        {
            get { return languagesRepository; }
        }

        public IRepository<Replies> RepliesRepository
        {
            get { return repliesRepository; }
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            isDisposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
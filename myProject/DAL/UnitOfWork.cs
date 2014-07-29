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
        private MyProjectRepository<User> userRepository;
        private MyProjectRepository<Ticket> ticketRepository;
        private MyProjectRepository<Replies> repliesRepository;

        public MyProjectRepository<User> UserRepository
        {
            get 
            {
                if (userRepository == null)
                {
                    userRepository = new MyProjectRepository<User>(context);
                }
                return userRepository;
            }
        }

        public MyProjectRepository<Ticket> TicketRepository
        {
            get 
            { 
                if (ticketRepository == null)
                {
                    ticketRepository = new MyProjectRepository<Ticket>(context);
                }
                return ticketRepository;
            }
        }

        public MyProjectRepository<Replies> RepliesRepository
        {
            get
            {
                if (repliesRepository == null)
                {
                    repliesRepository = new MyProjectRepository<Replies>(context);
                }
                return repliesRepository;
            }
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
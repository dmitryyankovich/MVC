using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myProject.Models;

namespace myProject.DAL
{
    public class UnitOfWork
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private MyProjectRepository<User> userRepository;
        private MyProjectRepository<Ticket> ticketRepository;
        private MyProjectRepository<Languages> languageRepository;
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

        public MyProjectRepository<Languages> LanguageRepository
        {
            get
            {
                if (languageRepository == null)
                {
                    languageRepository = new MyProjectRepository<Languages>(context);
                }
                return languageRepository;
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

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
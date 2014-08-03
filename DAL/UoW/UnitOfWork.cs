using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;


namespace DAL.UoW
{
    public class UnitOfWork : IdentityDbContext<User, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>, IUnitOfWork
    {

        public UnitOfWork()
            : base("DefaultConnection")
        {

        }

        private MyProjectRepository<User> userRepository;
        private MyProjectRepository<Ticket> ticketRepository;
        private MyProjectRepository<Languages> languagesRepository;
        private MyProjectRepository<Replies> repliesRepository;
        private MyProjectRepository<Feedback> feedbackRepository;

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Languages> Languages { get; set; }
        public DbSet<Replies> Replies { get; set; }
        public DbSet<Feedback> Feedback { get; set; }

        public IRepository<User> UserRepository
        {
            get { return userRepository ?? (userRepository = new MyProjectRepository<User>(Users)); }
        }

        public IRepository<Ticket> TicketRepository
        {
            get { return ticketRepository ?? (ticketRepository = new MyProjectRepository<Ticket>(Tickets)); }
        }

        public IRepository<Languages> LanguagesRepository
        {
            get { return languagesRepository ?? (languagesRepository = new MyProjectRepository<Languages>(Languages)); }
        }

        public IRepository<Replies> RepliesRepository
        {
            get { return repliesRepository ?? (repliesRepository = new MyProjectRepository<Replies>(Replies)); }
        }

        public IRepository<Feedback> FeedbackRepository
        {
            get { return feedbackRepository ?? (feedbackRepository = new MyProjectRepository<Feedback>(Feedback)); }
        }

        public void Commit()
        {
            SaveChanges();
        }
    }
}
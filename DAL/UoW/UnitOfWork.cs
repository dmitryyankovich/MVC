using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IRepository<Languages> _languagesRepository;
        private readonly IRepository<Replies> _repliesRepository;

        public UnitOfWork(IRepository<User> userRepInstance, IRepository<Ticket> ticketRepInstance,
            IRepository<Languages> languageRepInstance, IRepository<Replies> repliesRepInstance, IDbContext contextInstance)
        {
            _context = contextInstance;
            _userRepository = userRepInstance;
            _ticketRepository = ticketRepInstance;
            _languagesRepository = languageRepInstance;
            _repliesRepository = repliesRepInstance;
        }

        public IRepository<User> UserRepository
        {
            get { return _userRepository; }
        }

        public IRepository<Ticket> TicketRepository
        {
            get { return _ticketRepository; }
        }

        public IRepository<Languages> LanguagesRepository
        {
            get { return _languagesRepository; }
        }

        public IRepository<Replies> RepliesRepository
        {
            get { return _repliesRepository; }
        }

        public IDbContext Context
        {
            get { return _context; }
        }

        public void Commit()
        {
            _context.SaveAll();
        }
    }
}
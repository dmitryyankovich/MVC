using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;


namespace DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;
        private readonly UserRepository _userRepository;
        private readonly TicketRepository _ticketRepository;
        private readonly LanguagesRepository _languagesRepository;
        private readonly RepliesRepository _repliesRepository;

        public UnitOfWork(UserRepository userRepInstance, TicketRepository ticketRepInstance,
            LanguagesRepository languageRepInstance, RepliesRepository repliesRepInstance, IDbContext contextInstance)
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
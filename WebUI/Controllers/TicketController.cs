using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private const int ticketsPerPage = 5;
        private readonly IUnitOfWork _unitOfWork;

        public TicketController(IUnitOfWork uowInstance)
        {
            _unitOfWork = uowInstance;
        }

        // GET: Ticket
        public ActionResult UserTickets(int withReply = 0)
        {
            var tickets = _unitOfWork.UserRepository.Get(Int32.Parse(User.Identity.GetUserId())).Tickets.ToList();
            if (withReply != 0)
            {
                tickets = tickets.FindAll(m => m.Reply != null);
            }
            var ticketsView = new List<TicketViewModel>();
            foreach (Ticket ticket in tickets)
            {
                ticketsView.Add(Mapper.DynamicMap<TicketViewModel>(ticket));
            }
            return PartialView(ticketsView);
        }

        [AllowAnonymous]
        public ActionResult Tickets(int sort = 0, int pageNum = 0)
        {
            var tickets = _unitOfWork.TicketRepository.GetAll();
            if (sort != 0)
            {
                tickets = tickets.OrderBy(s => s.TypeOfTicket);
            }
            int ticketCount = tickets.Count();
            tickets = tickets.Skip(ticketsPerPage * pageNum).Take(ticketsPerPage);
            int ticketsPageNum = 0;
            ticketsPageNum = ticketCount % ticketsPerPage != 0 ? (ticketCount / ticketsPerPage + 1) : ticketCount / ticketsPerPage;
            var ticketsView = new List<ShowTicketsViewModel>();
            foreach (Ticket ticket in tickets)
            {
                ticketsView.Add(Mapper.DynamicMap<ShowTicketsViewModel>(ticket));
            }
            ticketsView[0].NumberOfPages = ticketsPageNum;
            ticketsView[0].ToSort = sort;
            ticketsView[0].CurrentPage = pageNum;
            return View(ticketsView);
        }


        [HttpPost]
        public ActionResult Tickets(string country, string city)
        {
            var tickets = _unitOfWork.TicketRepository.GetAll()
                .Where(m => m.User.City.Contains(city))
                .Where(m => m.User.Country.Contains(country));
            var ticketsView = new List<ShowTicketsViewModel>();
            foreach (Ticket ticket in tickets)
            {
                ticketsView.Add(Mapper.DynamicMap<ShowTicketsViewModel>(ticket));
            }
            return View(ticketsView); 
        }

        // GET: Ticket/Details/5
        public ActionResult Details(int id)
        {
            Ticket ticket = _unitOfWork.TicketRepository.Get(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            var ticketView = Mapper.DynamicMap<TicketViewModel>(ticket);
            return View(ticketView);
        }

        // GET: Ticket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ticket/Create
        [HttpPost]
        public ActionResult Create(TicketViewModel ticketViewModel)
        {
            if (ModelState.IsValid)
            {
                ticketViewModel.UserId = _unitOfWork.UserRepository.Get(Int32.Parse(User.Identity.GetUserId())).Id;
                var ticket = Mapper.DynamicMap<Ticket>(ticketViewModel);
                _unitOfWork.TicketRepository.Insert(ticket);
                _unitOfWork.Commit();
                return RedirectToAction("Tickets");
            }
            return View();
        }

        // GET: Ticket/Edit/5
        public ActionResult Edit(int id)
        {
            Ticket ticket = _unitOfWork.TicketRepository.Get(id);
            var ticketView = Mapper.DynamicMap<TicketViewModel>(ticket);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticketView);
        }

        // POST: Ticket/Edit/5
        [HttpPost]
        public ActionResult Edit(TicketViewModel ticketViewModel)
        {
            if (ModelState.IsValid)
            {
                var ticket = Mapper.DynamicMap<Ticket>(ticketViewModel);
                _unitOfWork.TicketRepository.Update(ticket);
                _unitOfWork.Commit();
                return RedirectToAction("Tickets");
            }
            return View();

        }

        // GET: Ticket/Delete/5
        public ActionResult Delete(int id)
        {
            Ticket ticket = _unitOfWork.TicketRepository.Get(id);
            var ticketView = Mapper.DynamicMap<TicketViewModel>(ticket);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticketView);
        }

        // POST: Ticket/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            _unitOfWork.TicketRepository.Delete(id);
            _unitOfWork.Commit();
            return RedirectToAction("Tickets");
        }
    }
}

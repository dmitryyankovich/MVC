using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO.Interfaces;
using BO.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using myProject.Models;

namespace myProject.Controllers
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
        public ActionResult UserTickets()
        {
            var tickets = _unitOfWork.UserRepository.Get(Int32.Parse(User.Identity.GetUserId())).Tickets.ToList();
            return PartialView(tickets.ToList());
        }

        [AllowAnonymous]
        public ActionResult Tickets(int sort = 0, int pageNum = 0)
        {
            IEnumerable<Ticket> tickets;
            if (sort == 0)
            {
                tickets = _unitOfWork.TicketRepository.GetAll();
            }
            else
            {
                tickets = _unitOfWork.TicketRepository.GetAll();
                tickets = tickets.OrderBy(s => s.TypeOfTicket);
            }
            int ticketCount = tickets.Count();
            tickets = tickets.Skip(ticketsPerPage * pageNum).Take(5);
            int ticketsPageNum = 0;
            ticketsPageNum = ticketCount % ticketsPerPage != 0 ? (ticketCount / 5 + 1) : ticketCount / 5;
            ViewData["TicketsPageNum"] = ticketsPageNum;
            ViewData["ToSort"] = sort;
            ViewData["CurrentPage"] = pageNum;
            return View(tickets.ToList());
        }


        // GET: Ticket/Details/5
        public ActionResult Details(int id)
        {
            Ticket ticket = _unitOfWork.TicketRepository.Get(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Ticket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ticket/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,UserId,Title,Content,TypeOfTicket,Logo")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.UserId = _unitOfWork.UserRepository.Get(Int32.Parse(User.Identity.GetUserId())).Id;
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
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Ticket/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,UserId,Title,Content,TypeOfTicket,Logo")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
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
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
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

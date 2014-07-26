using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using myProject.DAL;
using myProject.Models;

namespace myProject.Controllers
{
    public class TicketController : Controller
    {

        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        // GET: Ticket
        public ActionResult UserTickets()
        {
            var tickets = _unitOfWork.UserRepository.Get(Int32.Parse(User.Identity.GetUserId())).Tickets.ToList();
            return PartialView(tickets);
        }

        public ActionResult Tickets()
        {
            return View(_unitOfWork.TicketRepository.GetAll());
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
                _unitOfWork.Save();
                return RedirectToAction("Index");
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
                _unitOfWork.Save();
                return RedirectToAction("Index");
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
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}

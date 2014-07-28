using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using myProject.DAL;
using myProject.Models;

namespace myProject.Controllers
{
    public class RepliesController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        // GET: Replies
        public ActionResult Index()
        {
            var replies = _unitOfWork.UserRepository.Get(Int32.Parse(User.Identity.GetUserId())).Replies.ToList();
            return PartialView(replies);
        }

        // GET: /Replies/Create
        public ActionResult Create(int ticketId)
        {
            Replies reply = new Replies()
            {
                TicketId = ticketId,
                UserId = _unitOfWork.UserRepository.Get(Int32.Parse(User.Identity.GetUserId())).Id
            };
            return PartialView(reply);
        }

        // POST: /Response/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketId,UserId,Message")] Replies replyModel)
        {

            if (ModelState.IsValid)
            {
                Replies reply = new Replies
                {
                    Message = replyModel.Message,
                    TicketId = replyModel.TicketId,
                    Time = DateTime.Now,
                    UserId = replyModel.UserId
                };
                _unitOfWork.RepliesRepository.Insert(reply);
                _unitOfWork.Save();
                return RedirectToAction("ShowReply",new {id = reply.TicketId});
                //return PartialView("HaveReply");
            }
            return PartialView("Create");
        }

        public ActionResult ShowReply(int id)
        {
            Replies reply = _unitOfWork.RepliesRepository.Get(id);
            return PartialView(reply);
        }


        // GET: Replies/Edit/5
        public ActionResult Edit(int id)
        {
            Replies reply = _unitOfWork.RepliesRepository.Get(id);
            if (reply == null)
            {
                return HttpNotFound();
            }
            return View(reply);
        }

        // POST: Replies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketId,UserId,Id,Message,Time")] Replies replies)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.RepliesRepository.Update(replies);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(replies);
        }

        // GET: Replies/Delete/5
        public ActionResult Delete(int id)
        {
            Replies reply = _unitOfWork.RepliesRepository.Get(id);
            if (reply == null)
            {
                return HttpNotFound();
            }
            return View(reply);
        }

        // POST: Replies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.TicketRepository.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}

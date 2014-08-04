using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNet.Identity;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    [Authorize]
    public class RepliesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RepliesController(IUnitOfWork uowInstance)
        {
            _unitOfWork = uowInstance;
        }

        // GET: /Replies/Create
        public ActionResult Create(int ticketId)
        {
            Replies reply = new Replies()
            {
                TicketId = ticketId,
                UserId = _unitOfWork.UserRepository.Get(Int32.Parse(User.Identity.GetUserId())).Id
            };
            var replyViewModel = Mapper.DynamicMap<RepliesViewModel>(reply);
            return PartialView(replyViewModel);
        }

        // POST: /Response/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RepliesViewModel replyModel)
        {
            if (ModelState.IsValid)
            {
                var reply = Mapper.DynamicMap<Replies>(replyModel);
                reply.Time = DateTime.Now;
                _unitOfWork.RepliesRepository.Insert(reply);
                _unitOfWork.Commit();
                return RedirectToAction("ShowReply", new { id = replyModel.TicketId });
                //return PartialView("HaveReply");
            }
            return PartialView("Create");
        }

        public ActionResult ShowReply(int id)
        {
            var reply1 = _unitOfWork.RepliesRepository.Get(id);
            var reply = Mapper.DynamicMap<RepliesViewModel>(reply1);
            reply.UserName = reply1.User.UserName;
            return PartialView(reply);
        }


        // GET: Replies/Edit/5
        public ActionResult Edit(int id)
        {
            var reply = Mapper.DynamicMap<RepliesViewModel>(_unitOfWork.RepliesRepository.Get(id));
            if (reply == null)
            {
                return HttpNotFound();
            }
            return PartialView(reply);
        }

        // POST: Replies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RepliesViewModel replyViewModel)
        {
            if (ModelState.IsValid)
            {
                var reply = _unitOfWork.RepliesRepository.Get(replyViewModel.TicketId);
                reply.Time = DateTime.Now;
                reply.Message = replyViewModel.Message;
                _unitOfWork.Commit();
                return RedirectToAction("ShowReply", new { id = reply.TicketId });
            }

            return View(replyViewModel);
        }

        // GET: Replies/Delete/5
        public ActionResult Delete(int id)
        {
            var reply = Mapper.DynamicMap<RepliesViewModel>(_unitOfWork.RepliesRepository.Get(id));
            if (reply == null)
            {
                return HttpNotFound();
            }
            return PartialView(reply);
        }

        // POST: Replies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.RepliesRepository.Delete(id);
            _unitOfWork.Commit();
            return RedirectToAction("Details", "Ticket", new { id = id });
        }
    }
}

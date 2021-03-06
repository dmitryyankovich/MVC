﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using AutoMapper;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNet.Identity;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MessageController(IUnitOfWork uowInstance)
        {
            _unitOfWork = uowInstance;
        }

        public ActionResult MessagesCount()
        {
            var messages = _unitOfWork.MessageRepository.GetAll().Where(m => m.IsRead == false).Count(m => m.UserNameTo == (User.Identity.GetUserName()));
            return PartialView(messages);
        }

        public ActionResult Success()
        {
            return PartialView();
        }

        public ActionResult ShowMessages(int userId, int output = 0)
        {
            var messages = _unitOfWork.MessageRepository.GetAll();
            if (output == 0)
            {
                messages = messages.Where(m => m.UserNameTo == _unitOfWork.UserRepository.Get(userId).UserName);
            }
            else
            {
               messages = messages.Where(m => m.UserId == userId);
            }
            var messageView = new List<MessageViewModel>();
            foreach (var message in messages)
            {
                MessageViewModel messageViewModel = Mapper.DynamicMap<MessageViewModel>(message);
                messageViewModel.UserName =
                    _unitOfWork.UserRepository.Get(messageViewModel.UserId).UserName;
                messageView.Add(messageViewModel);
            }
            return PartialView(messageView);
        }

        public ActionResult Details(int id)
        {
            Message message = _unitOfWork.MessageRepository.Get(id);
            if (message.UserId != Int32.Parse(User.Identity.GetUserId()))
            {
                message.IsRead = true;
            }
            _unitOfWork.Commit();
            if (message == null)
            {
                return HttpNotFound();
            }
            var feedbackView = Mapper.DynamicMap<MessageViewModel>(message);
            return PartialView(feedbackView);
        }

        // GET: /Replies/Create
        public ActionResult Create(int userId)
        {
            Message mess = new Message()
            {
                UserNameTo = _unitOfWork.UserRepository.Get(userId).UserName,
                IsRead = false
            };
            var messageViewModel = Mapper.DynamicMap<MessageViewModel>(mess);
            return PartialView(messageViewModel);
        }

        // POST: /Response/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MessageViewModel messageModel)
        {
            if (ModelState.IsValid)
            {
                messageModel.UserId = Int32.Parse(User.Identity.GetUserId());
                var message = Mapper.DynamicMap<Message>(messageModel);
                message.Time = DateTime.Now;
                _unitOfWork.MessageRepository.Insert(message);
                _unitOfWork.Commit();
                return PartialView("Success");
            }
            return PartialView("Create");
        }

        // GET: Replies/Edit/5
        public ActionResult Edit(int id)
        {
            var message= Mapper.DynamicMap<MessageViewModel>(_unitOfWork.MessageRepository.Get(id));
            if (message == null)
            {
                return HttpNotFound();
            }
            return PartialView(message);
        }

        // POST: Replies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MessageViewModel messageViewModel)
        {
            if (ModelState.IsValid)
            {
                var message = _unitOfWork.MessageRepository.Get(messageViewModel.Id);
                message.MessageText = messageViewModel.MessageText;
                message.Title = messageViewModel.Title;
                message.Time = DateTime.Now;
                _unitOfWork.Commit();
                return RedirectToAction("Success");
            }

            return View(messageViewModel);
        }

        // GET: Replies/Delete/5
        public ActionResult Delete(int id)
        {
            var message = Mapper.DynamicMap<MessageViewModel>(_unitOfWork.MessageRepository.Get(id));
            if (message == null)
            {
                return HttpNotFound();
            }
            return PartialView(message);
        }

        // POST: Replies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.FeedbackRepository.Delete(id);
            _unitOfWork.Commit();
            return RedirectToAction("Index", "Home");
        }
    }
}
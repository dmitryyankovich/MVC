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
    public class FeedbackController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FeedbackController(IUnitOfWork uowInstance)
        {
            _unitOfWork = uowInstance;
        }

        public ActionResult ShowFeedbacks(int userId)
        {
            var feedbacks = _unitOfWork.FeedbackRepository.GetAll();
            feedbacks = feedbacks.Where(m => m.UserToId == userId);
            var feedbackView = new List<FeedbackViewModel>();
            foreach (var feedback in feedbacks)
            {
                FeedbackViewModel feedbackViewModel = Mapper.DynamicMap<FeedbackViewModel>(feedback);
                feedbackViewModel.UserName =
                    _unitOfWork.UserRepository.Get(feedbackViewModel.UserId).UserName;
                feedbackView.Add(feedbackViewModel);
            }
            return PartialView(feedbackView);
        }

        public ActionResult Details(int id)
        {
            Feedback feedback = _unitOfWork.FeedbackRepository.Get(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            var feedbackView = Mapper.DynamicMap<FeedbackViewModel>(feedback);
            return PartialView(feedbackView);
        }
        // GET: /Replies/Create
        public ActionResult Create(int userId)
        {
            Feedback feedback = new Feedback()
            {
                UserId = _unitOfWork.UserRepository.Get(Int32.Parse(User.Identity.GetUserId())).Id,
                UserToId = userId
            };
            var feedbackViewModel = Mapper.DynamicMap<FeedbackViewModel>(feedback);
            return PartialView(feedbackViewModel);
        }

        // POST: /Response/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FeedbackViewModel feedbackModel)
        {
            if (ModelState.IsValid)
            {
                feedbackModel.UserId = _unitOfWork.UserRepository.Get(Int32.Parse(User.Identity.GetUserId())).Id;
                var feedback = Mapper.DynamicMap<Feedback>(feedbackModel);
                feedback.Time = DateTime.Now;
                _unitOfWork.FeedbackRepository.Insert(feedback);
                _unitOfWork.Commit();
                return RedirectToAction("ShowFeedbacks", new { userId = feedback.UserToId });
            }
            return PartialView("Create");
        }

        // GET: Replies/Edit/5
        public ActionResult Edit(int id)
        {
            var feedback = Mapper.DynamicMap<FeedbackViewModel>(_unitOfWork.FeedbackRepository.Get(id));
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return PartialView(feedback);
        }

        // POST: Replies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FeedbackViewModel feedbackViewModel)
        {
            if (ModelState.IsValid)
            {
                feedbackViewModel.Time = DateTime.Now;
                var feedback = Mapper.DynamicMap<Feedback>(feedbackViewModel);
                _unitOfWork.FeedbackRepository.Update(feedback);
                _unitOfWork.Commit();
                return RedirectToAction("ShowFeedbacks", new { userId = feedback.UserToId });
            }

            return View(feedbackViewModel);
        }

        // GET: Replies/Delete/5
        public ActionResult Delete(int id)
        {
            var feedback = Mapper.DynamicMap<FeedbackViewModel>(_unitOfWork.FeedbackRepository.Get(id));
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return PartialView(feedback);
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

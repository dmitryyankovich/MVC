using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using AutoMapper;
using BLL.DomainModels;
using WebUI.ViewModels;

namespace WebUI
{
    public partial class AutomapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<User, ManageUserViewModel>();
            Mapper.CreateMap<RegisterViewModel, User>();
            Mapper.CreateMap<Ticket, TicketViewModel>().AfterMap((ticket, viewmodel) =>
            {
                viewmodel.UserAvatar = ticket.User.Avatar;
                viewmodel.UserCity = ticket.User.City;
                viewmodel.UserCountry = ticket.User.Country;
                viewmodel.ReplyMessage = ticket.Reply.Message;
                viewmodel.UserName = ticket.User.UserName;
            });
            Mapper.CreateMap<Ticket, ShowTicketsViewModel>().AfterMap((ticket, viewmodel) =>
            {
                viewmodel.UserAvatar = ticket.User.Avatar;
                viewmodel.UserCity = ticket.User.City;
                viewmodel.UserCountry = ticket.User.Country;
                viewmodel.ReplyMessage = ticket.Reply.Message;
                viewmodel.UserName = ticket.User.UserName;
            });

            Mapper.CreateMap<TicketViewModel, Ticket>();

            Mapper.CreateMap<Replies, RepliesViewModel>().AfterMap((reply, viewmodel) =>
            {
                viewmodel.UserName = reply.User.UserName;
            });

            Mapper.CreateMap<RepliesViewModel, Replies>();

            Mapper.CreateMap<Feedback, FeedbackViewModel>().AfterMap((feedback, viewmodel) =>
            {
                viewmodel.UserName = feedback.User.UserName;
            });

            Mapper.CreateMap<FeedbackViewModel,Feedback>();

            Mapper.CreateMap<User, ViewProfileViewModel>();

        }
    }
}
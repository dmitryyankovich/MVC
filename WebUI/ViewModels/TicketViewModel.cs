using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BLL.DomainModels;

namespace WebUI.ViewModels
{
    public class TicketViewModel : IdModel
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Logo { get; set; }
        public string Content { get; set; }
        [Display(Name = "Type of ticket")]
        public TypeOfTicket TypeOfTicket { get; set; }
        public string ReplyMessage { get; set; }
        public string UserCity { get; set; }
        public string UserCountry { get; set; }
        public string UserAvatar { get; set; }
        public string UserName { get; set; }
    }
}
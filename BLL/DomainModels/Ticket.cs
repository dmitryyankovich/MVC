using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BLL.DomainModels
{
    public class Ticket : IdModel
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Logo { get; set; }
        public string Content { get; set; }
        [Display(Name = "Type of ticket")]
        public TypeOfTicket TypeOfTicket { get; set; }
        public User User { get; set; }
        public Replies Reply { get; set; }
        public ICollection<Photos> Photos { get; set; }
    }
}
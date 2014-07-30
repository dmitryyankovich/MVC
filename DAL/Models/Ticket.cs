using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace myProject.Models
{
    public class Ticket : IdModel
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Logo { get; set; }
        public string Content { get; set; }
        [Display(Name = "Type of ticket")]
        public virtual TypeOfTicket TypeOfTicket { get; set; }
        public virtual User User { get; set; }
        public virtual Replies Reply { get; set; }
        public virtual ICollection<Photos> Photos { get; set; }
    }

    public enum TypeOfTicket
    {
        Offer,
        Find
    }
}
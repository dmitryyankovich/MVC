using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DAL.Models
{
    public class Ticket : IdModel
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be maximum {1} characters long.")]
        public string Title { get; set; }
        public string Logo { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be maximum {1} characters long.")]
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
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class RepliesViewModel
    {
        public int TicketId { get; set; }
        public int UserId { get; set; }
        [StringLength(255, ErrorMessage = "The {0} must be maximum {1} characters long.")]
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public string UserName { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BLL.DomainModels;

namespace WebUI.ViewModels
{
    public class MessageViewModel : IdModel
    {
        public string UserNameTo { get; set; }
        public DateTime Time { get; set; }
        [StringLength(256, ErrorMessage = "The {0} must be maximum {1} characters long.")]
        [DisplayName("Message")]
        public string MessageText { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool IsRead { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be maximum {1} characters long")]
        public string Title { get; set; }
    }
}
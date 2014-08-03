using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BLL.DomainModels;

namespace WebUI.ViewModels
{
    public class FeedbackViewModel : IdModel
    {
        [Required]
        public int UserToId { get; set; }
        public DateTime Time { get; set; }
        [Range(0, 5, ErrorMessage = "Rating from 0 to 5")]
        public int Rating { get; set; }
        [StringLength(256, ErrorMessage = "The {0} must be maximum {1} characters long.")]
        public string FeedbackMessage { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
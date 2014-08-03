using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DomainModels
{
    public class Feedback : IdModel
    {
        public int UserId { get; set; }
        [Required]
        public int UserToId { get; set; }
        public DateTime Time { get; set; }
        [Range(0,5,ErrorMessage = "Rating from 0 to 5")]
        public int Rating { get; set; }
        [StringLength(256, ErrorMessage = "The {0} must be maximum {1} characters long.")]
        public string FeedbackMessage { get; set; }
        public virtual User User { get; set; }
    }
}

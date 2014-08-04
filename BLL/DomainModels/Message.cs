using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DomainModels
{
    public class Message : IdModel
    {
        public int UserId { get; set; }
        [StringLength(20, ErrorMessage = "The {0} must be maximum {1} characters long")]
        public string UserNameTo { get; set; }
        public DateTime Time { get; set; }
        [StringLength(256, ErrorMessage = "The {0} must be maximum {1} characters long.")]
        public string MessageText { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be maximum {1} characters long")]
        public string Title { get; set; }
        public virtual User User { get; set; }
    }
}

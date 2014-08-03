using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DAL.Models
{
    public class Languages : IdModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be maximum {1} characters long.")]
        public string Language { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
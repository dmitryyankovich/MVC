using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BLL.DomainModels
{
    public class Languages : IdModel
    {
        [StringLength(20, ErrorMessage = "The {0} must be maximum {1} characters long.")]
        public string Language { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
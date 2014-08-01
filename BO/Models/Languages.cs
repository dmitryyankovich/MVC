using System;
using System.Collections.Generic;
using System.Linq;

namespace BO.Models
{
    public class Languages : IdModel
    {
        public string Language { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
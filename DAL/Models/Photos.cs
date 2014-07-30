using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myProject.Models
{
    public class Photos : IdModel
    {
        public string Photo { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
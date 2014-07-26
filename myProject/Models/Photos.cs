using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myProject.Models
{
    public class Photos
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
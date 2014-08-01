using System;
using System.Collections.Generic;
using System.Linq;

namespace BO.Models
{
    public class Photos : IdModel
    {
        public string Photo { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
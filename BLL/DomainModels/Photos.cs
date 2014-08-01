using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.DomainModels
{
    public class Photos : IdModel
    {
        public string Photo { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
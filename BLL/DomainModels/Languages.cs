using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.DomainModels
{
    public class Languages : IdModel
    {
        public string Language { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
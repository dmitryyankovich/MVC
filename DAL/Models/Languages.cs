﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class Languages : IdModel
    {
        public string Language { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
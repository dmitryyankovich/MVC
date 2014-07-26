﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myProject.Models
{
    public class Languages
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
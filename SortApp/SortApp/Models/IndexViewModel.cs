﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortApp.Models
{
    public class IndexViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}

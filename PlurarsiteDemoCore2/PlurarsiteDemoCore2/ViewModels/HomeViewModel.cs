﻿using PlurarsiteDemoCore2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlurarsiteDemoCore2.ViewModels
{
    public class HomeViewModel
    {
        public string Title { get; set; }

        public List<Pie> Pies { get; set; }

        public List<IceCream> IceCream { get; set; }

    }
}

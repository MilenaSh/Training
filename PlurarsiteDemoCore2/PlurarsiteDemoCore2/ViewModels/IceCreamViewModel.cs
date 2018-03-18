using PlurarsiteDemoCore2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlurarsiteDemoCore2.ViewModels
{
    public class IceCreamViewModel
    {
        public string Title { get; set; }

        public List<IceCream> IceCreams { get; set; }
    }
}

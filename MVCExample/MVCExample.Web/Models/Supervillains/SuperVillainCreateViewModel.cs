using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCExample.Web.Models.Supervillains
{
    public class SuperVillainCreateViewModel
    {
        public string Name { get; set; }

        public bool IsAlien { get; set; }

        public string RealName { get; set; }

    }
}
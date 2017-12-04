using MVCExample.DataModels;
using MVCExample.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.Services.Models
{
    public class SuperVillainService : IMapFrom<Supervillain>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}


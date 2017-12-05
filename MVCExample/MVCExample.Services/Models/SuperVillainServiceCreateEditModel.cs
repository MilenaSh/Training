using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.Services.Models
{
    public class SuperVillainServiceCreateEditModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string VillainIdentityName { get; set; }
    }
}

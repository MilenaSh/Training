using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.Services.Models
{
    public class SuperHeroServiceUpdateModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsAlien { get; set; }

        public string SecretIdentityName { get; set; }

        public int SecretIdentiyAge { get; set; }

        public Guid CurrentCity { get; set; }

        public Guid[] CurrentPowers { get; set; }
    }
}

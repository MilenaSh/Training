using MVCExample.DataModels;
using MVCExample.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.Services.Models
{
    public class SuperHeroServiceCreateEditModel 
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string SecretIdentityName { get; set; }

        public int SecretIdentityage { get; set; }

        public string CityName { get; set; }
    }
}

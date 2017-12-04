using MVCExample.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCExample.Web.Models.Superheroes
{
    public class SuperHeroeUpdateViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string SecretIdentityName { get; set; }

        public int SecretIdentityage { get; set; }

        public string CityName { get; set; }

        public IEnumerable<City> Cities { get; set; }

    }
}
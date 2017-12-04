using MVCExample.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MVCExample.DataModels;
using MVCExample.Services.Models;

namespace MVCExample.Web.Models.Superheroes
{
    public class SuperHeroeCreateViewModel
    {
        public string Name { get; set; }

        public string SecretIdentityName { get; set; }

        public int SecretIdentityage { get; set; }

        public string CityName { get; set; }

    }
}
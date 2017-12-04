using AutoMapper;
using MVCExample.DataModels;
using MVCExample.Infrastructure;
using MVCExample.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCExample.Web.Models.Superheroes
{
    public class SuperHeroeDetailedViewModel : IMapFrom<Superhero>, IMapFrom<SuperheroServiceModel>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsAlien { get; set; }

        public string RealName { get; set; }

        public int RealAge { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Superhero, SuperHeroeDetailedViewModel>()
                .ForMember(shvm => shvm.RealName, opt => opt.MapFrom(sh => sh.SecretIdentity.Name))
                .ForMember(shvm => shvm.RealAge, opt => opt.MapFrom(sh => sh.SecretIdentity.Age));
        }
    }
}
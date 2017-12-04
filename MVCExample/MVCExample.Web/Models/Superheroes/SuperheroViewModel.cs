using AutoMapper;
using MVCExample.DataModels;
using MVCExample.Infrastructure;
using MVCExample.Services.Models;
using System;

namespace MVCExample.Web.Models.Superheroes
{
    public class SuperheroViewModel : IMapFrom<Superhero>, IMapFrom<SuperheroServiceModel>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsAlien { get; set; }

        public string RealName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Superhero, SuperheroViewModel>()
                .ForMember(shvm => shvm.RealName, opt => opt.MapFrom(sh => sh.SecretIdentity.Name));
        }
    }
}
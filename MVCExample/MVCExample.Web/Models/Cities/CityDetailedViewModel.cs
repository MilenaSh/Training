using AutoMapper;
using MVCExample.DataModels;
using MVCExample.Infrastructure;
using MVCExample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCExample.Web.Models.Cities
{
    public class CityDetailedViewModel : IMapFrom<City>, IMapFrom<CityService>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Population { get; set; }

        public int SuperheroCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<City, CityDetailedViewModel>()
                .ForMember(cvm => cvm.SuperheroCount, opt => opt.MapFrom(c => c.SuperHeroes.Count())); // at least 30 years old
        }

    }
}
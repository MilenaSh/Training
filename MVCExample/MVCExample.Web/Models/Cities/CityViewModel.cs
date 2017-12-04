﻿using MVCExample.DataModels;
using MVCExample.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MVCExample.Services;

namespace MVCExample.Web.Models.Cities
{
    public class CityViewModel : IMapFrom<City>, IMapFrom<CityService>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Population { get; set; }

        public int SuperheroCount { get; set; }

        public int Age { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<City, CityViewModel>()
                .ForMember(cvm => cvm.SuperheroCount, opt => opt.MapFrom(c => c.SuperHeroes.Count())); // at least 30 years old
        }

        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    configuration.CreateMap<Superhero, SuperheroViewModel>()
        //        .ForMember(shvm => shvm.RealName, opt => opt.MapFrom(sh => sh.SecretIdentity.Name));
        //}
    }
}

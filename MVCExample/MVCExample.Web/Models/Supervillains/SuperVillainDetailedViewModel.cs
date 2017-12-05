using MVCExample.DataModels;
using MVCExample.Infrastructure;
using MVCExample.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace MVCExample.Web.Models.Supervillains
{
    public class SuperVillainDetailedViewModel : IMapFrom<Supervillain>, IMapFrom<SuperVillainService>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsAlien { get; set; }

        public string RealName { get; set; }


        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Supervillain, SuperVillainDetailedViewModel>()
                .ForMember(svvm => svvm.RealName, opt => opt.MapFrom(sv => sv.VillainIdentity.Name));
        }

    }
}
using MVCExample.DataModels;
using MVCExample.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MVCExample.Services.Models;

namespace MVCExample.Web.Models.Supervillains
{
    public class SuperVillainViewModel : IMapFrom<Supervillain>, IMapFrom<SuperVillainService>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsAlien { get; set; }

        public string RealName { get; set; }


        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Supervillain, SuperVillainViewModel>()
                .ForMember(svvm => svvm.RealName, opt => opt.MapFrom(sv => sv.VillainIdentity.Name));
        }
    }
}


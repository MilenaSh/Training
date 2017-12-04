using MVCExample.DataModels;
using MVCExample.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCExample.Web.Models.Cities
{
    public class CityDropDownCompleteViewModel : IMapFrom<City>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

    }
}
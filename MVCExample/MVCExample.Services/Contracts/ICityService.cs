using MVCExample.DataModels;
using MVCExample.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.Services.Contracts
{
    public interface ICityService
    {
        IQueryable<City> All();

        IQueryable<City> Filtered(string pattern);

        City GetById(Guid id);

        City Create(CityServiceCreateModel data);

        bool Delete(Guid id);
    }
}

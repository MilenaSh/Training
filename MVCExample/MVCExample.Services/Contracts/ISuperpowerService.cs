using MVCExample.DataModels;
using MVCExample.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.Services.Contracts
{
    public interface ISuperpowerService
    {
        SuperPower GetPowerByName(string name);

        SuperPower GetById(Guid id);

        IQueryable<SuperPower> GetAll();

        ICollection<SuperPower> GetAllBySuperhero(Guid id);

        SuperPower Create(SuperPowerServiceCreateModel powerInfo);

        SuperPower Update(SuperPowerServiceUpdateModel powerInfo);

        bool Delete(Guid id);

    }
}

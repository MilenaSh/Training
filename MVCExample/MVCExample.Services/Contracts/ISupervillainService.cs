using MVCExample.DataModels;
using MVCExample.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.Services.Contracts
{
    public interface ISupervillainService
    {
        IQueryable<Supervillain> All();

        Supervillain GetById(Guid id);

        Supervillain Create(SuperVillainServiceCreateEditModel data);

        Supervillain Update(SuperVillainServiceCreateEditModel data);

        bool Delete(Guid id);
    }
}


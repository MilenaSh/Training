using MVCExample.DataModels;
using MVCExample.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCExample.Services.Contracts
{
    // standart Service Methods
    public interface ISuperheroService
    {
        IQueryable<Superhero> All();

        IQueryable<Superhero> GetSuperHeroes(int page, int pageSize);

        Superhero GetById(Guid id);

        Superhero Create(SuperHeroServiceCreateEditModel data);

        Superhero Update(SuperHeroServiceCreateEditModel data);

        bool Delete(Guid id);
    }
}

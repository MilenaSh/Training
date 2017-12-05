using MVCExample.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCExample.DataModels;
using MVCExample.Data.Repository;
using MVCExample.Services.Models;

namespace MVCExample.Services
{
    public class SuperPowerService : ISuperpowerService
    {

        // add sevices not generic rep

        private readonly ISuperheroService superHeroesService;
        private readonly IGenericRepository<SuperPower> superPowers;


        public SuperPowerService(IGenericRepository<SuperPower> superPowers, ISuperheroService superHeroesService)
        {
            this.superHeroesService = superHeroesService;
            this.superPowers = superPowers;
        }

        public SuperPower GetPowerByName(string name)
        {
            var result = this.superPowers.All()
                .FirstOrDefault(x => x.Name == name);

            return result;

        }
        public SuperPower GetById(Guid id)
        {
            var result = this.superPowers.GetById(id);

            return result;

        }

        public IQueryable<SuperPower> GetAll()
        {
            var result = this.superPowers.All();

            return result; 
        }

        public ICollection<SuperPower> GetAllBySuperhero(Guid id)
        {
            // find the given superhero by his id
            var currentHero = this.superHeroesService.GetById(id);

            // if no match is found - return null 
            if (currentHero == null)
            {
                return null;
            }

            // get all of his powers - superhero.superpowers
            var result = currentHero.SuperPowers;

            // return the collection
            return result;
        }

        public SuperPower Create(SuperPowerServiceCreateModel powerInfo)
        {
            var newSuprpower = new SuperPower()
            {
                Name = powerInfo.Name,
                Description = powerInfo.Description
            };

            this.superPowers.Add(newSuprpower);
            this.superPowers.SaveChanges();

            return newSuprpower;
         
        }

        public SuperPower Update(SuperPowerServiceUpdateModel powerInfo)
        {
            var superpower = this.GetById(powerInfo.Id);

            if (superpower == null)
            {
                return null;
            }

            superpower.Name = powerInfo.Name;
            superpower.Description = powerInfo.Name;

            this.superPowers.Update(superpower);
            this.superPowers.SaveChanges();

            return superpower;

        }

        public bool Delete(Guid id)
        {
            var item = this.GetById(id);
            if (item == null)
            {
                return false;
            }

            this.superPowers.Delete(item.Id);
            this.superPowers.SaveChanges();

            return true;
        }

    
    }
}

using MVCExample.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using MVCExample.Services.Models;
using MVCExample.Data;
using MVCExample.Infrastructure;
using MVCExample.Data.Repository;
using MVCExample.DataModels;
using System;

namespace MVCExample.Services
{
    public class SuperheroService : ISuperheroService
    {
        // add supervillain
        private readonly IGenericRepository<Superhero> superHeroes;
        private readonly IGenericRepository<SuperPower> superPowers;
        private readonly IGenericRepository<City> cities;

        public SuperheroService(IGenericRepository<Superhero> superHeroes, IGenericRepository<SuperPower> superPowers, IGenericRepository<City> cities)
        {
            this.superHeroes = superHeroes;
            this.cities = cities;
            this.superPowers = superPowers;
        }

        public IQueryable<Superhero> All()
        {
            var result = this.superHeroes.All();

            return result;
        }

        public Superhero Create(SuperHeroServiceCreateEditModel data)
        {
            var newSuperHero = new Superhero()
            {
                Name = data.Name,
                SecretIdentity = new SecretIdentity() { Name = data.SecretIdentityName, Age = data.SecretIdentityage }
            };

            City city = this.cities.All().FirstOrDefault(x => x.Name == data.CityName);
            if(city == null)
            {
                city = new City { Name = data.Name };
            }

            newSuperHero.City = city;
            this.superHeroes.Add(newSuperHero);
            this.superHeroes.SaveChanges();

            return newSuperHero;
        }

        public bool Delete(Guid id)
        {
            var item = this.GetById(id);
            if(item == null)
            {
                return false;
            }

            this.superHeroes.Delete(item.Id);
            this.superHeroes.SaveChanges();

            return true;
        }

        public Superhero GetById(Guid id)
        {
            var result = this.superHeroes.GetById(id);

            return result;
        }

        public IQueryable<Superhero> GetSuperHeroes(int page, int pageSize)
        {
            if(page <= 0)
            {
                return null;
            }

            if (pageSize <= 0 )
            {
                return null;
            }

            var result = this.superHeroes.All()
                .OrderBy(x => x.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return result;
        }

        public Superhero Update(SuperHeroServiceCreateEditModel data)
        {
            var heroe = this.GetById(data.Id);

            heroe.Name = data.Name;
            heroe.SecretIdentity.Name = data.SecretIdentityName;
            heroe.SecretIdentity.Age = data.SecretIdentityage;


            City city = this.cities.All().FirstOrDefault(x => x.Name == data.CityName);
            if (city == null)
            {
                city = new City { Name = data.CityName };
            }

            heroe.City = city;

            this.superHeroes.Update(heroe);
            this.superHeroes.SaveChanges();

            return heroe;
  

        }

        public void AddPowerToSuperhero(Guid superheroId, string powerName)
        {
            // check if power exists
            var existingPower = this.superPowers.All()
                .FirstOrDefault(x => x.Name == powerName);

            var superhero = this.GetById(superheroId);

            if (superhero == null)
            {
                return;
            }
            // if not create new one
            if (existingPower == null)
            {
                existingPower = new SuperPower
                {
                    Name = powerName,
                    Description = ""
                };

                this.superPowers.Add(existingPower);
                this.superPowers.SaveChanges();
            }

            superhero.SuperPowers.Add(existingPower);
            this.superHeroes.Update(superhero);
            this.superHeroes.SaveChanges();
            // add power to hero

            // save changes
        }
    }
}

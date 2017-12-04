using MVCExample.Data.Repository;
using MVCExample.DataModels;
using MVCExample.Services.Contracts;
using MVCExample.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.Services
{
    public class CityService : ICityService
    {
        private readonly IGenericRepository<Superhero> superHeroes;
        private readonly IGenericRepository<City> cities;

        public CityService(IGenericRepository<Superhero> superHeroes, IGenericRepository<City> cities)
        {
            this.cities = cities;
            this.superHeroes = superHeroes;
        }

        public IQueryable<City> All()
        {
            var result = this.cities.All();

            return result;
        }

        public IQueryable<City> Filtered(string pattern)
        {
            var result = this.cities.All()
                .Where(x=>x.Name.Contains(pattern))
                .OrderBy(x=>x.Population);

            return result;
        }

        public City GetById(Guid id)
        {
            var result = this.cities.GetById(id);

            return result;
        }

        public bool Delete(Guid id)
        {
            var item = this.GetById(id);
            if (item == null)
            {
                return false;
            }

            this.cities.Delete(item.Id);
            this.cities.SaveChanges();

            return true;
        }

        public City Create(CityServiceCreateModel data)
        {
            var newCity = new City()
            {
                Name = data.Name,
                Population = data.Population,
            };

            this.cities.Add(newCity);
            this.cities.SaveChanges();

            return newCity;
        }

    }

}

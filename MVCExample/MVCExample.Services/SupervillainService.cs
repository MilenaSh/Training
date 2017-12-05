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
    public class SupervillainService : ISupervillainService
    {
        private readonly IGenericRepository<Superhero> superHeroes;
        private readonly IGenericRepository<SuperPower> superPowers;
        private readonly IGenericRepository<Supervillain> supervillains;

        public SupervillainService(IGenericRepository<Superhero> superHeroes, IGenericRepository<SuperPower> superPowers, IGenericRepository<Supervillain> supervillains)
        {
            this.superHeroes = superHeroes;
            this.superPowers = superPowers;
            this.supervillains = supervillains;
        }

        public IQueryable<Supervillain> All()
        {
            var result = this.supervillains.All();

            return result;
        }

        public Supervillain Create(SuperVillainServiceCreateEditModel data)
        {
            var newSupervillain = new Supervillain()
            {
                Name = data.Name,                
                VillainIdentity = new VillainIdentity() { Name = data.VillainIdentityName }
            };

            this.supervillains.Add(newSupervillain);
            this.supervillains.SaveChanges();

            return newSupervillain;
        }

        public bool Delete(Guid id)
        {
            var item = this.GetById(id);
            if (item == null)
            {
                return false;
            }

            this.supervillains.Delete(item.Id);
            this.supervillains.SaveChanges();

            return true;
        }

        public Supervillain GetById(Guid id)
        {
            var result = this.supervillains.GetById(id);

            return result;
        }

        public Supervillain Update(SuperVillainServiceCreateEditModel data)
        {

            var villain = this.GetById(data.Id);

            villain.Name = data.Name;
            villain.VillainIdentity.Name = data.VillainIdentityName;

            this.supervillains.Update(villain);
            this.supervillains.SaveChanges();

            return villain;
        }

        public void AddPowertosupervillain(Guid supervillainId, string powerName)
        {
            var existingPower = this.superPowers.All()
      .FirstOrDefault(x => x.Name == powerName);

            var supervillain = this.GetById(supervillainId);

            if (supervillain == null)
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

            supervillain.SuperPowers.Add(existingPower);
            this.supervillains.Update(supervillain);
            this.supervillains.SaveChanges();

        }
    }
}

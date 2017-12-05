using MVCExample.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.DataModels
{
    public class Supervillain : BaseDbModel
    {
        private ICollection<SuperPower> superpowers;

        private ICollection<Superhero> superheroes;

        // constructor

        public Supervillain()
        {
            this.superpowers = new HashSet<SuperPower>();
            this.superheroes = new HashSet<Superhero>();
        }

        [MaxLength(ValidationConstants.ShortTextLength)]
        public string Name { get; set; }

        public bool IsAlien { get; set; }

        public virtual VillainIdentity VillainIdentity { get; set; }

        public ICollection<SuperPower> SuperPowers
        {
            get { return superpowers; }
            set { value = superpowers; }
        }

        public ICollection<Superhero> SuperHero
        {
            get { return superheroes; }
            set { value = superheroes; }
        }

    }
}

using MVCExample.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCExample.DataModels
{
    public class Superhero: BaseDbModel
    {
        private ICollection<SuperPower> superpowers;

        private ICollection<Supervillain> supervillains;

        public Superhero()
        {
            this.superpowers = new HashSet<SuperPower>();
            this.supervillains = new HashSet<Supervillain>();
        }

        [MaxLength(ValidationConstants.ShortTextLength)]
        public string Name { get; set; }

        public bool IsAlien { get; set; }

        public Guid? CityId { get; set; }

        public virtual City City { get; set; }

        public virtual SecretIdentity SecretIdentity { get; set; }

        public ICollection<SuperPower> SuperPowers
        {
            get { return superpowers; }
            set { superpowers = value; }
        }

        public ICollection<Supervillain> SuperVillains
        {
            get { return supervillains; }
            set { supervillains = value; }
        }
    }
}

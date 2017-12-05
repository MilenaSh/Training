using MVCExample.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.DataModels
{
    public class City : BaseDbModel
    {
        private ICollection<Superhero> superHeroes;

        public City()
        {
            this.superHeroes = new HashSet<Superhero>();
        }

        public int Population { get; set; }

        [MaxLength(ValidationConstants.ShortTextLength)]
        public string Name { get; set; }

        public virtual ICollection<Superhero> SuperHeroes
        {
            get { return this.superHeroes; }
            set { this.superHeroes = value; }
        }
    }
}

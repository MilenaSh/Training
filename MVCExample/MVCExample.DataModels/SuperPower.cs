using MVCExample.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.DataModels
{
    public class SuperPower : BaseDbModel
    {
        private ICollection<Superhero> superheros;

        public SuperPower()
        {
            this.superheros = new HashSet<Superhero>();
        }

        [MaxLength(ValidationConstants.ShortTextLength)]
        public string Name { get; set; }

        [MaxLength(ValidationConstants.ShortTextLength)]
        public string Description { get; set; }


        public ICollection<Superhero> Superheros
        {
            get { return superheros; }
            set { superheros = value; }
        }

    }
}

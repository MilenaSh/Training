using MVCExample.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.DataModels
{
    public class SecretIdentity
    {
        [ForeignKey("Superhero")]
        public Guid Id { get; set; }

        [MaxLength(ValidationConstants.ShortTextLength)]
        public string Name { get; set; }

        public int Age { get; set; }

        public virtual Superhero Superhero { get; set; }
    }
}

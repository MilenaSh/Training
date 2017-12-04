using MVCExample.DataModels;
using MVCExample.Infrastructure;
using System;

namespace MVCExample.Services.Models
{
    public class SuperheroServiceModel: IMapFrom<Superhero>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}

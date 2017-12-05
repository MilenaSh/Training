using MVCExample.DataModels;
using System.Data.Entity;

namespace MVCExample.Data
{
    public class ExampleContext : DbContext, IExampleContext
    {
        public ExampleContext()
                : base("DefaultConnection")
        {
        }

        public IDbSet<Superhero> Superheroes { get; set; }

        public IDbSet<SuperPower> Superpowers { get; set; }

        public IDbSet<Supervillain> Supervillains { get; set; }

        public IDbSet<City> Cities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static ExampleContext Create()
        {
            return new ExampleContext();
        }
    }
}

namespace MVCExample.Data.Migrations
{
    using MVCExample.DataModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<MVCExample.Data.ExampleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ExampleContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            if (!context.Superheroes.Any())
            {
                //cities
                City batmanCity = new City()
                {
                    Name = "Gottam",
                    Population = 10000000
                };

                City supermanCity = new City()
                {
                    Name = "Smallville",
                    Population = 500
                };

                context.Cities.Add(batmanCity);
                context.Cities.Add(supermanCity);

                context.SaveChanges();

                // super heroes
                Superhero batman = new Superhero()
                {
                    Name = "Batman",
                    SecretIdentity = new SecretIdentity() { Name = "Bruce Wayne", Age = 30 },
                    CityId = batmanCity.Id
                };


                Superhero superman = new Superhero()
                {
                    Name = "Superman",
                    SecretIdentity = new SecretIdentity() { Name = "Clark Kent", Age = 35 },
                    City = supermanCity
                };

                context.Superheroes.Add(batman);
                context.Superheroes.Add(superman);
                context.SaveChanges();

                var spiderWeb = new SuperPower
                {
                    Name = "Spider Web",
                    Description = "Excreting sticky white stuff"
                };

                Superhero spiderman = new Superhero()
                {
                    Name = "Spiderman",
                    SecretIdentity = new SecretIdentity() { Name = "Peter Parker", Age = 30 },
                };
                spiderman.SuperPowers.Add(spiderWeb);

                City spidermanCity = new City()
                {
                    Name = "New York",
                    Population = 11000000
                };
                spidermanCity.SuperHeroes.Add(spiderman);

                context.Cities.Add(spidermanCity);

                context.SaveChanges();

             }

            if (!context.Supervillains.Any())
            {
                Supervillain lexLutar = new Supervillain()
                {
                    Name = "LexLutar",
                    IsAlien = false,
                    VillainIdentity = new VillainIdentity() { Name = "Lex Lutar" },

                };

                Supervillain theJocker = new Supervillain()
                {
                    Name = "The Jocker",
                    IsAlien = false,
                    VillainIdentity = new VillainIdentity() { Name = "Unknown" }
                };

                Supervillain harleyQuinn = new Supervillain()
                {
                    Name = "Harley Quinn",
                    IsAlien = false,
                    VillainIdentity = new VillainIdentity() { Name = "Dr. Quinzel" }
                };

                Supervillain greenGoblin = new Supervillain()
                {
                    Name = "Green Goblin",
                    IsAlien = false,
                    VillainIdentity = new VillainIdentity() { Name = "Osborn" }
                };

                context.Supervillains.Add(lexLutar);
                context.Supervillains.Add(theJocker);
                context.Supervillains.Add(harleyQuinn);
                context.Supervillains.Add(greenGoblin);

                context.SaveChanges();
            }
        }
    }
}

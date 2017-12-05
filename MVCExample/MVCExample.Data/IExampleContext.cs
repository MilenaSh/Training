using MVCExample.DataModels;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MVCExample.Data
{
    public interface IExampleContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<Superhero> Superheroes { get; set; }

        IDbSet<City> Cities { get; set; }

        void Dispose();

        int SaveChanges();
    }
}
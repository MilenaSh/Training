using MVCExample.Data;
using MVCExample.Data.Migrations;
using System.Data.Entity;

namespace MVCExample.Web.App_Start
{
    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ExampleContext, Configuration>());
            ExampleContext.Create().Database.Initialize(true);
        }
    }
}
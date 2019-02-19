namespace Elmarknad.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Elmarknad.Models.Webscrape.DbEl>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Elmarknad.Models.Webscrape.DbEl";
        }

        protected override void Seed(Elmarknad.Models.Webscrape.DbEl context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}

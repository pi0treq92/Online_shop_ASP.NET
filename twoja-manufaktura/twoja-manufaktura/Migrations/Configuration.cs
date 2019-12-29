namespace twoja_manufaktura.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using twoja_manufaktura.DAL;

    public sealed class Configuration : DbMigrationsConfiguration<twoja_manufaktura.DAL.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(twoja_manufaktura.DAL.StoreContext context)
        {
            StoreInitializer.SeedStoreData(context);
            StoreInitializer.IdentityForApplication(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}

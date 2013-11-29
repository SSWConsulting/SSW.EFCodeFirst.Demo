namespace EFCodeFirstDemo.Data.EF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class Configuration : DbMigrationsConfiguration<EFCodeFirstDemo.Data.EF.DemoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EFCodeFirstDemo.Data.EF.DemoDbContext";
        }

        protected override void Seed(EFCodeFirstDemo.Data.EF.DemoDbContext context)
        {
            
        }
    }
}

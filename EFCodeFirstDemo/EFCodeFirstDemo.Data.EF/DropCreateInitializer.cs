using System.Data.Entity;
using System.Linq;
using EFCodeFirstDemo.Domain;

namespace EFCodeFirstDemo.Data.EF
{

    public class DropCreateInitializer : DropCreateDatabaseIfModelChanges<DemoDbContext>//CreateDatabaseIfNotExists, DropCreateDatabaseIfModelChanges, AlwaysRecreateDatabase,MigrateDatabaseToLatestVersion
    {

        protected override void Seed(DemoDbContext context)
        {
            if (!context.Set<Customer>().Any())
            {
                var customer1 = new Customer()
                {
                    FirstName = "John",
                    LastName = "Smith",
                    EmailAddress = "johnsmith@ssw.com.au",
                    Address1 = "10 Church St",
                    Suburb = "Neutral Bay",
                    Postcode = "2089",
                    State = State.NSW,
                    Phone = "12345"
                };

                context.Entry(customer1).State = EntityState.Added;


                var customer2 = new Customer()
                {
                    FirstName = "Mark",
                    LastName = "Jones",
                    EmailAddress = "markjones@ssw.com.au",
                    Address1 = "10 Church St",
                    Suburb = "Neutral Bay",
                    Postcode = "2089",
                    State = State.NSW,
                    Phone = "54321"
                };

                context.Entry(customer2).State = EntityState.Added;

                context.SaveChanges();

            }
        }
    }


}
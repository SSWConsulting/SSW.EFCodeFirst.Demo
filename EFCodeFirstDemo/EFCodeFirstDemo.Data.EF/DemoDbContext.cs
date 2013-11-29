using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstDemo.Data.EF
{


    public class DemoDbContext : DbContext
    {

        public DemoDbContext(string connectionStringName)
            : base(connectionStringName)
        {
            this.Configuration.LazyLoadingEnabled = true;
        }



        public DemoDbContext()
            : base("name=DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Assembly);
        }

    }
}

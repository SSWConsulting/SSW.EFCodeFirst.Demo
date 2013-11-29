using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCodeFirstDemo.Domain;

namespace EFCodeFirstDemo.Data.EF.EntityConfiguration
{
    public class ClientConfiguration : EntityTypeConfiguration<Customer>
    {
    }
}

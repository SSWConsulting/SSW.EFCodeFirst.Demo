using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCodeFirstDemo.Domain;
using EFCodeFirstDemo.RepositoryInterfaces;
using SSW.Framework.Data.EF;

namespace EFCodeFirstDemo.Data.EF.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDbContextManager contextManager) : base(contextManager) { }
    }
}

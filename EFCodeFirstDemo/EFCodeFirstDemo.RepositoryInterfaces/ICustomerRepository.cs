using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCodeFirstDemo.Domain;
using SSW.Framework.Data.Interfaces;

namespace EFCodeFirstDemo.RepositoryInterfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
    }
}

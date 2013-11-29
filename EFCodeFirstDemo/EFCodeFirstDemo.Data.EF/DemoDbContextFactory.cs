using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSW.Framework.Data.EF;

namespace EFCodeFirstDemo.Data.EF
{
    public class DemoDbContextFactory : IDbContextFactory<DemoDbContext>
    {
        
        private bool _hasSetInitializer = false;

        private readonly IDatabaseInitializer<DemoDbContext> _dbInitializer;
        private readonly string _connectionString; 

        public DemoDbContextFactory(IDatabaseInitializer<DemoDbContext> dbInitializer, string connectionString)
        {
            _dbInitializer = dbInitializer;
            _connectionString = connectionString;
        }


        public DemoDbContext Build()
        {
            if (!_hasSetInitializer)
            {
                System.Data.Entity.Database.SetInitializer<DemoDbContext>(_dbInitializer);
                _hasSetInitializer = true;
            }
            return new DemoDbContext(_connectionString);
        }

    }


}

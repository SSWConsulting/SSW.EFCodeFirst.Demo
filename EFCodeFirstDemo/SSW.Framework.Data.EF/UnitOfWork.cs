using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SSW.Framework.Data.Interfaces;


namespace SSW.Framework.Data.EF
{



    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        IEnumerable<IDbContextManager> _contextList;

        public UnitOfWork(IEnumerable<IDbContextManager> contextList)
        {
            _contextList = contextList;
        }

        public void SaveChanges()
        {
            foreach (var contextManager in _contextList)
            {
                if (contextManager.HasContext) contextManager.Context.SaveChanges();
            }
            
        }

        public void Dispose()
        {
            foreach (var contextManager in _contextList)
            {
                contextManager.Dispose();
            }
        }
    }
}

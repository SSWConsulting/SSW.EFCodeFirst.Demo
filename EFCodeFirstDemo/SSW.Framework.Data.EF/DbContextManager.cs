using System;
using System.Data.Entity;

namespace SSW.Framework.Data.EF
{


    


    public interface IDbContextManager : IDisposable
    {
        bool HasContext { get; }
        DbContext Context { get; }
    }

    public interface IDbContextManager<T> : IDbContextManager
    {
    }


    public class DbContextManager<T> : IDbContextManager<T> 
        where T : DbContext
    {

        IDbContextFactory<T> _factory;

        public DbContextManager(IDbContextFactory<T> factory)
        {
            _factory = factory;
        }

        T _context = default(T);
        public DbContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = _factory.Build();
                }
                return _context as DbContext;
            }
        }
        public bool HasContext
        {
            get
            {
                return _context != null;
            }
        }


        public void Dispose()
        {
            if (HasContext)
            {
                _context.Dispose();
                _context = null;
            }
        }

    }


    


}

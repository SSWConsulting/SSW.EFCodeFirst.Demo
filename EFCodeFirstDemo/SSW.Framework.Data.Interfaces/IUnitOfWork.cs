using System;

namespace SSW.Framework.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();

    }
}
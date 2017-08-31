using System;
using System.Data.Entity;

namespace PortfolioManagerClient.ProxyCloud.DAL.Interfacies
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }

        void Commit();
    }
}

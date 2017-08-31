using PortfolioManagerClient.ProxyCloud.DAL.Interfacies;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace PortfolioManagerClient.ProxyCloud.DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; private set; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            if (Context == null)
                throw new NullReferenceException(nameof(Context));

            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception("Validation exception. Try again.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Database don't save the data.", ex);
            }
        }

        public void Dispose()
        {
            if (Context == null)
                throw new NullReferenceException(nameof(Context));

            Context.Dispose();
            Context = null;
        }
    }
}

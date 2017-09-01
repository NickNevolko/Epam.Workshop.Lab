using Ninject;
using Ninject.Web.Common;
using PortfolioManagerClient.ProxyCloud.BLL.Interfacies.Services;
using PortfolioManagerClient.ProxyCloud.BLL.Services;
using PortfolioManagerClient.ProxyCloud.DAL.Concrete;
using PortfolioManagerClient.ProxyCloud.DAL.Concrete.Repositories;
using PortfolioManagerClient.ProxyCloud.DAL.Interfacies;
using PortfolioManagerClient.ProxyCloud.DAL.Interfacies.IRepositories;
using PortfolioManagerClient.ProxyCloud.Entities;
using System.Data.Entity;

namespace PortfolioManagerClient.ProxyCloud.DependencyResolver.Resolver
{
    public static class ResolverModule
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }

        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                kernel.Bind<DbContext>().To<EntityModel>().InRequestScope();
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                kernel.Bind<DbContext>().To<EntityModel>().InSingletonScope();
            }

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IShareService>().To<ShareService>();

            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IShareRepository>().To<ShareRepository>();
        }
    }
}

﻿using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PortfolioManagerClient.ProxyCloud.DependencyResolver.Resolver;

namespace PortfolioManagerClient.ProxyCloud.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            kernel.ConfigurateResolverWeb();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}
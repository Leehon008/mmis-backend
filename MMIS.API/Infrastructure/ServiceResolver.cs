using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.Windsor.MsDependencyInjection;
using MMIS.BusinessLogicLayer;
using Dashboard.CommonLayer;
using Dashboard.Core;
using MMIS.DataAccessLayer;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MMIS.API.Infrastructure
{
    public class ServiceResolver
    {
        private static WindsorContainer _container;
        private static IServiceProvider _provider;

        public ServiceResolver(IServiceCollection service)
        {
            _container = new WindsorContainer();

            _container.Install(FromAssembly.Containing<IMMISAPI>());
            _container.Install(FromAssembly.Containing<IMMISBusinessLogicLayer>());
            _container.Install(FromAssembly.Containing<IMMISCore>());
            _container.Install(FromAssembly.Containing<IMMISDataAccessLayer>());
            _container.Install(FromAssembly.Containing<IMMISCommonLayer>());

            _provider = WindsorRegistrationHelper.CreateServiceProvider(_container, service);
        }

        public IServiceProvider GetServiceProvider()
        {
            return _provider;
        }
    }
}

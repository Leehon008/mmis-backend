using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using MMIS.Core.Infrastructure.Contracts;
using MMIS.DataAccessLayer.Shared;
using MMIS.DataAccessLayer.Shared.Contracts;

namespace MMIS.DataAccessLayer._Installers
{
    public class ModuleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining<IMMISDataAccessLayer>().BasedOn(typeof(IRepository<>))
                .WithServiceAllInterfaces().LifestyleCustom<MsScopedLifestyleManager>());
            container.Register(Component.For<IUnitOfWork, IRunOnError>().ImplementedBy<UnitOfWork>().LifestyleCustom<MsScopedLifestyleManager>());
            container.Register(Component.For<MMISDbContext>().LifestyleCustom<MsScopedLifestyleManager>());
            container.Register(Component.For<IDeltaHttpClient>().ImplementedBy<DeltaHttpClient>().LifestyleCustom<MsScopedLifestyleManager>());
            container.Register(Component.For<IDeltaApi>().ImplementedBy<DeltaApi>().LifestyleCustom<MsScopedLifestyleManager>());
        }
    }
}

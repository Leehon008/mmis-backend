using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using MMIS.BusinessLogicLayer.Shared.Contracts;

namespace MMIS.BusinessLogicLayer._Installers
{
    public class ModuleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining<ILogic>().BasedOn<ILogic>().WithServiceAllInterfaces()
                .LifestyleCustom<MsScopedLifestyleManager>());
        }
    }
}

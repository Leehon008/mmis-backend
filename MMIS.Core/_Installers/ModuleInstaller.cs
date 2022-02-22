//using Castle.MicroKernel.Registration;
//using Castle.MicroKernel.SubSystems.Configuration;
//using Castle.Windsor;
//using Castle.Windsor.MsDependencyInjection;
//using MMIS.Core.Security;
//using MMIS.Core.Security.Contracts;

//namespace MMIS.Core._Installers
//{
//    public class ModuleInstaller : IWindsorInstaller
//    {
//        public void Install(IWindsorContainer container, IConfigurationStore store)
//        {
//            container.Register(Component.For<IJSONWebTokenGenerator>().ImplementedBy<JSONWebTokenGenerator>()
//                .LifestyleCustom<MsScopedLifestyleManager>());
//        }
//    }
//}

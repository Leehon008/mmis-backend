using AutoMapper;
using AutoMapper.Configuration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using MMIS.CommonLayer.Automapper.Contracts;
using MMIS.DomainLayer;
using System.Linq;

namespace MMIS.API._Installers
{
    public class AutoMapperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var config = ConfigMaps();
            var mapper = new Mapper(new MapperConfiguration(config));
            container.Register(Component.For<IMapper>().Instance(mapper).LifestyleCustom<MsScopedLifestyleManager>());
        }

        private MapperConfigurationExpression ConfigMaps()
        {
            using (var container = new WindsorContainer())
            {
                container.Register(Classes.FromAssemblyContaining<IMMISDomainLayer>().BasedOn<IHaveCustomMappings>().WithServiceAllInterfaces());

                var config = new MapperConfigurationExpression();
                container.ResolveAll<IHaveCustomMappings>()
                    .ToList()
                    .ForEach(x => x.CreateMaps(config));

                return config;
            }
        }
    }
}

using AutoMapper.Configuration;

namespace MMIS.CommonLayer.Automapper.Contracts
{
    public interface IHaveCustomMappings
    {
        void CreateMaps(MapperConfigurationExpression config);
    }
}

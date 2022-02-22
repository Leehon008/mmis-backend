namespace MMIS.CommonLayer.Automapper.Contracts
{
    public interface IMapTo
    {
        TDestination MapTo<TSource, TDestination>() where TDestination : class;
    }
}

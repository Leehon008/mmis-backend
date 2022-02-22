using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Shared.Contracts
{
    public interface IDeltaApi
    {
        Task<string> Authenticate();
    }
}

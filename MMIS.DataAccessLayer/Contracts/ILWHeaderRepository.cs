using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.DomainLayer.Entities.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Contracts
{
    public interface ILWHeaderRepository : IRepository<LossWasteHeader>
    {
        Task<List<LossWasteHeader>> GetData(string Id);
    }
}

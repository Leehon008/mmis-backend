using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.DomainLayer.Entities.Users;
using MMIS.DomainLayer.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Contracts
{
    public interface ILineRepository : IRepository<Lines>
    { 
        Task<List<Lines>> GetLineById(string Id);
    }
}

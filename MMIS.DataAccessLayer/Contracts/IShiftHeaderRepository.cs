using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.DomainLayer.Entities.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Contracts
{
    public interface IShiftHeaderRepository : IRepository<ShiftHeader>
    {
        Task<List<ShiftHeader>> GetActiveShifts(string Plant);
    }
}

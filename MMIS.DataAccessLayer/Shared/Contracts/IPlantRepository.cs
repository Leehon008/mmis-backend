using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Plants;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.DomainLayer.Entities.Users;
using MMIS.DomainLayer.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Shared.Contracts
{
    public interface IPlantRepository : IRepository<Plant>
    { 
        Task<List<Plant>> GetData();
    }
}

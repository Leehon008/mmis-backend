using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Shifts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Contracts
{
    public interface ICMPlannerRepository : IRepository<CMPlannerInput>
    {
        Task<List<CMPlannerInput>> GetDataAsync(string shifNo);
        public void Update(string id);
    }
}

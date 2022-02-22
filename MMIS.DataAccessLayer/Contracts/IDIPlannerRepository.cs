using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Shifts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Contracts
{
    public interface IDIPlannerRepository : IRepository<DIPlannerInput>
    {
        Task<List<DIPlannerInput>> GetDataAsync(string shifNo);
        public void Update(string id);
    }
}

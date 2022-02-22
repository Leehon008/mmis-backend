using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Shifts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Contracts
{
    public interface ICMArtisanRepository : IRepository<CMArtisanInput>
    {
        Task<List<CMArtisanInput>> GetDataAsync(string shifNo);
        public void Update(string id);
    }
}

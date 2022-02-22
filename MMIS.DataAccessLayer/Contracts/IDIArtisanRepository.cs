using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Shifts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Contracts
{
    public interface IDIArtisanRepository : IRepository<DIArtisanInput>
    {
        Task<List<DIArtisanInput>> GetDataAsync(string shifNo);
        public void Update(string id);
    }
}

using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Entities.Shifts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Shift
{
    public class LWHeaderRepository : RepositoryBase<LossWasteHeader>, ILWHeaderRepository
    {
        public LWHeaderRepository(MMISDbContext dbContext) : base(dbContext) { }

        public async Task<List<LossWasteHeader>> GetData(string Plant)
        {
            return  this.DbSet.ToList();
        }
    }
}

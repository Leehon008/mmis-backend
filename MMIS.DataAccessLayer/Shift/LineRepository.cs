using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MMIS.DomainLayer.Entities.Shifts;
using System.Collections.Generic;

namespace MMIS.DataAccessLayer.Shift
{
    public class LineRepository : RepositoryBase<Lines>,ILineRepository
    {
        public LineRepository(MMISDbContext dbContext) : base(dbContext) { }

        public async Task<List<Lines>> GetLineById(string PlantId)
        {
            return await this.DbSet.ToListAsync();
        }

      
    }
}

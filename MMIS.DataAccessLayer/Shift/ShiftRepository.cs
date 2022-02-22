using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MMIS.DomainLayer.Entities.Shifts;
using System.Collections.Generic;

namespace MMIS.DataAccessLayer.Shift
{
    public class ShiftRepository : RepositoryBase<Shifts>,IShiftRepository
    {
        public ShiftRepository(MMISDbContext dbContext) : base(dbContext) { }

        public async Task<List<Shifts>> GetShifts(string PlantId)
        {
            return await this.DbSet.ToListAsync();
        }

      
    }
}

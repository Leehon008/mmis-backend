using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Entities.Shifts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Shift
{
    public class ShiftHeaderRepository : RepositoryBase<ShiftHeader>, IShiftHeaderRepository
    {
        public ShiftHeaderRepository(MMISDbContext dbContext) : base(dbContext) { }

        public async Task<List<ShiftHeader>> GetActiveShifts(string Plant)
        {
            return  this.DbSet.ToList().Where(x=>x.PlantId == Plant).ToList();
        }
    }
}

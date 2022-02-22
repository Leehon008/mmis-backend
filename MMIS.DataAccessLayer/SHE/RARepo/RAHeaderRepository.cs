using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.DomainLayer.SHE.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Shift
{
    public class RAHeaderRepository : RepositoryBase<PreTaskRAHeader>, IPreTaskRARepository
    {
        public RAHeaderRepository(MMISDbContext dbContext) : base(dbContext) { }

    }
}

using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Entities.Shifts;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Shift
{
    public class PIMsPOMsRepository : RepositoryBase<PIMsPOMs>, IPIMsPOMsRepository
    {
        public PIMsPOMsRepository(MMISDbContext dbContext) : base(dbContext) { }

    }
}

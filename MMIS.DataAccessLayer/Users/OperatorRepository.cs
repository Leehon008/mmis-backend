using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MMIS.DomainLayer.Entities.Shifts;
using System.Collections.Generic;
using MMIS.DomainLayer.Models.Users;

namespace MMIS.DataAccessLayer.Users
{
    public class OperatorRepository : RepositoryBase<Operators>,IOperatorRepository
    {
        public OperatorRepository(MMISDbContext dbContext) : base(dbContext) { }

        public async Task<List<Operators>> GetOperators(string PlantId)
        {
            return await this.DbSet.ToListAsync();
        }

      
    }
}

using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using MMIS.DataAccessLayer.Contracts;

namespace MMIS.DataAccessLayer.Users
{
    public class TeamLeaderRepository : RepositoryBase<TeamLeaders>, ITeamLeadersRepository
    {
        public TeamLeaderRepository(MMISDbContext dbContext) : base(dbContext) { }

        public async Task<List<TeamLeaders >> GetTeamLeadersById(string PlantId)
        {
            return await this.DbSet.ToListAsync();
        }

      
    }
}

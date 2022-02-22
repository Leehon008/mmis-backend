using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared;
using System.Threading.Tasks;
using MMIS.DomainLayer.Entities.Users;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MMIS.DataAccessLayer.UserGroups
{
    public class UserGroupRepository : RepositoryBase<UserGroup>, IUserGroupRepository
    {
        public UserGroupRepository(MMISDbContext dbContext) : base(dbContext) { }

        public async Task<List<UserGroup>> GetData()
        {
            return await this.DbSet.ToListAsync();
        }
    }
}

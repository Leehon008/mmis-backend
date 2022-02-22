using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared;
using System.Threading.Tasks;
using MMIS.DomainLayer.Entities.Users;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace MMIS.DataAccessLayer.UserRoles
{
    public class UserRoleRepository : RepositoryBase<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(MMISDbContext dbContext) : base(dbContext) { }

        public async Task<List<UserRole>> GetData()
        {
            return await this.DbSet.ToListAsync();
        }
        public async Task<List<UserRole>> GetData(string id)
        {
            return this.DbSet.ToList().Where(i => i.RoleTypeDescription.Trim() == id.Trim()).ToList();
            
        }
    }
}

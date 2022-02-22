using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared;
using System.Threading.Tasks;
using MMIS.DomainLayer.Entities.Users;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MMIS.DataAccessLayer.UserTypes
{
    public class UserTypeRepository : RepositoryBase<UserType>, IUserTypeRepository
    {
        public UserTypeRepository(MMISDbContext dbContext) : base(dbContext) { }

        public async Task<List<UserType>> GetData()
        {
            return await this.DbSet.ToListAsync();
        }
    }
}

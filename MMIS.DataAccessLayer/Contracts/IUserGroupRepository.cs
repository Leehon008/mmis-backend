using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Contracts
{
    public interface IUserGroupRepository : IRepository<UserGroup>
    {
        Task<List<UserGroup>> GetData();
    }
}

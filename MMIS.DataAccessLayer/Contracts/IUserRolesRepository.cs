using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Contracts
{
    public interface IUserRoleRepository : IRepository<UserRole>
    {
        Task<List<UserRole>> GetData();
        Task<List<UserRole>> GetData(string id);
    }
}

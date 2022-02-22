using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Contracts
{
    public interface IUserTypeRepository : IRepository<UserType>
    {
        Task<List<UserType>> GetData();
    }
}

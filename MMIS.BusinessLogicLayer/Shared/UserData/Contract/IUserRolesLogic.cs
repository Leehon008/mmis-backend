using MMIS.BusinessLogicLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.Shared.UserData.Contract
{
    public interface IUserRoleLogic : ILogic
    {
        Task<List<UserRole>> GetData();
        Task<List<UserRole>> GetData(string id);



    }
}

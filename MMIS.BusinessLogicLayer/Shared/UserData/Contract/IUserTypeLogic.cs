using MMIS.BusinessLogicLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.Shared.UserData.Contract
{
    public interface IUserTypeLogic : ILogic
    {
        Task<List<UserType>> GetData();
       


    }
}

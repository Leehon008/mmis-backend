using MMIS.BusinessLogicLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.DomainLayer.Models.Shift;
using MMIS.DomainLayer.Models.Users;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.Operators.Contract
{
    public interface IOperatorLogic : ILogic
    {
        Task<PersonnelResultDto> GetOperators(string PlantId,string moduleId);
        Task<PersonnelResultDto> GetOperators(string PlantId);


    }
}

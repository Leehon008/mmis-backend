using MMIS.BusinessLogicLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Plants;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.DomainLayer.Models.Shift;
using MMIS.DomainLayer.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.Shared.PlantData.Contract
{
    public interface IPlantLogic : ILogic
    {
        Task<List<Plant>> GetData();
       


    }
}

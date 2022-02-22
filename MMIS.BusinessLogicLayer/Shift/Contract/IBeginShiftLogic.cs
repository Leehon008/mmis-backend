using MMIS.BusinessLogicLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.DomainLayer.Models.Shift;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.Shift.Contract
{
    public interface IBeginShiftLogic : ILogic
    {
        Task<ShiftResultDto> BeginShift(ShiftHeader model);
        Task<List<ShiftHeader>> GetActiveShifts(string Plant);
        Task<List<ShiftHeader>> GetShifts(string Plant, string moduleId);
        Task<ShiftHeader> GetShift(string Id);


    }
}

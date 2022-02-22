using MMIS.BusinessLogicLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Shifts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.Shift.Contract
{
    public interface IShiftMeetingsLogic : ILogic
    {
        Task<List<ShiftMeetingActions>> GetMeetingActions(string shiftName);
        ShiftMeetingActions GetActionItemById(string Id);
        public void UpdateActionItem(ShiftMeetingActions model);
        public void UpdateTaskItem(string id);
    }
}

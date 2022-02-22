using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.DomainLayer.Entities.Users;
using MMIS.DomainLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Contracts
{
    public interface IShiftMeetingRepository : IRepository<ShiftMeetingActions>
    { 
        Task<List<ShiftMeetingActions>> GetShiftMeetingActions(string ShiftName);
        ShiftMeetingActions GetActionItemById(string Id);
        public void UpdateActionItem(ShiftMeetingActions model);
        public void UpdateTaskItem(string id);
        
    }
}

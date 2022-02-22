using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MMIS.DomainLayer.Entities.Shifts;
using System.Collections.Generic;
using System;

namespace MMIS.DataAccessLayer.Shift
{
    public class ShiftMeetingRepostory : RepositoryBase<ShiftMeetingActions>,IShiftMeetingRepository
    {
        public ShiftMeetingRepostory(MMISDbContext dbContext) : base(dbContext) { }

        public async Task<List<ShiftMeetingActions>> GetShiftMeetingActions(string ShiftName)
        {
            return await this.DbSet.ToListAsync();
        }

        public ShiftMeetingActions GetActionItemById(string Id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateActionItem(ShiftMeetingActions model)
        {
            Update(model);
        }

        public void UpdateTaskItem(string id)
        {
            UpdateItem(id);
        }
    }
}

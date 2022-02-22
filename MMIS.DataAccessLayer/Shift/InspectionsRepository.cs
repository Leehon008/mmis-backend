using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Entities.Shifts;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Shift
{
    public class InspectionsRepository : RepositoryBase<Inspections>, IInspectionRepository
    {
        public InspectionsRepository(MMISDbContext dbContext) : base(dbContext) { }

        public async Task<List<Inspections>> GetInspectionsAsync(string shifNo)
        {
            return  this.DbSet.ToList().Where(i=>i.ShiftNo == shifNo && i.Status =="Not Done").ToList();
        }

        public async Task<List<Inspections>> GetInspectionsAsync(string shifNo,string user)
        {
            return this.DbSet.ToList().Where(i => i.ShiftNo == shifNo && i.Status == "Not Done" && i.AssignedTo == user).ToList();
        }
        public void UpdateWorkAssignments(string id)
        {
            UpdateWA(id);
        }
    }
}

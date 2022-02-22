using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Shifts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Contracts
{
    public interface IInspectionRepository : IRepository<Inspections>
    {
        Task<List<Inspections>> GetInspectionsAsync(string shifNo);
        Task<List<Inspections>> GetInspectionsAsync(string shifNo, string user);
        public void UpdateWorkAssignments(string id);
    }
}

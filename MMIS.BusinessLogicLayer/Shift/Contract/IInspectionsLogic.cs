using MMIS.BusinessLogicLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.DomainLayer.Models.Shift;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.Shift.Contract
{
    public interface IInspectionsLogic : ILogic
    {
       ShiftResultDto CreateInspections(List<Inspections> model);
      List<Inspections> GetInspections(string ShiftNo);
        List<Inspections> GetInspections(string ShiftNo,string user);
        public void UpdateWorkAssignments(string id);


    }
}

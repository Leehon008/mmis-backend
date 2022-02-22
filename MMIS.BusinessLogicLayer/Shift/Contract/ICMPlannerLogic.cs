using MMIS.BusinessLogicLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.DomainLayer.Models.Shift;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.Shift.Contract
{
    public interface ICMPlannerLogic : ILogic
    {
        ShiftResultDto Create(List<CMPlannerInput> model);
        List<CMPlannerInput> Get(string Id);
        public void Update(string id);



    }
}

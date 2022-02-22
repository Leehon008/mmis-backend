using MMIS.BusinessLogicLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.DomainLayer.Models.Shift;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.Shift.Contract
{
    public interface IDIArtisanLogic : ILogic
    {
       ShiftResultDto Create(List<DIArtisanInput> model);
      List<DIArtisanInput> Get(string Id);
        public void Update(string id);


    }
}

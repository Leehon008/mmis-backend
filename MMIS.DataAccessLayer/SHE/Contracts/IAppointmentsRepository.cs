using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.SHE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Contracts
{
    public interface IAppointmentsRepository : IRepository<Appointments>
    {
         Task<List<Appointments>> GetData();
    }
}

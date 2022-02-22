using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.SHE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.SHE
{
    public class ApointmentsRepository : RepositoryBase<Appointments>, IAppointmentsRepository
    {
        public ApointmentsRepository(MMISDbContext dbContext) : base(dbContext) { }
        public async Task<List<Appointments>> GetData()
        {
            return await this.DbSet.ToListAsync();
        }

    }
}

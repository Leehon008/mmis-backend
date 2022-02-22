using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MMIS.DomainLayer.Entities.Shifts;
using System.Collections.Generic;
using MMIS.DomainLayer.Entities.Plants;
using MMIS.DataAccessLayer.Shared.Contracts;
using System.Linq.Expressions;
using System;
using System.Linq;

namespace MMIS.DataAccessLayer.Shared.PlantData
{
    public class PlantRepository : RepositoryBase<Plant>, IPlantRepository
    {
        public PlantRepository(MMISDbContext dbContext) : base(dbContext) { }

        public async Task<List<Plant>> GetData()
        {
            return await this.DbSet.ToListAsync();
        }

    }
}
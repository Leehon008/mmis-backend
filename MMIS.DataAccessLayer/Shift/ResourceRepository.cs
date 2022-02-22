using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MMIS.DomainLayer.Entities.Shifts;
using System.Collections.Generic;
using System.Linq;

namespace MMIS.DataAccessLayer.Shift
{
    public class ResourceRepository : RepositoryBase<Resources>,IResourceRepository
    {
        public ResourceRepository(MMISDbContext dbContext) : base(dbContext) { }

        public  List<Resources> GetResources(string resId)
        {
            return  this.DbSet.ToList().Where(x=>x.ResourceCategoryId == resId).ToList();
        }

      
    }
}

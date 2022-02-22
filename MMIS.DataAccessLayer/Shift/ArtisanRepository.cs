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
    public class ArtisanRepository : RepositoryBase<DIArtisanInput>, IDIArtisanRepository
    {
        public ArtisanRepository(MMISDbContext dbContext) : base(dbContext) { }

        public async Task<List<DIArtisanInput>> GetDataAsync(string shifNo)
        {
            return  this.DbSet.ToList().Where(i=>i.ShiftNo == shifNo).ToList();
        }
        public void Update(string id)
        {
            UpdateWA(id);
        }
    }
}

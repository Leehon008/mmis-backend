using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.SHE.Entities;

namespace MMIS.DataAccessLayer.Shift
{
    public class IssueBasedRepository : RepositoryBase<IssueBasedRAHeader>, IIssueBasedRARepository
    {
        public IssueBasedRepository(MMISDbContext dbContext) : base(dbContext) { }

    }
}

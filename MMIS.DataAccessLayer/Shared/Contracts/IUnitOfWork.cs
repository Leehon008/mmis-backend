using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Shared.Contracts
{
    public interface IUnitOfWork
    {
        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
        void Commit();
        void Rollback();
        void CommitInnerTransaction();
    }
}

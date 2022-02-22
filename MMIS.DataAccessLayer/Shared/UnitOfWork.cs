using MMIS.DataAccessLayer.Shared.Contracts;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Shared
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MMISDbContext _dbContext;

        public UnitOfWork(MMISDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }

        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return _dbContext.Database.BeginTransactionAsync();
        }

        public void Commit()
        {
            try
            {
                _dbContext.SaveChanges();
                _dbContext.Database.CommitTransaction();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        public void CommitInnerTransaction()
        {
            this.Commit();
            this.BeginTransaction();
        }

        public void Rollback()
        {
            _dbContext.Database.RollbackTransaction();
        }
    }
}

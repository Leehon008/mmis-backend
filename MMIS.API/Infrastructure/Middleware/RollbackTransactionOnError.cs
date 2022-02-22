using MMIS.Core.Infrastructure.Contracts;
using MMIS.DataAccessLayer.Shared.Contracts;
using Microsoft.AspNetCore.Http;

namespace MMIS.API.Infrastructure.Middleware
{
    public class RollbackTransactionOnError : IRunOnError
    {
        private readonly IUnitOfWork _unitOfWork;

        public RollbackTransactionOnError(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Execute(HttpContext context)
        {
            _unitOfWork.Rollback();
        }
    }
}

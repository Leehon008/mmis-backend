using MMIS.DataAccessLayer.Shared.Contracts;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MMIS.API.Infrastructure.Middleware
{
    public class UnitOfWorkMiddleware
    {
        private readonly RequestDelegate _request;

        public UnitOfWorkMiddleware(RequestDelegate request)
        {
            _request = request;
        }

        public async Task Invoke(HttpContext context)
        {
            var unitOfWork = context.RequestServices.GetService(typeof(IUnitOfWork)) as IUnitOfWork;
            unitOfWork?.BeginTransaction();
            await _request(context);
            unitOfWork?.Commit();
        }
    }
}

using Microsoft.AspNetCore.Http;

namespace MMIS.Core.Infrastructure.Contracts
{
    public interface IRunOnError
    {
        void Execute(HttpContext context);
    }
}

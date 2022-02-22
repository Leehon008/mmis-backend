using System.Net.Http;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Shared.Contracts
{
    public interface IDeltaHttpClient
    {
        Task<string> Authenticate();
        Task<HttpResponseMessage> PostAsync(string url, HttpContent content);
        Task<HttpResponseMessage> PutAsync(string url, HttpContent content);
        Task<HttpResponseMessage> PatchAsync(string url, HttpContent content);
        Task<HttpResponseMessage> GetAsync(string url);
    }
}

using MMIS.CommonLayer.Settings;
using MMIS.DataAccessLayer.Shared.Contracts;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Shared
{
    public class DeltaApi : IDeltaApi
    {
        private readonly AppSettings _appSettings;
        private readonly IDeltaHttpClient _deltaHttpClient;

        public DeltaApi(IOptions<AppSettings> appSettings, IDeltaHttpClient deltaHttpClient)
        {
            _appSettings = appSettings.Value;
            _deltaHttpClient = deltaHttpClient;
        }

        public async Task<string> Authenticate()
        {
            return await _deltaHttpClient.Authenticate();
        }
    }
}

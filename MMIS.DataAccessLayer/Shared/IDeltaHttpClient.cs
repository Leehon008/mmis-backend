using MMIS.CommonLayer.Settings;
using MMIS.DataAccessLayer.Shared.Contracts;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Shared
{
    public class DeltaHttpClient : IDeltaHttpClient
    {
        private readonly IMemoryCache _memoryCache;
        private readonly AppSettings _appSettings;

        public DeltaHttpClient(IMemoryCache memoryCache, IOptions<AppSettings> appSettings)
        {
            _memoryCache = memoryCache;
            _appSettings = appSettings.Value;
        }

        private void AddAuthorizationHeader(HttpClient httpClient)
        {
            var token = _memoryCache.Get<string>("token");
            if (string.IsNullOrEmpty(token))
            {
                token = Authenticate().Result;
                _memoryCache.Set("token", token, DateTimeOffset.Now.AddHours(7));
            }
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }

        public async Task<string> Authenticate()
        {
            using (var client = new HttpClient())
            {
                var result = client.PostAsync($"{_appSettings.WebApiUrl}/token",
                    new StringContent(
                        $"grant_type=password&username={_appSettings.WebApiUsername}&password={_appSettings.WebApiPassword}",
                        Encoding.UTF8, "application/x-www-form-urlencoded")).Result;
                var content = await result.Content.ReadAsStringAsync();
                var authResult = new { access_token = "" };
                var token = JsonConvert.DeserializeAnonymousType(content, authResult).access_token;

                return token;
            }
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                AddAuthorizationHeader(httpClient);
                var result = await httpClient.GetAsync($"{_appSettings.WebApiUrl}/{url}");
                return result;
            }
        }

        public async Task<HttpResponseMessage> PatchAsync(string url, HttpContent content)
        {
            using (var httpClient = new HttpClient())
            {
                AddAuthorizationHeader(httpClient);
                var result = await httpClient.PatchAsync($"{_appSettings.WebApiUrl}/{url}", content);
                return result;
            }
        }

        public async Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            using (var httpClient = new HttpClient())
            {
                AddAuthorizationHeader(httpClient);
                var result = await httpClient.PostAsync($"{_appSettings.WebApiUrl}/{url}", content);
                return result;
            }
        }

        public async Task<HttpResponseMessage> PutAsync(string url, HttpContent content)
        {
            using (var httpClient = new HttpClient())
            {
                AddAuthorizationHeader(httpClient);
                var result = await httpClient.PutAsync($"{_appSettings.WebApiUrl}/{url}", content);
                return result;
            }
        }
    }
}

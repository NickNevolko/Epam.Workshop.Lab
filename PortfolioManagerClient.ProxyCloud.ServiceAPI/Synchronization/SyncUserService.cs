using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PortfolioManagerClient.ProxyCloud.ServiceAPI.Synchronization
{
    public class SyncUserService
    {
        private static readonly string CreateUrl = "Users";

        private readonly string _serviceApiUrl =
            ConfigurationManager.AppSettings["PortfolioManagerServiceUrl"];

        private readonly HttpClient _httpClient;

        public SyncUserService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public int Create(string userName)
        {
            var response = _httpClient.PostAsJsonAsync(_serviceApiUrl + CreateUrl, userName).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsAsync<int>().Result;
        }
    }
}
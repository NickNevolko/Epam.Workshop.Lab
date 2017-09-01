using System.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using PortfolioManagerClient.ProxyCloud.ServiceAPI.Models;

namespace PortfolioManagerClient.ProxyCloud.ServiceAPI.Synchronization
{
    public class SyncShareService
    {
        private static readonly string GetAllUrl = "PortfolioItems?userId={0}";
        private static readonly string UpdateUrl = "PortfolioItems";
        private static readonly string CreateUrl = "PortfolioItems";
        private static readonly string DeleteUrl = "PortfolioItems/{0}";

        private readonly string _serviceApiUrl =
            ConfigurationManager.AppSettings["PortfolioManagerServiceUrl"];

        private readonly HttpClient _httpClient;

        public SyncShareService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public IList<PortfolioItemModel> GetItems(int userId)
        {
            var dataAsString = _httpClient.GetStringAsync(string.Format(_serviceApiUrl + GetAllUrl, userId)).Result;
            return JsonConvert.DeserializeObject<IList<PortfolioItemModel>>(dataAsString);
        }

        public void Create(PortfolioItemModel item)
        {
            _httpClient.PostAsJsonAsync(_serviceApiUrl + CreateUrl, item)
                .Result.EnsureSuccessStatusCode();
        }

        public void Update(PortfolioItemModel item)
        {
            _httpClient.PutAsJsonAsync(_serviceApiUrl + UpdateUrl, item)
                .Result.EnsureSuccessStatusCode();
        }

        public void Delete(int id)
        {
            _httpClient.DeleteAsync(string.Format(_serviceApiUrl + DeleteUrl, id))
                .Result.EnsureSuccessStatusCode();
        }
    }
}
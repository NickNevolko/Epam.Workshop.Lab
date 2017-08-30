using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using PortfolioManagerClient.Models;
using System.Threading.Tasks;

namespace PortfolioManagerClient.Services
{
    /// <summary>
    /// Works with portfolio backend.
    /// </summary>
    public class PortfolioItemsService
    {
        public static List<PortfolioItemViewModel> NameAndCount = new List<PortfolioItemViewModel>();


        /// <summary>
        /// The url for getting all portfolio items.
        /// </summary>
        private const string GetAllUrl = "PortfolioItems?userId={0}";

        /// <summary>
        /// The url for updating a portfolio item.
        /// </summary>
        private const string UpdateUrl = "PortfolioItems";

        /// <summary>
        /// The url for a portfolio item's creation.
        /// </summary>
        private const string CreateUrl = "PortfolioItems";

        /// <summary>
        /// The url for a portfolio item's deletion.
        /// </summary>
        private const string DeleteUrl = "PortfolioItems/{0}";

        /// <summary>
        /// The service URL.
        /// </summary>
        private readonly string _serviceApiUrl = ConfigurationManager.AppSettings["PortfolioManagerServiceUrl"];

        private readonly HttpClient _httpClient;

        /// <summary>
        /// Creates the service.
        /// </summary>
        public PortfolioItemsService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Gets all portfolio items for the user.
        /// </summary>
        /// <param name="userId">The User Id.</param>
        /// <returns>The list of portfolio items.</returns>
        public IList<PortfolioItemViewModel> GetItems(int userId)
        {
            if (NameAndCount.Count > 0)
                return NameAndCount;

            var dataAsString = _httpClient.GetStringAsync(string.Format(_serviceApiUrl + GetAllUrl, userId)).Result;
            NameAndCount = JsonConvert.DeserializeObject<List<PortfolioItemViewModel>>(dataAsString);
            return NameAndCount;
        }

        /// <summary>
        /// Creates a portfolio item. UserId is taken from the model.
        /// </summary>
        /// <param name="item">The portfolio item to create.</param>
        public void CreateItem(PortfolioItemViewModel item)
        {
            NameAndCount.Add(item);

            Task.Run(() => _httpClient.PostAsJsonAsync(_serviceApiUrl + CreateUrl, item)
                .Result.EnsureSuccessStatusCode());
        }

        /// <summary>
        /// Updates a portfolio item.
        /// </summary>
        /// <param name="item">The portfolio item to update.</param>
        public void UpdateItem(PortfolioItemViewModel item)
        {
            var itemIndex = NameAndCount.FindIndex(x => x.ItemId == item.ItemId);
            if (itemIndex != -1)
            {
                NameAndCount[itemIndex] = item;

                Task.Run(() => _httpClient.PutAsJsonAsync(_serviceApiUrl + UpdateUrl, item)
                    .Result.EnsureSuccessStatusCode());
            }
        }

        /// <summary>
        /// Deletes a portfolio item.
        /// </summary>
        /// <param name="id">The portfolio item Id to delete.</param>
        public void DeleteItem(int id)
        {
            var itemIndex = NameAndCount.FindIndex(x => x.ItemId == id);
            if (itemIndex != -1)
            {
                NameAndCount.RemoveAt(itemIndex);

                Task.Run(() => _httpClient.DeleteAsync(string.Format(_serviceApiUrl + DeleteUrl, id))
                    .Result.EnsureSuccessStatusCode());
            }
        }
    }
}

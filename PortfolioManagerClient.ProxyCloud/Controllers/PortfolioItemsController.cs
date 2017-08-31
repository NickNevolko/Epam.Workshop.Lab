using System.Collections.Generic;
using System.Web.Http;
using PortfolioManagerClient.ProxyCloud.Models;

namespace PortfolioManagerClient.ProxyCloud.Controllers
{
    public class PortfolioItemsController : ApiController
    {
        public PortfolioItemsController()
        {
        }
        
        public IList<PortfolioItemViewModel> Get(int? userId = null)
        {
            if (userId == null)
                return new List<PortfolioItemViewModel>();

            // TODO Sync via ConcurrentQueue<T>

            return new List<PortfolioItemViewModel>() { new PortfolioItemViewModel() { Symbol = "hello", SharesNumber = 123 } };
        }
        
        public void Post(PortfolioItemViewModel model)
        {
            if (model == null)
                return;

            //TODO Create
        }
        
        public void Put(PortfolioItemViewModel model)
        {
            if (model == null)
                return;

            // TODO Update
        }
        
        public void Delete(int id)
        {
            if (id < 0)
                return;

            // TODO Delete
        }
    }
}

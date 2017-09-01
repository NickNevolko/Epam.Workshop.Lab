using System.Collections.Generic;
using System.Web.Http;
using PortfolioManagerClient.ProxyCloud.Models;
using PortfolioManagerClient.ProxyCloud.BLL.Interfacies.Services;
using PortfolioManagerClient.ProxyCloud.Infrastructure.Mappers.PortfolioItemsMapper;
using PortfolioManagerClient.ProxyCloud.ServiceAPI.Synchronization;
using PortfolioManagerClient.ProxyCloud.ServiceAPI.Mappers;

namespace PortfolioManagerClient.ProxyCloud.Controllers
{
    public class PortfolioItemsController : ApiController
    {
        private IUserService _userService;
        private IShareService _shareService;

        public PortfolioItemsController(IUserService userService, IShareService shareService)
        {
            _userService = userService;
            _shareService = shareService;
        }

        public IList<PortfolioItemViewModel> Get(int? userId = null)
        {
            if (userId == null)
                return new List<PortfolioItemViewModel>();

            var bllUser = _userService.GetUserById((int)userId);

            new SyncShareService().GetItems((int)userId);
            return bllUser?.Shares.ToPortfolioItemViewModelList();
        }

        public void Post(PortfolioItemViewModel model)
        {
            if (model == null)
                return;

            _shareService.Create(model.PortfolioItemToBllShare());
            new SyncShareService().Create(model.ViewToModel());
        }

        public void Put(PortfolioItemViewModel model)
        {
            if (model == null)
                return;

            _shareService.Update(model.PortfolioItemToBllShare());
            new SyncShareService().Update(model.ViewToModel());
        }

        public void Delete(int id)
        {
            if (id < 0)
                return;

            _shareService.Delete(id);
            new SyncShareService().Delete(id);
        }
    }
}

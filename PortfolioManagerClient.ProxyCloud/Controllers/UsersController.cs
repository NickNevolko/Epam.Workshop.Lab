using PortfolioManagerClient.ProxyCloud.BLL.Entities;
using PortfolioManagerClient.ProxyCloud.BLL.Interfacies.Services;
using PortfolioManagerClient.ProxyCloud.Infrastructure.Mappers.UsersMapper;
using PortfolioManagerClient.ProxyCloud.Models;
using PortfolioManagerClient.ProxyCloud.ServiceAPI.Synchronization;
using System.Web.Http;

namespace PortfolioManagerClient.ProxyCloud.Controllers
{
    public class UsersController : ApiController
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public UserViewModel Get(int? userId = null)
        {
            if (userId != null)
                return _userService.GetUserById((int)userId)?.BllUserToUser();

            return null;
        }

        public int Post([FromBody]string userName)
        {
            var user = new BllUser() { Name = userName };

            _userService.Create(user);
            new SyncUserService().Create(userName);

            return _userService.GetUserByName(userName).Id;
        }
    }
}

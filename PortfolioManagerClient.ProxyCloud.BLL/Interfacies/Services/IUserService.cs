using PortfolioManagerClient.ProxyCloud.BLL.Entities;
using System.Collections.Generic;

namespace PortfolioManagerClient.ProxyCloud.BLL.Interfacies.Services
{
    public interface IUserService
    {
        IEnumerable<BllUser> GetAll();
        BllUser GetUserById(int id);
        void Create(BllUser user);
        BllUser GetUserByName(string userName);
    }
}

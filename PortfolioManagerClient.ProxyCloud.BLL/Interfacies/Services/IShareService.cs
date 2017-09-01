using PortfolioManagerClient.ProxyCloud.BLL.Entities;

namespace PortfolioManagerClient.ProxyCloud.BLL.Interfacies.Services
{
    public interface IShareService
    {
        void Create(BllShare share);
        void Update(BllShare bllShare);
        void Delete(int id);
    }
}

using PortfolioManagerClient.ProxyCloud.DAL.DTO;

namespace PortfolioManagerClient.ProxyCloud.DAL.Interfacies.IRepositories
{
    public interface IUserRepository : IRepository<DalUser>
    {
        DalUser GetByName(string userName);
    }
}

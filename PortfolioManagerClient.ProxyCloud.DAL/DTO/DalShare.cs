using PortfolioManagerClient.ProxyCloud.DAL.Interfacies;

namespace PortfolioManagerClient.ProxyCloud.DAL.DTO
{
    public class DalShare : IEntity
    {
        public int Id { get; set; }

        public DalUser User { get; set; }

        public string Symbol { get; set; }

        public int SharesNumber { get; set; }
    }
}

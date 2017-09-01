using PortfolioManagerClient.ProxyCloud.DAL.Interfacies;
using System.Collections.Generic;

namespace PortfolioManagerClient.ProxyCloud.DAL.DTO
{
    public class DalUser : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<DalShare> Shares { get; set; }
    }
}

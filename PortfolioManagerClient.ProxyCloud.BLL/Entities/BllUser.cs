using System.Collections.Generic;

namespace PortfolioManagerClient.ProxyCloud.BLL.Entities
{
    public class BllUser
    {
        public int Id { get; set; }

        public IEnumerable<BllShare> Shares { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioManagerClient.ProxyCloud.Entities
{
    public class DbShare
    {
        public int Id { get; set; }

        [ForeignKey("ManagerId")]
        public virtual DbUser User { get; set; }

        public string Symbol { get; set; }

        public int SharesNumber { get; set; }
    }
}

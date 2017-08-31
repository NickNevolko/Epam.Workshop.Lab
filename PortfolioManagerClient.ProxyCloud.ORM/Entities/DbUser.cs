using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioManagerClient.ProxyCloud.Entities
{
    public class DbUser
    {
        public int Id { get; set; }

        [InverseProperty("DbUserId")]
        public virtual ICollection<DbShare> Shares { get; set; }
    }
}

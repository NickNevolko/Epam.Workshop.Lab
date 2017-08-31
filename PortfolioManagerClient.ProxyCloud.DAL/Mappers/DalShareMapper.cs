using PortfolioManagerClient.ProxyCloud.DAL.DTO;
using PortfolioManagerClient.ProxyCloud.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PortfolioManagerClient.ProxyCloud.DAL.Mappers
{
    public static class DbShareMapper
    {
        public static DalShare ToDalShare(this DbShare dbShare)
        {
            return new DalShare()
            {
                Id = dbShare.Id,
                User = dbShare.User.ToDalUser(),
                SharesNumber = dbShare.SharesNumber,
                Symbol = dbShare.Symbol
            };
        }

        public static DbShare ToDbShare(this DalShare dalShare)
        {
            return new DbShare()
            {
                Id = dalShare.Id,
                User = dalShare.User.ToDbUser(),
                SharesNumber = dalShare.SharesNumber,
                Symbol = dalShare.Symbol
            };
        }

        public static IEnumerable<DalShare> ToDalShareEnumerable(this ICollection<DbShare> dbShares)
        {
            return dbShares?.Select(x => x.ToDalShare());
        }

        public static ICollection<DbShare> ToDbShareCollection(this IEnumerable<DalShare> dalShares)
        {
            return dalShares?.Select(x => x.ToDbShare()) as ICollection<DbShare>;
        }
    }
}

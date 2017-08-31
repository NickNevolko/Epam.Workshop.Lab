using PortfolioManagerClient.ProxyCloud.BLL.Entities;
using PortfolioManagerClient.ProxyCloud.DAL.DTO;
using System.Collections.Generic;
using System.Linq;

namespace PortfolioManagerClient.ProxyCloud.BLL.Mappers
{
    public static class BllShareMapper
    {
        public static BllShare ToBllShare(this DalShare dbShare)
        {
            return new BllShare()
            {
                Id = dbShare.Id,
                User = dbShare.User.ToBllUser(),
                SharesNumber = dbShare.SharesNumber,
                Symbol = dbShare.Symbol
            };
        }

        public static DalShare ToDalShare(this BllShare dalShare)
        {
            return new DalShare()
            {
                Id = dalShare.Id,
                User = dalShare.User.ToDalUser(),
                SharesNumber = dalShare.SharesNumber,
                Symbol = dalShare.Symbol
            };
        }

        public static IEnumerable<BllShare> ToBllShareEnumerable(this IEnumerable<DalShare> dbShares)
        {
            return dbShares?.Select(x => x.ToBllShare());
        }

        public static IEnumerable<DalShare> ToDalShareEnumerable(this IEnumerable<BllShare> bllTasks)
        {
            return bllTasks?.Select(x => x.ToDalShare());
        }
    }
}

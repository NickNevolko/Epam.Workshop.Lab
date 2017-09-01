using PortfolioManagerClient.ProxyCloud.BLL.Entities;
using PortfolioManagerClient.ProxyCloud.Models;
using System.Collections.Generic;
using System.Linq;

namespace PortfolioManagerClient.ProxyCloud.Infrastructure.Mappers.PortfolioItemsMapper
{
    public static class PortfolioItemMapper
    {
        public static BllShare PortfolioItemToBllShare(this PortfolioItemViewModel portfolioItem)
        {
            return new BllShare()
            {
                Id = portfolioItem.ItemId,
                SharesNumber = portfolioItem.SharesNumber,
                Symbol = portfolioItem.Symbol
            };
        }

        public static PortfolioItemViewModel BllShareToPortfolioItem(this BllShare bllShare)
        {
            return new PortfolioItemViewModel()
            {
                ItemId = bllShare.Id,
                SharesNumber = bllShare.SharesNumber,
                Symbol = bllShare.Symbol,
                UserId = bllShare.User.Id
            };
        }

        public static IList<PortfolioItemViewModel> ToPortfolioItemViewModelList(this IEnumerable<BllShare> bllShares)
        {
            return bllShares?.Select(x => x.BllShareToPortfolioItem()) as IList<PortfolioItemViewModel>;
        }

        public static IEnumerable<BllShare> ToBllShareEnumerable(this IList<PortfolioItemViewModel> dbShares)
        {
            return dbShares?.Select(x => x.PortfolioItemToBllShare());
        }
    }
}
using PortfolioManagerClient.ProxyCloud.Models;
using PortfolioManagerClient.ProxyCloud.ServiceAPI.Models;

namespace PortfolioManagerClient.ProxyCloud.ServiceAPI.Mappers
{
    public static class PortfolioItemModelMapper
    {
        public static PortfolioItemViewModel ModelToView(this PortfolioItemModel portfolioItem)
        {
            return new PortfolioItemViewModel()
            {
                ItemId = portfolioItem.ItemId,
                SharesNumber = portfolioItem.SharesNumber,
                Symbol = portfolioItem.Symbol
            };
        }

        public static PortfolioItemModel ViewToModel(this PortfolioItemViewModel bllShare)
        {
            return new PortfolioItemModel()
            {
                ItemId = bllShare.ItemId,
                SharesNumber = bllShare.SharesNumber,
                Symbol = bllShare.Symbol
            };
        }
    }
}

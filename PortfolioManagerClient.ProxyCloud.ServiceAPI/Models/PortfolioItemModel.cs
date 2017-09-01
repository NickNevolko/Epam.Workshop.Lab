namespace PortfolioManagerClient.ProxyCloud.ServiceAPI.Models
{
    public class PortfolioItemModel
    {
        public int ItemId { get; set; }

        public int UserId { get; set; }

        public string Symbol { get; set; }

        public int SharesNumber { get; set; }
    }
}
namespace PortfolioManagerClient.ProxyCloud.BLL.Entities
{
    public class BllShare
    {
        public int Id { get; set; }

        public BllUser User { get; set; }

        public string Symbol { get; set; }

        public int SharesNumber { get; set; }
    }
}

using System.Web.Http;
using System.Web.Mvc;

namespace PortfolioManagerClient.ProxyCloud
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}

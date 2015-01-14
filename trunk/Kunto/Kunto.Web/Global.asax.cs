using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Kunto.Web
{
    /// <summary>
    /// </summary>
    public class KuntoMvcApplication : HttpApplication
    {
        #region Methods

        /// <summary>
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        #endregion
    }
}
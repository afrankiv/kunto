using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Kunto.Web
{
    /// <summary>
    /// Application routings configuration.
    /// </summary>
    public class RouteConfig
    {
        #region Public Methods and Operators

        /// <summary>
        /// Registers the routes.
        /// </summary>
        /// <param name="routes">
        /// The routes.
        /// </param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // routes.Add(new Route("handler/{*path}", new CustomRouteHandler { HandlerType = typeof(DayOfWeekHandler) }));
            routes.MapRoute("Default", "{controller}/{action}/{id}", 
                new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }

        #endregion
    }

    /// <summary>
    /// </summary>
    internal class CustomRouteHandler : IRouteHandler
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the type of the handler.
        /// </summary>
        /// <value>
        /// The type of the handler.
        /// </value>
        public Type HandlerType { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Provides the object that processes the request.
        /// </summary>
        /// <param name="requestContext">
        /// An object that encapsulates information about the
        /// request.
        /// </param>
        /// <returns>
        /// An object that processes the request.
        /// </returns>
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return (IHttpHandler)Activator.CreateInstance(this.HandlerType);
        }

        #endregion
    }
}
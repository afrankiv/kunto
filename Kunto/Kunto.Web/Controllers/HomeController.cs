using System.Web.Mvc;

namespace Kunto.Web.Controllers
{
    /// <summary>
    /// </summary>
    public class HomeController : Controller
    {
        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public ActionResult Index()
        {
            return this.View();
        }

        #endregion
    }
}
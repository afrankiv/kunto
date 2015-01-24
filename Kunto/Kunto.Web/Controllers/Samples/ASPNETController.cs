using System.Web.Mvc;

namespace Kunto.Web.Controllers.Samples
{
    /// <summary>
    /// </summary>
    public class ASPNETController : Controller
    {
        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public ActionResult Events()
        {
            return View(HttpContext.Application["events"]);
        }
        
        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public ActionResult Samples()
        {
            return View();
        }

        #endregion
    }
}
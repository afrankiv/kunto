using System;
using System.Linq;
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

        public ActionResult Modules()
        {
            var modules = HttpContext.ApplicationInstance.Modules;

            Tuple<string, string>[] data =
                modules.AllKeys
                    .Select(x => new Tuple<string, string>(
                        x.StartsWith("__Dynamic") ? x.Split('_', ',')[3] : x,
                        modules[x].GetType().Name))
                    .OrderBy(x => x.Item1)
                    .ToArray();

            return View(data);
        }

        #endregion
    }
}
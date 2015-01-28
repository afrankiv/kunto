using System;
using System.Web;

namespace Kunto.Web.Infrustructure.Samples.Modules
{
    /// <summary>
    /// </summary>
    public class DayModule : IHttpModule
    {
        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        public void Dispose()
        {
            // nothing to do
        }

        /// <summary>
        /// </summary>
        /// <param name="app">
        /// </param>
        public void Init(HttpApplication app)
        {
            app.BeginRequest += delegate
            {
                app.Context.Items["DayModule_Time"] = DateTime.Now;
            };
        }

        #endregion
    }
}
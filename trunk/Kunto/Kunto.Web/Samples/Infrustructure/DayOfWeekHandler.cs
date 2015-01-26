using System;
using System.Web;

namespace Kunto.Web.Samples.Infrustructure
{
    /// <summary>
    /// </summary>
    public class DayOfWeekHandler : IHttpHandler
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        /// <param name="context">
        /// </param>
        public void ProcessRequest(HttpContext context)
        {
            string day = DateTime.Now.DayOfWeek.ToString();

            if (context.Request.CurrentExecutionFilePathExtension == ".json"){
                context.Response.ContentType = "application/json";
                context.Response.Write(string.Format("{{\"day\": \"{0}\"}}", day));
            }
            else{
                context.Response.ContentType = "text/html";
                context.Response.Write(string.Format("<span>It is: {0}</span>", day));
            }
        }

        #endregion
    }
}
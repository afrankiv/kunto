using System;
using System.Web;

namespace Kunto.Web.Infrustructure.Samples
{
    /// <summary>
    /// </summary>
    public enum SessionStateKeys
    {
        /// <summary>
        /// </summary>
        NAME
    }

    /// <summary>
    /// </summary>
    public static class SessionStateHelper
    {
        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        /// <param name="key">
        /// </param>
        /// <returns>
        /// </returns>
        public static object Get(SessionStateKeys key)
        {
            string keyString = Enum.GetName(typeof(SessionStateKeys), key);
            return HttpContext.Current.Session[keyString];
        }

        /// <summary>
        /// </summary>
        /// <param name="key">
        /// </param>
        /// <param name="value">
        /// </param>
        /// <returns>
        /// </returns>
        public static object Set(SessionStateKeys key, object value)
        {
            string keyString = Enum.GetName(typeof(SessionStateKeys), key);
            return HttpContext.Current.Session[keyString] = value;
        }

        #endregion
    }
}
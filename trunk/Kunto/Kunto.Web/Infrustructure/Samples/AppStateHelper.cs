using System;
using System.Collections.Generic;
using System.Web;

namespace Kunto.Web.Infrustructure.Samples
{
    /// <summary>
    /// </summary>
    public enum AppStateKeys
    {
        /// <summary>
        /// </summary>
        COUNTER, 

        /// <summary>
        /// </summary>
        LAST_REQUEST_TIME, 

        /// <summary>
        /// </summary>
        LAST_REQUEST_URL, 

        /// <summary>
        /// </summary>
        INDEX_COUNTER
    };

    /// <summary>
    /// </summary>
    public static class AppStateHelper
    {
        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        /// <param name="key">
        /// </param>
        /// <param name="defaultValue">
        /// </param>
        /// <returns>
        /// </returns>
        public static object Get(AppStateKeys key, object defaultValue = null)
        {
            string keyString = Enum.GetName(typeof(AppStateKeys), key);

            if (HttpContext.Current.Application[keyString] == null
                && defaultValue != null){
                HttpContext.Current.Application[keyString] = defaultValue;
            }

            return HttpContext.Current.Application[keyString];
        }

        /// <summary>
        /// </summary>
        /// <param name="keys">
        /// </param>
        /// <returns>
        /// </returns>
        public static IDictionary<AppStateKeys, object> GetMultiple(params AppStateKeys[] keys)
        {
            Dictionary<AppStateKeys, object> results = new Dictionary<AppStateKeys, object>();
            HttpApplicationState appState = HttpContext.Current.Application;
            appState.Lock();
            foreach (AppStateKeys key in keys){
                string keyString = Enum.GetName(typeof(AppStateKeys), key);
                results.Add(key, appState[keyString]);
            }

            appState.UnLock();
            return results;
        }

        /// <summary>
        /// </summary>
        /// <param name="key">
        /// </param>
        /// <returns>
        /// </returns>
        public static int IncrementAndGet(AppStateKeys key)
        {
            string keyString = Enum.GetName(typeof(AppStateKeys), key);
            HttpApplicationState state = HttpContext.Current.Application;
            return (int)(state[keyString] = (int)(state[keyString] ?? 0) + 1);
        }

        /// <summary>
        /// </summary>
        /// <param name="key">
        /// </param>
        /// <param name="value">
        /// </param>
        /// <returns>
        /// </returns>
        public static object Set(AppStateKeys key, object value)
        {
            return HttpContext.Current.Application[Enum.GetName(typeof(AppStateKeys), key)] = value;
        }

        /// <summary>
        /// </summary>
        /// <param name="data">
        /// </param>
        public static void SetMultiple(IDictionary<AppStateKeys, object> data)
        {
            HttpApplicationState appState = HttpContext.Current.Application;
            appState.Lock();
            foreach (AppStateKeys key in data.Keys){
                string keyString = Enum.GetName(typeof(AppStateKeys), key);
                appState[keyString] = data[key];
            }

            appState.UnLock();
        }

        #endregion
    }
}
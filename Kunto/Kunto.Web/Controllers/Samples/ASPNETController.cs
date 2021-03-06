﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;

using Kunto.Web.Infrustructure.Samples;

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
        public ActionResult CacheData()
        {
            return this.View((long?)this.HttpContext.Cache["pageLength"]);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        [OutputCache(Duration = 30, Location = OutputCacheLocation.Server)]
        public ActionResult CachingContent()
        {
            Thread.Sleep(1000);

            int counterValue = AppStateHelper.IncrementAndGet(AppStateKeys.INDEX_COUNTER);

            Debug.WriteLine(string.Format("INDEX_COUNTER: {0}", counterValue));

            return View(counterValue);
        }

        /// <summary>
        /// </summary>
        /// <param name="country">
        /// </param>
        /// <returns>
        /// </returns>
        [HttpPost]
        public ActionResult CompleteForm(string country)
        {
            System.Diagnostics.Debug.WriteLine("Country: {0}", (object)country);

            // in a real application, this is where the call to create the
            // new user account would be
            this.ViewBag.Name = SessionStateHelper.Get(SessionStateKeys.NAME);
            this.ViewBag.Country = country;
            return this.View();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public ActionResult Events()
        {
            return this.View(this.HttpContext.Application["events"]);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public ActionResult Increment()
        {
            int currentValue = (int)AppStateHelper.Get(AppStateKeys.COUNTER, 0);
            AppStateHelper.Set(AppStateKeys.COUNTER, currentValue + 1);
            AppStateHelper.SetMultiple(new Dictionary<AppStateKeys, object>
                                           {
                                               {
                                                   AppStateKeys
                                                   .LAST_REQUEST_TIME, 
                                                   this.HttpContext
                                                       .Timestamp
                                               }, 
                                               {
                                                   AppStateKeys
                                                   .LAST_REQUEST_URL, 
                                                   this.Request
                                                       .RawUrl
                                               }
                                           });
            return this.RedirectToAction("StateData");
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public ActionResult Modules()
        {
            var modules = this.HttpContext.ApplicationInstance.Modules;

            Tuple<string, string>[] data =
                modules.AllKeys.Select(
                    x =>
                    new Tuple<string, string>(x.StartsWith("__Dynamic") ? x.Split('_', ',')[3] : x, 
                        modules[x].GetType().Name)).OrderBy(x => x.Item1).ToArray();

            return View(data);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public async Task<ActionResult> PopulateCache()
        {
            HttpResponseMessage result = await new HttpClient().GetAsync("http://apress.com");
            this.HttpContext.Cache["pageLength"] = result.Content.Headers.ContentLength;
            return this.RedirectToAction("CacheData");
        }

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <returns>
        /// </returns>
        [HttpPost]
        public ActionResult ProcessFirstForm(string name)
        {
            System.Diagnostics.Debug.WriteLine("Name: {0}", (object)name);
            SessionStateHelper.Set(SessionStateKeys.NAME, name);
            return this.View("SecondForm");
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public ActionResult Registration()
        {
            return this.View();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public ActionResult Samples()
        {
            return this.View();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public ActionResult StateData()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();

            data.Add("Counter", AppStateHelper.Get(AppStateKeys.COUNTER, 0));
            IDictionary<AppStateKeys, object> stateData =
                AppStateHelper.GetMultiple(AppStateKeys.LAST_REQUEST_TIME, 
                    AppStateKeys.LAST_REQUEST_URL);

            foreach (AppStateKeys key in stateData.Keys){
                data.Add(Enum.GetName(typeof(AppStateKeys), key), stateData[key]);
            }

            return View(data);
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Kunto.Web
{
    /// <summary>
    /// </summary>
    public class KuntoMvcApplication : HttpApplication
    {
        #region Constructors and Destructors

        /// <summary>
        /// </summary>
        public KuntoMvcApplication()
        {
            this.setupEvents();
        }

        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        private void recordEvent(string name)
        {
            var eventList = this.Application["events"] as List<string>;
            if (eventList == null){
                this.Application["events"] = eventList = new List<string>();
            }

            eventList.Add(name);
        }

        /// <summary>
        /// </summary>
        /// <param name="src">
        /// </param>
        /// <param name="args">
        /// </param>
        private void onAcquireRequestState(object src, EventArgs args)
        {
            this.recordEvent("AcquireRequestState");
        }

        /// <summary>
        /// </summary>
        /// <param name="src">
        /// </param>
        /// <param name="args">
        /// </param>
        private void onAuthenticateRequest(object src, EventArgs args)
        {
            this.recordEvent("AuthentucateRequest");
        }

        /// <summary>
        /// </summary>
        /// <param name="src">
        /// </param>
        /// <param name="args">
        /// </param>
        private void onAuthorizeRequest(object src, EventArgs args)
        {
            this.recordEvent("AuthorizeRequest");
        }

        /// <summary>
        /// </summary>
        /// <param name="src">
        /// </param>
        /// <param name="args">
        /// </param>
        private void onBeginRequest(object src, EventArgs args)
        {
            this.recordEvent("BeginRequest");
        }

        /// <summary>
        /// </summary>
        /// <param name="src">
        /// </param>
        /// <param name="args">
        /// </param>
        private void onEndRequest(object src, EventArgs args)
        {
            this.recordEvent("EndRequest");
        }

        /// <summary>
        /// </summary>
        /// <param name="src">
        /// </param>
        /// <param name="args">
        /// </param>
        private void onError(object src, EventArgs args)
        {
            this.recordEvent("Error");
        }

        /// <summary>
        /// </summary>
        /// <param name="src">
        /// </param>
        /// <param name="args">
        /// </param>
        private void onLogRequest(object src, EventArgs args)
        {
            this.recordEvent("LogRequest");
        }

        /// <summary>
        /// </summary>
        /// <param name="src">
        /// </param>
        /// <param name="args">
        /// </param>
        private void onMapRequestHandler(object src, EventArgs args)
        {
            this.recordEvent("MapRequestHandler");
        }

        /// <summary>
        /// </summary>
        /// <param name="src">
        /// </param>
        /// <param name="args">
        /// </param>
        private void onPostAcquireRequestState(object src, EventArgs args)
        {
            this.recordEvent("PostAcquireRequestState");
        }

        /// <summary>
        /// </summary>
        /// <param name="src">
        /// </param>
        /// <param name="args">
        /// </param>
        private void onPostAuthenticateRequest(object src, EventArgs args)
        {
            this.recordEvent("PostAuthenticateRequest");
        }

        /// <summary>
        /// </summary>
        /// <param name="src">
        /// </param>
        /// <param name="args">
        /// </param>
        private void onPostAuthorizeRequest(object src, EventArgs args)
        {
            this.recordEvent("PostAuthorizeRequest");
        }

        /// <summary>
        /// </summary>
        /// <param name="src">
        /// </param>
        /// <param name="args">
        /// </param>
        private void onPostLogRequest(object src, EventArgs args)
        {
            this.recordEvent("PostLogRequest");
        }

        /// <summary>
        /// </summary>
        /// <param name="src">
        /// </param>
        /// <param name="args">
        /// </param>
        private void onPostMapRequestHandler(object src, EventArgs args)
        {
            this.recordEvent("PostMapRequestHandler");
        }

        /// <summary>
        /// </summary>
        /// <param name="src">
        /// </param>
        /// <param name="args">
        /// </param>
        private void onPostReleaseRequestState(object src, EventArgs args)
        {
            this.recordEvent("PostReleaseRequestState");
        }

        /// <summary>
        /// </summary>
        /// <param name="src">
        /// </param>
        /// <param name="args">
        /// </param>
        private void onPostRequestHandlerExecute(object src, EventArgs args)
        {
            this.recordEvent("PostRequestHandlerExecute");
        }

        /// <summary>
        /// </summary>
        /// <param name="src">
        /// </param>
        /// <param name="args">
        /// </param>
        private void onPostResolveRequestCache(object src, EventArgs args)
        {
            this.recordEvent("PostResolveRequestCache");
        }

        /// <summary>
        /// </summary>
        /// <param name="src">
        /// </param>
        /// <param name="args">
        /// </param>
        private void onPreRequestHandlerExecute(object src, EventArgs args)
        {
            this.recordEvent("PreRequestHandlerExecute");
        }

        /// <summary>
        /// </summary>
        /// <param name="src">
        /// </param>
        /// <param name="args">
        /// </param>
        private void onPreSendRequestContent(object src, EventArgs args)
        {
            this.recordEvent("PreSendRequestContent");
        }

        /// <summary>
        /// </summary>
        /// <param name="src">
        /// </param>
        /// <param name="args">
        /// </param>
        private void onPreSendRequestHeaders(object src, EventArgs args)
        {
            this.recordEvent("PreSendRequestHeaders");
        }

        /// <summary>
        /// </summary>
        /// <param name="src">
        /// </param>
        /// <param name="args">
        /// </param>
        private void onReleaseRequestState(object src, EventArgs args)
        {
            this.recordEvent("ReleaseRequestState");
        }

        /// <summary>
        /// </summary>
        /// <param name="src">
        /// </param>
        /// <param name="args">
        /// </param>
        private void onResolveRequestCache(object src, EventArgs args)
        {
            this.recordEvent("ResolveRequestCache");
        }

        /// <summary>
        /// </summary>
        /// <param name="src">
        /// </param>
        /// <param name="args">
        /// </param>
        private void onUpdateRequestCache(object src, EventArgs args)
        {
            this.recordEvent("UpdateRequestCache");
        }

        /// <summary>
        /// </summary>
        private void setupEvents()
        {
            this.BeginRequest += this.onBeginRequest;
            this.AuthenticateRequest += this.onAuthenticateRequest;
            this.PostAuthenticateRequest += this.onPostAuthenticateRequest;
            this.AuthorizeRequest += this.onAuthorizeRequest;
            this.PostAuthorizeRequest += this.onPostAuthorizeRequest;
            this.ResolveRequestCache += this.onResolveRequestCache;
            this.PostResolveRequestCache += this.onPostResolveRequestCache;
            this.MapRequestHandler += this.onMapRequestHandler;
            this.PostMapRequestHandler += this.onPostMapRequestHandler;
            this.AcquireRequestState += this.onAcquireRequestState;
            this.PostAcquireRequestState += this.onPostAcquireRequestState;
            this.PreRequestHandlerExecute += this.onPreRequestHandlerExecute;
            this.PostRequestHandlerExecute += this.onPostRequestHandlerExecute;
            this.ReleaseRequestState += this.onReleaseRequestState;
            this.PostReleaseRequestState += this.onPostReleaseRequestState;
            this.UpdateRequestCache += this.onUpdateRequestCache;
            this.LogRequest += this.onLogRequest;
            this.PostLogRequest += this.onPostLogRequest;
            this.EndRequest += this.onEndRequest;
            this.PreSendRequestHeaders += this.onPreSendRequestHeaders;
            this.PreSendRequestContent += this.onPreSendRequestContent;
            this.Error += this.onError;
        }

        #endregion
    }
}
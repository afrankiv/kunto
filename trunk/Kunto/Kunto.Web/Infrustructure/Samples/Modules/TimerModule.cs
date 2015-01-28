using System;
using System.Diagnostics;
using System.Web;

namespace Kunto.Web.Infrustructure.Samples.Modules
{
    /// <summary>
    /// </summary>
    public class RequestTimerEventArgs : EventArgs
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public float Duration { get; set; }

        #endregion
    }

    /// <summary>
    /// </summary>
    public class TimerModule : IHttpModule
    {
        #region Fields

        /// <summary>
        /// </summary>
        private Stopwatch timer;

        #endregion

        #region Public Events

        /// <summary>
        /// </summary>
        public event EventHandler<RequestTimerEventArgs> RequestTimed;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        public void Dispose()
        {
            // do nothing - no resources to release
        }

        /// <summary>
        /// </summary>
        /// <param name="app">
        /// </param>
        public void Init(HttpApplication app)
        {
            app.BeginRequest += this.HandleEvent;
            app.EndRequest += this.HandleEvent;
        }

        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="src">
        /// </param>
        /// <param name="args">
        /// </param>
        private void HandleEvent(object src, EventArgs args)
        {
            HttpContext ctx = HttpContext.Current;
            if (ctx.CurrentNotification == RequestNotification.BeginRequest){
                this.timer = Stopwatch.StartNew();
            }
            else{
                float duration = ((float)this.timer.ElapsedTicks) / Stopwatch.Frequency;
                ctx.Response.Write(
                    string.Format("<div class='alert alert-success'>Elapsed: {0:F5} seconds</div>", 
                        duration));
                if (this.RequestTimed != null){
                    this.RequestTimed(this, new RequestTimerEventArgs { Duration = duration });
                }
            }
        }

        #endregion
    }
}
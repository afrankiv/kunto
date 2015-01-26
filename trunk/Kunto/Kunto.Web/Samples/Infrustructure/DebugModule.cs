﻿using System.Collections.Generic;
using System.Web;

namespace Kunto.Web.Samples.Infrustructure
{
    public class DebugModule : IHttpModule
    {
        private static List<string> requestUrls = new List<string>();
        private static object lockObject = new object();

        public void Init(HttpApplication app)
        {
            app.BeginRequest += (src, args) =>
            {
                lock (lockObject)
                {
                    if (app.Request.RawUrl == "/Kunto.Web/Stats")
                    {
                        app.Response.Write(
                            string.Format("<div>There have been {0} requests</div>",
                                requestUrls.Count));
                        app.Response.Write("<table><tr><th>ID</th><th>URL</th></tr>");
                        for (int i = 0; i < requestUrls.Count; i++)
                        {
                            app.Response.Write(
                                string.Format("<tr><td>{0}</td><td>{1}</td></tr>",
                                    i, requestUrls[i]));
                        }
                        app.CompleteRequest();
                    }
                    else
                    {
                        requestUrls.Add(app.Request.RawUrl);
                    }
                }
            };
        }

        public void Dispose()
        {
            // do nothing
        }
    }
}
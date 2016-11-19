using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace MyLabService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AppDomain.CurrentDomain.SetData("DataDirectory", @"C:\Users\Max\Documents\CST 356\Lab7\Lab 2\App_Data");
        }
    }
}

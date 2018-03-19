using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Southernfund.UpdateSystem.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.TypeNameHandling = TypeNameHandling.All;


            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{pcode}/{ctype}",
                defaults: new { pcode = RouteParameter.Optional, ctype = RouteParameter.Optional }
            );

            GlobalConfiguration.Configuration.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}

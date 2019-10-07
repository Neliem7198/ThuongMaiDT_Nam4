using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DA_BookStore
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //convert xml to json
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(new System.Net.Http.Formatting.RequestHeaderMapping("Accept",
                              "text/html",
                              StringComparison.InvariantCultureIgnoreCase,
                              true,
                              "application/json")); ;

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

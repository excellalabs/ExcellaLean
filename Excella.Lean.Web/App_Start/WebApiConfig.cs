namespace Excella.Lean.Web
{
    using System.Net.Http.Formatting;
    using System.Web.Http;

    using Breeze.WebApi;

    using Excella.Lean.Web.Core;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
        }

////        public static void Register(HttpConfiguration config)
////        {
////#if AAT
////            config.Routes.MapHttpRoute(
////                name: "AatApi",
////                routeTemplate: "api/{controller}/{id}",
////                defaults: new { id = RouteParameter.Optional }
////            );
////#else
////            config.Routes.MapHttpRoute(
////                name: "DefaultApi",
////                routeTemplate: "api/{controller}/{id}",
////                defaults: new { id = RouteParameter.Optional }
////            );
////#endif

////            config.EnableQuerySupport();

////#if (DEBUG || AAT)
////            // To disable tracing in your application, please comment out or remove the following line of code
////            // For more information, refer to: http://www.asp.net/web-api
////            config.EnableSystemDiagnosticsTracing();
////#endif
////        }
    }
}

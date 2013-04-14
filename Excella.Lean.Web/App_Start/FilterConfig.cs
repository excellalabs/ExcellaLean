namespace Excella.Lean.Web
{
    using System.Web.Http.Filters;
    using System.Web.Mvc;

    using Excella.Lean.Web.Filters;

    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterHttpFilters(HttpFilterCollection filters)
        {
            filters.Add(new ElmahHandledErrorLoggerFilter());
        }
    }
}
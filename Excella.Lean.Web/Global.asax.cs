namespace Excella.Lean.Web
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Autofac;
    using Autofac.Integration.WebApi;

    using Excella.Lean.Core.Composition;
    using Excella.Lean.Core.Composition.Modules;
    using Excella.Lean.Web.Composition;

    public class MvcApplication : System.Web.HttpApplication
    {
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Functions provided by the framework should not be altered")]
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterDependencyResolver();
            RegisterWebApiDependencyResolver();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            FilterConfig.RegisterHttpFilters(GlobalConfiguration.Configuration.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static void RegisterDependencyResolver()
        {
            var compositionRoot = new CompositionRoot(Assembly.GetExecutingAssembly(), false);

            var resolver = compositionRoot.BuildDependencyResolver(GetWebModuleContainer);

            DependencyResolver.SetResolver(resolver);
        }

        private static void GetWebModuleContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new WebModule(Assembly.GetExecutingAssembly()));
        }

        private static void RegisterWebApiDependencyResolver()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterModule(new WebModule(Assembly.GetExecutingAssembly()));
            builder.RegisterModule(new MvcModule(Assembly.GetExecutingAssembly()));

            var container = builder.Build();

            var resolver = new AutofacWebApiDependencyResolver(container);

            // Configure Web API with the dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}
namespace Excella.Lean.Api
{
    using System;
    using System.Web;

    using Autofac;
    using Autofac.Integration.Wcf;

    using Excella.Lean.Api.Mapping;
    using Excella.Lean.Api.ServiceContracts;
    using Excella.Lean.Api.ServiceContracts.Impl;
    using Excella.Lean.Core.Composition.Modules;
    using Excella.Lean.Domain.Mapping;

    public class Global : HttpApplication
    {
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            // register dependencies
            var builder = new ContainerBuilder();
            builder.RegisterType<>().As<>();
          
            builder.RegisterModule<ServicesModule>();
            AutofacHostFactory.Container = builder.Build();

            // configure maps
            RegisterAutomapper();
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        private static void RegisterAutomapper()
        {
            ApiMappingFactory.InitializeMappers();
        }
    }
}

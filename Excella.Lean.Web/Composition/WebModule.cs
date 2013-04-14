namespace Excella.Lean.Web.Composition
{
    using System.Reflection;

    using Autofac;
    using Autofac.Integration.Mvc;

    public class WebModule : Autofac.Module
    {
        private readonly Assembly assembly;

        public WebModule(Assembly assembly)
        {
            this.assembly = assembly;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Models.Repositories.>()
                .As<Models.Repositories.>();


            if (this.assembly != null)
            {
                builder.RegisterControllers(this.assembly);
            }
        }
    }
}
namespace Excella.Lean.Core.Composition
{
    using System;
    using System.Reflection;
    using System.Web.Mvc;
    using Autofac;
    using Autofac.Integration.Mvc;
    using Excella.Lean.Core.Composition.Modules;

    public class CompositionRoot
    {
        private readonly Assembly assembly;
        private readonly bool useFakeServicesModule;

        public CompositionRoot()
        {
        }

        public CompositionRoot(Assembly assembly, bool useFakeServicesModule)
        {
            this.assembly = assembly;
            this.useFakeServicesModule = useFakeServicesModule;
        }

        public IDependencyResolver BuildDependencyResolver()
        {
            return this.BuildDependencyResolver(a => { });
        }

        public IDependencyResolver BuildDependencyResolver(Action<ContainerBuilder> builderCustomizations)
        {
            return new AutofacDependencyResolver(this.BuildContainer(builderCustomizations));
        }

        private IContainer BuildContainer(Action<ContainerBuilder> builderCustomizations)
        {
            var builder = new ContainerBuilder();

            if (this.useFakeServicesModule)
            {
                ////builder.RegisterModule<FakeServicesModule>();
                ////builder.RegisterModule(new FakeUiModule(this.assembly));
            }
            else
            {
                builder.RegisterModule(new MvcModule(this.assembly));
                builder.RegisterModule<ServicesModule>();
            }

            builderCustomizations(builder);
            return builder.Build();
        }
    }
}

namespace Excella.Lean.Core.Composition.Modules
{
    using System.Reflection;

    using Autofac;
    using Autofac.Integration.Mvc;

    using Excella.Lean.Dal;
    using Excella.Lean.Dal.EntityFramework.Contexts;
    using Excella.Lean.Domain.Events;
    using Excella.Lean.Domain.Events.Impl;
    using Excella.Lean.Domain.Shared;
    using Excella.Lean.Domain.Shared.Impl;

    public class MvcModule : Autofac.Module
    {
        private readonly Assembly assembly;

        public MvcModule(Assembly assembly)
        {
            this.assembly = assembly;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EventService>().As<IEventService>();

            builder.RegisterType<PersonService>().As<IPersonService>();

            builder.RegisterType<LeanDatabase>().As<ILeanDatabase>().InstancePerDependency();

            if (this.assembly != null)
            {
                builder.RegisterControllers(this.assembly);
            }
        }
    }
}

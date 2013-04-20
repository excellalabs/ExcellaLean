namespace Excella.Lean.Core.Composition.Modules
{
    using Autofac;

    using Excella.Lean.Dal;
    using Excella.Lean.Dal.EntityFramework.Contexts;
    using Excella.Lean.Domain.Events;
    using Excella.Lean.Domain.Events.Impl;
    using Excella.Lean.Domain.Shared;
    using Excella.Lean.Domain.Shared.Impl;

    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EventService>().As<IEventService>();

            builder.RegisterType<PersonService>().As<IPersonService>();

            builder.RegisterType<LeanDatabase>().As<ILeanDatabase>().InstancePerDependency();
        }
    }
}

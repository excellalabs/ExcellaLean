namespace Excella.Lean.Core.Composition.Modules
{
    using Autofac;

    using Excella.Lean.Dal;
    using Excella.Lean.Dal.EntityFramework.Contexts;

    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LeanDatabase>().As<ILeanDatabase>().InstancePerLifetimeScope();
        }
    }
}

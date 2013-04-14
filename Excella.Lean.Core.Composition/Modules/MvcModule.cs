﻿namespace Excella.Lean.Core.Composition.Modules
{
    using System.Reflection;

    using Autofac;
    using Autofac.Integration.Mvc;

    using Excella.Lean.Dal;
    using Excella.Lean.Dal.EntityFramework.Contexts;

    public class MvcModule : Autofac.Module
    {
        private readonly Assembly assembly;

        public MvcModule(Assembly assembly)
        {
            this.assembly = assembly;
        }

        protected override void Load(ContainerBuilder builder)
        {
            // Core
            builder.RegisterType<>().As<>();
           
            if (this.assembly != null)
            {
                builder.RegisterControllers(this.assembly);
            }
        }
    }
}

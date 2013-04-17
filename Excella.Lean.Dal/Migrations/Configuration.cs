namespace Excella.Lean.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    using Excella.Lean.Core.Models.Shared;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityFramework.Contexts.LeanDatabase>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EntityFramework.Contexts.LeanDatabase context)
        {
            // This method will be called after migrating to the latest version.
            context.Persons.AddOrUpdate(
                p => p.Ssn,
                new Person
                    {
                        Ssn = "123456001",
                        FirstName = "John",
                        LastName = "Doe",
                        LastUpdateBy = "SYSTEM",
                        LastUpdateDate = DateTime.Now,
                    },
                new Person
                {
                        Ssn = "123456002",
                        FirstName = "Jane",
                        LastName = "Smith",
                        LastUpdateBy = "SYSTEM",
                        LastUpdateDate = DateTime.Now,
                    });
        }
    }
}

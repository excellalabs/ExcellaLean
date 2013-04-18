namespace Excella.Lean.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    using Excella.Lean.Core.Models.Shared;
    using Excella.Lean.Dal.EntityFramework.Contexts;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityFramework.Contexts.LeanDatabase>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LeanDatabase context)
        {
            SeedPersons(context);
        }

        private static void SeedPersons(LeanDatabase context)
        {
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

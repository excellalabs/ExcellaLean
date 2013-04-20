namespace Excella.Lean.Dal.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity.Migrations;

    using Excella.Lean.Core.Models.Events;
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
            SeedEvents(context);
        }

        private void SeedEvents(LeanDatabase context)
        {
            var events = new List<Event>
                             {
                                 new Event
                                     {
                                         Title = "My Event",
                                         Description = "My Event",
                                         ReservationRequests = new Collection<ReservationRequest>(),
                                         ScheduledDate = DateTime.Now,
                                         LastUpdateBy = "SYSTEM",
                                         LastUpdateDate = DateTime.Now,
                                     }
                             };

            foreach (var evt in events)
            {
                context.AddUpdate(evt);
            }

            context.SaveAllChanges();
        }

        private static void SeedPersons(LeanDatabase context)
        {
            var people = new List<Person>
                             {
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
                                     }
                             };

            foreach (var person in people)
            {
                context.AddUpdate(person);
            }

            context.SaveAllChanges();
        }
    }
}

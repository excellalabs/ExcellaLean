namespace Excella.Lean.Web.Models.Contexts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Excella.Lean.Core.Models.Events;
    using Excella.Lean.Core.Models.Shared;
    using Excella.Lean.Domain.Events;
    using Excella.Lean.Domain.Shared;

    public class EventWebContext : WebContext
    {
        private readonly IPersonService personService;

        private readonly IEventService eventService;

        protected EventWebContext(IPersonService personService, IEventService eventService)
        {
            this.personService = personService;
            this.eventService = eventService;
        }

        // TODO: Fix bad grammar
        protected IQueryable<Person> Persons
        {
            get
            {
                return this.personService.Persons;
            }
        }

        protected IQueryable<Event> Events
        {
            get
            {
                return this.eventService.Events;
            }
        }

        protected IQueryable<ReservationResult> ReservationResults
        {
            get
            {
                return this.eventService.ReservationResults;
            }
        }

        protected override Dictionary<System.Type, EntityMetadata> DomainServiceMapping
        {
            get
            {
                return new Dictionary<Type, EntityMetadata>
                    {
                        {
                            typeof(Event), 
                            new EntityMetadata { DomainService = this.eventService, Key = typeof(int) }
                        }, 
                        {
                            typeof(Person), 
                            new EntityMetadata { DomainService = this.personService, Key = typeof(int) }
                        }, 
                        {
                            typeof(ReservationResult), 
                            new EntityMetadata { DomainService = this.eventService, Key = typeof(int) }
                        }
                    };
            }
        }
    }
}
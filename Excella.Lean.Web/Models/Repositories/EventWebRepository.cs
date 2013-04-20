namespace Excella.Lean.Web.Models.Repositories
{
    using System.Linq;

    using Excella.Lean.Web.Models.Contexts;

    public class EventWebRepository : MetadataWebRepository, IEventWebRepository
    {
        private readonly IEventWebContext eventWebContext;

        public EventWebRepository(IEventWebContext eventWebContext)
            : base("WebMetadata", eventWebContext)
        {
            this.eventWebContext = eventWebContext;
        }


        public IQueryable<Lean.Core.Models.Shared.Person> Persons
        {
            get
            {
                return this.eventWebContext.Persons;
            }
        }

        public IQueryable<Lean.Core.Models.Events.Event> Events
        {
            get
            {
                return this.eventWebContext.Events;
            }
        }

        public IQueryable<Lean.Core.Models.Events.ReservationResult> ReservationResults
        {
            get
            {
                return this.eventWebContext.ReservationResults;
            }
        }
    }
}
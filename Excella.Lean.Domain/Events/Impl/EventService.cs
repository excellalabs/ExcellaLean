namespace Excella.Lean.Domain.Events.Impl
{
    using System.Linq;

    using Excella.Lean.Core.Models.Events;
    using Excella.Lean.Dal;
    using Excella.Lean.Domain.Shared.Impl;

    public class EventService : ServiceBase, IEventService
    {
        public EventService(ILeanDatabase database)
            : base(database)
        {
        }

        public IQueryable<Event> Events
        {
            get
            {
                return this.Database.GetAll<Event>();
            }
        }

        public IQueryable<ReservationRequest> ReservationRequests
        {
            get
            {
                return this.Database.GetAll<ReservationRequest>();
            }
        }

        public IQueryable<ReservationResult> ReservationResults
        {
            get
            {
                return this.Database.GetAll<ReservationResult>();
            }
        }
    }
}

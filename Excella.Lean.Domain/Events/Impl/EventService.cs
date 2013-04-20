namespace Excella.Lean.Domain.Events.Impl
{
    using System.Linq;

    using Excella.Lean.Core.Models.Events;
    using Excella.Lean.Dal;

    public class EventService
    {
        private readonly ILeanDatabase database;

        public EventService(ILeanDatabase database)
        {
            this.database = database;
        }

        public IQueryable<Event> Events
        {
            get
            {
                return this.database.Events;
            }
        }

        public IQueryable<ReservationRequest> ReservationRequests
        {
            get
            {
                return this.database.ReservationRequests;
            }
        }

        public IQueryable<ReservationResult> ReservationResults
        {
            get
            {
                return this.database.ReservationResults;
            }
        }

        public void SaveAllChanges()
        {
            this.database.SaveAllChanges();
        }
    }
}

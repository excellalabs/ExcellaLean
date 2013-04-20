namespace Excella.Lean.Domain.Events
{
    using System.Linq;
    using Excella.Lean.Core.Models.Events;
    
    public interface IEventService
    {
        IQueryable<Event> Events { get; }

        IQueryable<ReservationRequest> ReservationRequests { get; }

        IQueryable<ReservationResult> ReservationResults { get; }

        void SaveAllChanges();
    }
}

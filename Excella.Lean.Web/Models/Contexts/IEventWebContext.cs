namespace Excella.Lean.Web.Models.Contexts
{
    using System.Linq;

    using Excella.Lean.Core.Models.Events;
    using Excella.Lean.Core.Models.Shared;

    public interface IEventWebContext : IWebContext
    {
        IQueryable<Person> Persons { get; }

        IQueryable<Event> Events { get; }

        IQueryable<ReservationResult> ReservationResults { get; }
    }
}
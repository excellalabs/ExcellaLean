namespace Excella.Lean.Web.Models.Repositories
{
    using System.Linq;

    using Excella.Lean.Core.Models.Events;
    using Excella.Lean.Core.Models.Shared;

    public interface IEventWebRepository : IWebRepository
    {
        IQueryable<Person> Persons { get; }

        IQueryable<Event> Events { get; }

        IQueryable<ReservationResult> ReservationResults { get; }
    }
}
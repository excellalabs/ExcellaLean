namespace Excella.Lean.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Breeze.WebApi;

    using Excella.Lean.Core.Models.Events;
    using Excella.Lean.Core.Models.Shared;
    using Excella.Lean.Web.Models.Repositories;

    using Newtonsoft.Json.Linq;

    [BreezeController]
    public class EventsController : ApiController
    {
        private readonly IEventWebRepository eventWebRepository;

        public EventsController(IEventWebRepository eventWebRepository)
        {
            this.eventWebRepository = eventWebRepository;
        }

        // GET ~/api/Events/Events
        [HttpGet]
        public IQueryable<Event> Events()
        {
            return this.eventWebRepository.Events
                .OrderByDescending(t => t.Id);
        }

        // GET ~/api/Events/Persons
        [HttpGet]
        public IQueryable<Person> Persons()
        {
            return this.eventWebRepository.Persons
                .OrderByDescending(t => t.Id);
        }

        // GET ~/api/Events/ReservationResults
        [HttpGet]
        public IQueryable<ReservationResult> ReservationResults()
        {
            return this.eventWebRepository.ReservationResults
                .OrderByDescending(t => t.Id);
        }

        // GET ~/api/Events/Metadata
        [HttpGet]
        public string Metadata()
        {
            return this.eventWebRepository.Metadata();
        }

        // POST ~/api/Events/SaveChanges
        [HttpPost]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return this.eventWebRepository.SaveChanges(saveBundle);
        }
    }
}

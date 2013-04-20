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
    public class EventController : ApiController
    {
        private readonly IEventWebRepository eventWebRepository;

        public EventController(IEventWebRepository eventWebRepository)
        {
            this.eventWebRepository = eventWebRepository;
        }

        // GET ~/api/Event/Events
        [HttpGet]
        public IQueryable<Event> Events()
        {
            return this.eventWebRepository.Events
                .OrderByDescending(t => t.Id);
        }

        // GET ~/api/Event/Persons
        [HttpGet]
        public IQueryable<Person> Persons()
        {
            return this.eventWebRepository.Persons
                .OrderByDescending(t => t.Id);
        }

        // GET ~/api/Event/ReservationResults
        [HttpGet]
        public IQueryable<ReservationResult> ReservationResults()
        {
            return this.eventWebRepository.ReservationResults
                .OrderByDescending(t => t.Id);
        }

        // GET ~/api/Event/Metadata
        [HttpGet]
        public string Metadata()
        {
            return this.eventWebRepository.Metadata();
        }

        // POST ~/api/Event/SaveChanges
        [HttpPost]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return this.eventWebRepository.SaveChanges(saveBundle);
        }
    }
}

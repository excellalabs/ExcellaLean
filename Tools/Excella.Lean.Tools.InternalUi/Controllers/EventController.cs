namespace Excella.Lean.Tools.InternalUi.Controllers
{
    using System.Web.Mvc;

    using Excella.Lean.Core.Models.Events;
    using Excella.Lean.Dal.EntityFramework.Contexts;
    using Excella.Lean.Domain.Shared;

    using Ploeh.AutoFixture;
    using Excella.Lean.Domain.Shared.Impl;

    [Bind(Exclude = "")]
    public class EventController : Controller
    {
        private readonly PersonService personService;

        private readonly Fixture fixture;

        public EventController()
        {
            this.fixture = new Fixture();
            var database = new LeanDatabase();
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Notify(Event myEvent)
        {
            this.ViewBag.Message = "Event Notification Trigger";

            /*var client = new EventNotificationServiceClient();
            var request = new NotifyEventRequest(myEvent);
            client.NotifyEvent(request);

            client.Close();*/

            return this.View();
        }
    }
}

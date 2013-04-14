﻿namespace InternalUi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Excella.Lean.Core.Models.Events;
    using Excella.Lean.Dal.EntityFramework.Contexts;

    using Ploeh.AutoFixture;

    [Bind(Exclude = "")]
    public class EventController : Controller
    {
        private readonly IRepositoryStore repositoryStore;

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

            var client = new EventNotificationServiceClient();
            var request = new NotifyEventRequest(myEvent);
            client.NotifyEvent(request);

            client.Close();

            return this.View();
        }
    }
}

namespace Excella.Lean.Core.Models.Events
{
    using System;
    using System.Collections.Generic;

    public class Event : EntityBase
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime ScheduledDate { get; set; }

        public ICollection<ReservationRequest> ReservationRequests { get; set; }
    }
}

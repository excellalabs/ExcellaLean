namespace Excella.Lean.Core.Models.Events
{
    using System;

    using Excella.Lean.Core.Models.Shared;

    public class ReservationRequest : EntityBase
    {
        public Person Requester { get; set; }

        public DateTime RequestDate { get; set; }
    }
}

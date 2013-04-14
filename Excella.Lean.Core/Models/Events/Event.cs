namespace Excella.Lean.Core.Models.Events
{
    using System;

    public class Event : EntityBase
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime ScheduledDate { get; set; }
    }
}

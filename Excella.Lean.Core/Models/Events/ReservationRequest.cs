namespace Excella.Lean.Core.Models.Events
{
    public class ReservationRequest : EntityBase
    {
        public string RequestedBy { get; set; }

        public string RequestedDate { get; set; }
    }
}

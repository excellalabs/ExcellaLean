namespace Excella.Lean.Dal.EntityFramework.Contexts
{
    using System.Data.Entity;
    using System.Linq;

    using Excella.Lean.Core.Models.Events;

    public partial class LeanDatabase
    {
        public DbSet<ReservationResult> ReservationResults { get; set; }

        public DbSet<ReservationRequest> ReservationRequests { get; set; }

        IQueryable<ReservationResult> ILeanDatabase.ReservationResults
        {
            get { return this.ReservationResults; }
        }

        IQueryable<ReservationRequest> ILeanDatabase.ReservationRequests
        {
            get { return this.ReservationRequests; }
        }
    }
}

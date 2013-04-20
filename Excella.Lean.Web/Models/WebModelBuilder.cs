namespace Excella.Lean.Web.Models
{
    using Excella.Lean.Core.Models.Events;
    using Excella.Lean.Core.Models.Shared;

    public static class MetadataModelBuilder
    {
        public static void BuildWebModel(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            // Note: Only use concrete types.
            modelBuilder.Entity<Event>();
            modelBuilder.Entity<Person>();
            modelBuilder.Entity<ReservationResult>();
        }
    }
}
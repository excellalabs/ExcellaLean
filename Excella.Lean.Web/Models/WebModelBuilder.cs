namespace Excella.Lean.Web.Models
{
    using Excella.Lean.Core.Models.Events;

    public static class MetadataModelBuilder
    {
        public static void BuildWebModel(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            // Note: Only use concrete types.
            modelBuilder.Entity<Event>();
        }
    }
}
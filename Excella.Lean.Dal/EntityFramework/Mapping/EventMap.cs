namespace Excella.Lean.Dal.EntityFramework.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using Excella.Lean.Core.Models.Events;

    public class EventMap : EntityTypeConfiguration<Event>
    {
        public EventMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            this.ToTable("Event");
            this.Property(t => t.Id).HasColumnName("EventId");

            // Relationships
            this.HasMany(t => t.ReservationRequests)
                .WithRequired()
                .Map(d => d.MapKey("EventId"));
        }
    }
}

namespace Excella.Lean.Dal.EntityFramework.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using Excella.Lean.Core.Models.Events;

    public class ReservationRequestMap : EntityTypeConfiguration<ReservationRequest>
    {
        public ReservationRequestMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            this.ToTable("ReservationRequest");
            this.Property(t => t.Id).HasColumnName("ReservationRequestId");

            // Relationships

        }
    }
}

namespace Excella.Lean.Dal.EntityFramework.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using Excella.Lean.Core.Models.Events;

    public class ReservationResultMap : EntityTypeConfiguration<ReservationResult>
    {
        public ReservationResultMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            this.ToTable("ReservationResult");
            this.Property(t => t.Id).HasColumnName("ReservationResultId");

            // Relationships
            this.HasRequired(t => t.ReservationRequest)
                .WithMany()
                .Map(d => d.MapKey("ReservationRequestId"));
        }
    }
}

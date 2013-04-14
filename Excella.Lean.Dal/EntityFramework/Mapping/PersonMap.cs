namespace Excella.Lean.Dal.EntityFramework.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using Excella.Lean.Core.Models.Shared;

    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            this.ToTable("Person");
            this.Property(t => t.Id).HasColumnName("PersonId");

            // Relationships

        }
    }
}

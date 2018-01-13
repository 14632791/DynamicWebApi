using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class dtpropertyMap : EntityTypeConfiguration<dtproperty>
    {
        public dtpropertyMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.property });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.property)
                .IsRequired()
                .HasMaxLength(64);

            this.Property(t => t.value)
                .HasMaxLength(255);

            this.Property(t => t.uvalue)
                .HasMaxLength(255);

        }
    }
}

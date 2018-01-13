using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class vw_INsMap : EntityTypeConfiguration<vw_INs>
    {
        public vw_INsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ISID, t.INNO, t.ProductCode });

            // Properties
            this.Property(t => t.ISID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.INNO)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.ProductCode)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Remark)
                .HasMaxLength(250);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(20);

            this.Property(t => t.LastUpdatedBy)
                .HasMaxLength(20);

            this.Property(t => t.ProductName)
                .HasMaxLength(50);

        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class vw_POsMap : EntityTypeConfiguration<vw_POs>
    {
        public vw_POsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ISID, t.PONO, t.Queue, t.ProductCode });

            // Properties
            this.Property(t => t.ISID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.PONO)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Queue)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ProductCode)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Unit)
                .HasMaxLength(10);

            this.Property(t => t.Remark)
                .HasMaxLength(50);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(50);

            this.Property(t => t.LastUpdatedBy)
                .HasMaxLength(20);

            this.Property(t => t.ProductName)
                .HasMaxLength(50);

        }
    }
}

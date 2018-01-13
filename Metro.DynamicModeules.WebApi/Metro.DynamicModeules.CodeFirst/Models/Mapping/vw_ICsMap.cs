using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class vw_ICsMap : EntityTypeConfiguration<vw_ICs>
    {
        public vw_ICsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ISID, t.ICNO, t.ProductCode });

            // Properties
            this.Property(t => t.ISID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.ICNO)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.ProductCode)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Remark)
                .HasMaxLength(250);

            this.Property(t => t.LocationID)
                .HasMaxLength(20);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(20);

            this.Property(t => t.LastUpdatedBy)
                .HasMaxLength(20);

            this.Property(t => t.StockName)
                .HasMaxLength(50);

        }
    }
}

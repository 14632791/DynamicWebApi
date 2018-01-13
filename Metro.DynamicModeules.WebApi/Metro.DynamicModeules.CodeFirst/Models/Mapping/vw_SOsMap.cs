using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class vw_SOsMap : EntityTypeConfiguration<vw_SOs>
    {
        public vw_SOsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ISID, t.SONO, t.Queue, t.StockCode });

            // Properties
            this.Property(t => t.ISID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.SONO)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Queue)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.StockCode)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.CustomerOrderNo)
                .HasMaxLength(50);

            this.Property(t => t.Unit)
                .HasMaxLength(10);

            this.Property(t => t.Qty)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.Remark)
                .HasMaxLength(50);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(50);

            this.Property(t => t.LastUpdatedBy)
                .HasMaxLength(20);

            this.Property(t => t.StockName)
                .HasMaxLength(50);

        }
    }
}

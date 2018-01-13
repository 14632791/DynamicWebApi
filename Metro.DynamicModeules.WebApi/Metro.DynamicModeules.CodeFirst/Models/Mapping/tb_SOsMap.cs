using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_SOsMap : EntityTypeConfiguration<tb_SOs>
    {
        public tb_SOsMap()
        {
            // Primary Key
            this.HasKey(t => t.ISID);

            // Properties
            this.Property(t => t.SONO)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.StockCode)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.CustomerOrderNo)
                .HasMaxLength(50);

            this.Property(t => t.Unit)
                .HasMaxLength(10);

            this.Property(t => t.Remark)
                .HasMaxLength(50);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(50);

            this.Property(t => t.LastUpdatedBy)
                .HasMaxLength(20);


            // Relationships
            this.HasRequired(t => t.tb_SO)
                .WithMany(t => t.tb_SOs)
                .HasForeignKey(d => d.SONO);

        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class log_SOsMap : EntityTypeConfiguration<log_SOs>
    {
        public log_SOsMap()
        {
            // Primary Key
            this.HasKey(t => t.ISID);

            // Properties
            this.Property(t => t.C_TmpKey)
                .HasMaxLength(32);

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

            // Table & Column Mappings
            this.ToTable("log_SOs");
            this.Property(t => t.C_TmpKey).HasColumnName("_TmpKey");
            this.Property(t => t.ISID).HasColumnName("ISID");
            this.Property(t => t.SONO).HasColumnName("SONO");
            this.Property(t => t.Queue).HasColumnName("Queue");
            this.Property(t => t.StockCode).HasColumnName("StockCode");
            this.Property(t => t.CustomerOrderNo).HasColumnName("CustomerOrderNo");
            this.Property(t => t.ShipDay).HasColumnName("ShipDay");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.Qty).HasColumnName("Qty");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.CreationDate).HasColumnName("CreationDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.LastUpdateDate).HasColumnName("LastUpdateDate");
            this.Property(t => t.LastUpdatedBy).HasColumnName("LastUpdatedBy");
        }
    }
}

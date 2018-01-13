using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_ProductMap : EntityTypeConfiguration<tb_Product>
    {
        public tb_ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductCode);

            // Properties
            this.Property(t => t.isid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.ProductCode)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.ProductName)
                .HasMaxLength(50);

            this.Property(t => t.CategoryId)
                .HasMaxLength(20);

            this.Property(t => t.Supplier)
                .HasMaxLength(50);

            this.Property(t => t.Remark)
                .HasMaxLength(100);

        }
    }
}

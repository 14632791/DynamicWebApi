using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_ProductCategoryMap : EntityTypeConfiguration<tb_ProductCategory>
    {
        public tb_ProductCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.CategoryId);

            // Properties
            this.Property(t => t.isid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.CategoryId)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.ParentId)
                .HasMaxLength(20);

            this.Property(t => t.CategoryName)
                .HasMaxLength(50);

            this.Property(t => t.Column1)
                .HasMaxLength(50);

            this.Property(t => t.Remark)
                .HasMaxLength(250);

        }
    }
}

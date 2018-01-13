using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_INsMap : EntityTypeConfiguration<tb_INs>
    {
        public tb_INsMap()
        {
            // Primary Key
            this.HasKey(t => t.ISID);

            // Properties
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

        }
    }
}

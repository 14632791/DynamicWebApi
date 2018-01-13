using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_IAsMap : EntityTypeConfiguration<tb_IAs>
    {
        public tb_IAsMap()
        {
            // Primary Key
            this.HasKey(t => t.ISID);

            // Properties
            this.Property(t => t.IANO)
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

        }
    }
}

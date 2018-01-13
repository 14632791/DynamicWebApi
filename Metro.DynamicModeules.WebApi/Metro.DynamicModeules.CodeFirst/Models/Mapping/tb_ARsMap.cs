using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_ARsMap : EntityTypeConfiguration<tb_ARs>
    {
        public tb_ARsMap()
        {
            // Primary Key
            this.HasKey(t => t.ISID);

            // Properties
            this.Property(t => t.ARNO)
                .HasMaxLength(20);

            this.Property(t => t.InvoiceNo)
                .HasMaxLength(20);

            this.Property(t => t.SONO)
                .HasMaxLength(20);

            this.Property(t => t.Currency)
                .HasMaxLength(20);

            this.Property(t => t.Remark)
                .HasMaxLength(100);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(20);

            this.Property(t => t.LastUpdatedBy)
                .HasMaxLength(20);

        }
    }
}

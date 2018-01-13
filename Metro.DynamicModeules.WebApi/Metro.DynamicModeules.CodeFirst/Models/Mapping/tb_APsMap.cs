using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_APsMap : EntityTypeConfiguration<tb_APs>
    {
        public tb_APsMap()
        {
            // Primary Key
            this.HasKey(t => t.ISID);

            // Properties
            this.Property(t => t.APNO)
                .HasMaxLength(20);

            this.Property(t => t.InvoiceNo)
                .HasMaxLength(20);

            this.Property(t => t.PONO)
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

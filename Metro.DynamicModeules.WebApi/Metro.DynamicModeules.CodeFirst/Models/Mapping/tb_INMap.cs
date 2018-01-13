using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_INMap : EntityTypeConfiguration<tb_IN>
    {
        public tb_INMap()
        {
            // Primary Key
            this.HasKey(t => t.INNO);

            // Properties
            this.Property(t => t.ISID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.INNO)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.DocUser)
                .HasMaxLength(20);

            this.Property(t => t.RefNo)
                .HasMaxLength(20);

            this.Property(t => t.SupplierCode)
                .HasMaxLength(20);

            this.Property(t => t.Department)
                .HasMaxLength(20);

            this.Property(t => t.Deliver)
                .HasMaxLength(20);

            this.Property(t => t.LocationID)
                .HasMaxLength(20);

            this.Property(t => t.Remark)
                .HasMaxLength(250);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(20);

            this.Property(t => t.FlagApp)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.AppUser)
                .HasMaxLength(20);

            this.Property(t => t.LastUpdatedBy)
                .HasMaxLength(20);

        }
    }
}

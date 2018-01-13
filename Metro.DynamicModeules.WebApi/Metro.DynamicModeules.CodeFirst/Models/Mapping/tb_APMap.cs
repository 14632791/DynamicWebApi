using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_APMap : EntityTypeConfiguration<tb_AP>
    {
        public tb_APMap()
        {
            // Primary Key
            this.HasKey(t => t.APNO);

            // Properties
            this.Property(t => t.ISID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.APNO)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.SupplierCode)
                .HasMaxLength(20);

            this.Property(t => t.ChequeNo)
                .HasMaxLength(20);

            this.Property(t => t.ChequeBank)
                .HasMaxLength(20);

            this.Property(t => t.Currency)
                .HasMaxLength(20);

            this.Property(t => t.Remark)
                .HasMaxLength(100);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(20);

            this.Property(t => t.LastUpdatedBy)
                .HasMaxLength(20);

            this.Property(t => t.FlagApp)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.AppUser)
                .HasMaxLength(20);

        }
    }
}

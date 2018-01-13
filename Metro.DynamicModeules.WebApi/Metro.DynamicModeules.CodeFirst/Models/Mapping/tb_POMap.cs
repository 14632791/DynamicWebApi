using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_POMap : EntityTypeConfiguration<tb_PO>
    {
        public tb_POMap()
        {
            // Primary Key
            this.HasKey(t => t.PONO);

            // Properties
            this.Property(t => t.ISID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.PONO)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.POUser)
                .HasMaxLength(20);

            this.Property(t => t.CustomerCode)
                .HasMaxLength(20);

            this.Property(t => t.CustomerContact)
                .HasMaxLength(20);

            this.Property(t => t.CustomerTel)
                .HasMaxLength(20);

            this.Property(t => t.PayType)
                .HasMaxLength(10);

            this.Property(t => t.CustomerOrderNo)
                .HasMaxLength(20);

            this.Property(t => t.Currency)
                .HasMaxLength(4);

            this.Property(t => t.Remark)
                .HasMaxLength(200);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(20);

            this.Property(t => t.LastUpdatedBy)
                .HasMaxLength(50);

            this.Property(t => t.FlagApp)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.AppUser)
                .HasMaxLength(20);

        }
    }
}

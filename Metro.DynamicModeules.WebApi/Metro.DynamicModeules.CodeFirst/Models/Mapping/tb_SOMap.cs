using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_SOMap : EntityTypeConfiguration<tb_SO>
    {
        public tb_SOMap()
        {
            // Primary Key
            this.HasKey(t => t.SONO);

            // Properties
            this.Property(t => t.ISID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.SONO)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.VerNo)
                .HasMaxLength(2);

            this.Property(t => t.CustomerCode)
                .HasMaxLength(20);

            this.Property(t => t.PayType)
                .HasMaxLength(10);

            this.Property(t => t.CustomerOrderNo)
                .HasMaxLength(20);

            this.Property(t => t.Salesman)
                .HasMaxLength(20);

            this.Property(t => t.Currency)
                .HasMaxLength(4);

            this.Property(t => t.FinishingStatus)
                .HasMaxLength(10);

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

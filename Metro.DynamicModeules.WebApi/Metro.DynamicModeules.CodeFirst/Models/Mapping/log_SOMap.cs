using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class log_SOMap : EntityTypeConfiguration<log_SO>
    {
        public log_SOMap()
        {
            // Primary Key
            this.HasKey(t => t.C_TmpKey);

            // Properties
            this.Property(t => t.C_TmpKey)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.C_CreateBy)
                .HasMaxLength(20);

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

            // Table & Column Mappings
            this.ToTable("log_SO");
            this.Property(t => t.C_TmpKey).HasColumnName("_TmpKey");
            this.Property(t => t.C_CreateBy).HasColumnName("_CreateBy");
            this.Property(t => t.C_CreateDate).HasColumnName("_CreateDate");
            this.Property(t => t.ISID).HasColumnName("ISID");
            this.Property(t => t.SONO).HasColumnName("SONO");
            this.Property(t => t.VerNo).HasColumnName("VerNo");
            this.Property(t => t.CustomerCode).HasColumnName("CustomerCode");
            this.Property(t => t.ReceiveDay).HasColumnName("ReceiveDay");
            this.Property(t => t.PayType).HasColumnName("PayType");
            this.Property(t => t.CustomerOrderNo).HasColumnName("CustomerOrderNo");
            this.Property(t => t.Salesman).HasColumnName("Salesman");
            this.Property(t => t.Currency).HasColumnName("Currency");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.FinishingStatus).HasColumnName("FinishingStatus");
            this.Property(t => t.OrderFinishDay).HasColumnName("OrderFinishDay");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.CreationDate).HasColumnName("CreationDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.LastUpdateDate).HasColumnName("LastUpdateDate");
            this.Property(t => t.LastUpdatedBy).HasColumnName("LastUpdatedBy");
            this.Property(t => t.FlagApp).HasColumnName("FlagApp");
            this.Property(t => t.AppUser).HasColumnName("AppUser");
            this.Property(t => t.AppDate).HasColumnName("AppDate");
        }
    }
}

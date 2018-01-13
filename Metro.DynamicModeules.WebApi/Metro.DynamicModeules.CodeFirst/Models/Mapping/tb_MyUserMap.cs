using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_MyUserMap : EntityTypeConfiguration<tb_MyUser>
    {
        public tb_MyUserMap()
        {
            // Primary Key
            this.HasKey(t => t.isid);

            // Properties
            this.Property(t => t.Account)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.NovellAccount)
                .HasMaxLength(100);

            this.Property(t => t.DomainName)
                .HasMaxLength(100);

            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Address)
                .HasMaxLength(50);

            this.Property(t => t.Tel)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(40);

            this.Property(t => t.Password)
                .HasMaxLength(100);

            this.Property(t => t.FlagAdmin)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.FlagOnline)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.DataSets)
                .HasMaxLength(250);

        }
    }
}

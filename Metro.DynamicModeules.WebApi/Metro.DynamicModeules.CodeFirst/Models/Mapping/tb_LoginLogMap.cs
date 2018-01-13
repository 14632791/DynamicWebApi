using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_LoginLogMap : EntityTypeConfiguration<tb_LoginLog>
    {
        public tb_LoginLogMap()
        {
            // Primary Key
            this.HasKey(t => t.isid);

            // Properties
            this.Property(t => t.Account)
                .HasMaxLength(20);

            this.Property(t => t.LoginType)
                .IsFixedLength()
                .HasMaxLength(1);

        }
    }
}

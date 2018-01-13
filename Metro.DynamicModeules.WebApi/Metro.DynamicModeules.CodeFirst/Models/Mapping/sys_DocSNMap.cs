using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class sys_DocSNMap : EntityTypeConfiguration<sys_DocSN>
    {
        public sys_DocSNMap()
        {
            // Primary Key
            this.HasKey(t => t.isid);

            // Properties
            this.Property(t => t.DocName)
                .HasMaxLength(10);

            this.Property(t => t.Header)
                .HasMaxLength(2);

            this.Property(t => t.YYMM)
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.Remark)
                .HasMaxLength(100);

        }
    }
}

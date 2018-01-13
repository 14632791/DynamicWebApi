using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class sys_FieldNameDefsMap : EntityTypeConfiguration<sys_FieldNameDefs>
    {
        public sys_FieldNameDefsMap()
        {
            // Primary Key
            this.HasKey(t => t.isid);

            // Properties
            this.Property(t => t.TableName)
                .HasMaxLength(50);

            this.Property(t => t.FieldName)
                .HasMaxLength(50);

            this.Property(t => t.DisplayName)
                .HasMaxLength(50);

            this.Property(t => t.Remark)
                .HasMaxLength(100);

            this.Property(t => t.FlagDisplay)
                .IsFixedLength()
                .HasMaxLength(1);

        }
    }
}

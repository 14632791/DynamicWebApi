using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_LogDtlMap : EntityTypeConfiguration<tb_LogDtl>
    {
        public tb_LogDtlMap()
        {
            // Primary Key
            this.HasKey(t => t.isid);

            // Properties
            this.Property(t => t.GUID32)
                .HasMaxLength(32);

            this.Property(t => t.TableName)
                .HasMaxLength(20);

            this.Property(t => t.FieldName)
                .HasMaxLength(20);

            this.Property(t => t.OldValue)
                .HasMaxLength(250);

            this.Property(t => t.NewValue)
                .HasMaxLength(250);

        }
    }
}

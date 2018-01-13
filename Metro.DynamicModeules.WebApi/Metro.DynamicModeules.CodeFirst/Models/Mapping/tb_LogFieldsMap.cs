using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_LogFieldsMap : EntityTypeConfiguration<tb_LogFields>
    {
        public tb_LogFieldsMap()
        {
            // Primary Key
            this.HasKey(t => t.isid);

            // Properties
            this.Property(t => t.TableName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.FieldName)
                .IsRequired()
                .HasMaxLength(20);

        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_CommDataDictTypeMap : EntityTypeConfiguration<tb_CommDataDictType>
    {
        public tb_CommDataDictTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.DataType);

            // Properties
            this.Property(t => t.isid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.DataType)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.TypeName)
                .HasMaxLength(20);

        }
    }
}

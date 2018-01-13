using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class vw_CommonDataDictsMap : EntityTypeConfiguration<vw_CommonDataDicts>
    {
        public vw_CommonDataDictsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.DataType, t.DataName });

            // Properties
            this.Property(t => t.DataType)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DataName)
                .IsRequired()
                .HasMaxLength(12);

        }
    }
}

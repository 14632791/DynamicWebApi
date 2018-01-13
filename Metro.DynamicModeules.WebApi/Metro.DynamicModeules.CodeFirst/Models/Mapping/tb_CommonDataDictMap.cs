using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_CommonDataDictMap : EntityTypeConfiguration<tb_CommonDataDict>
    {
        public tb_CommonDataDictMap()
        {
            // Primary Key
            this.HasKey(t => t.ISID);

            // Properties
            this.Property(t => t.DataCode)
                .HasMaxLength(20);

            this.Property(t => t.NativeName)
                .HasMaxLength(100);

            this.Property(t => t.EnglishName)
                .HasMaxLength(50);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(20);

            this.Property(t => t.LastUpdatedBy)
                .HasMaxLength(20);

        }
    }
}
